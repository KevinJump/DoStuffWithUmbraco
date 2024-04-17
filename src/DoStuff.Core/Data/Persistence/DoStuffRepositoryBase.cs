using NPoco;

using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Infrastructure.Persistence.SqlSyntax;
using Umbraco.Cms.Infrastructure.Scoping;
using Umbraco.Extensions;

namespace DoStuff.Core.Data.Persistence;

/// <summary>
///  base repository class. (NPoco)
/// </summary>
/// <remarks>
///  this base class does all the core things, get, save, delete etc,
///  
///  so you will only need to extend for your extra lookups or logic
///  that goes beyond the basic CRUD of an item.
/// </remarks>
internal class DoStuffRepositoryBase<TModelDTO, TModel> : IDoStuffRepositoryBase<TModel> where TModelDTO : class
	where TModel : class
{
	const int _maxParams = 2000; // SqlCE has a 2000 item limit on parameters.

	protected readonly IScopeAccessor scopeAccessor;
	protected readonly IProfilingLogger profilingLogger;
	protected readonly IUmbracoMapper umbracoMapper;
	protected string TableName;

	public DoStuffRepositoryBase(
		IScopeAccessor scopeAccessor,
		IProfilingLogger profilingLogger,
		IUmbracoMapper umbracoMapper,
		string tableName)
	{
		this.scopeAccessor = scopeAccessor;
		this.profilingLogger = profilingLogger;
		this.umbracoMapper = umbracoMapper;
		TableName = tableName;
	}

	protected IScope AmbientScope
	{
		get
		{
			return scopeAccessor.AmbientScope
				?? throw new InvalidOperationException("Cannot run repository without an ambient scope");
		}
	}

	protected IUmbracoDatabase Database => AmbientScope.Database;
	protected ISqlContext SqlContext => AmbientScope.SqlContext;
	protected Sql<ISqlContext> Sql() => SqlContext.Sql();
	protected ISqlSyntaxProvider SqlSyntax => SqlContext.SqlSyntax;

	protected virtual Sql<ISqlContext> GetBaseQuery(bool isCount)
		=> isCount
			? Sql().SelectCount().From<TModelDTO>()
			: Sql().Select($"{TableName}.*").From<TModelDTO>();

	protected virtual string GetBaseWhereClause()
		=> $"{TableName}.Id = @Id";

	public TModel? Get(int id)
	{
		var sql = GetBaseQuery(false)
			.Where(GetBaseWhereClause(), new { Id = id });

		var dto = Database.FirstOrDefault<TModelDTO>(sql);
		if (dto is null) return default;

		// map. 
		return umbracoMapper.Map<TModel>(dto);
	}

	public IEnumerable<TModel> GetAll(params int[] ids)
	{
		if (ids.Length == 0) return DoGetAll();

		int[] uniqueIds = ids.Distinct().ToArray();

		if (uniqueIds.Length <= _maxParams)
			return DoGetAll(uniqueIds);

		// if we are have more than the maxParam value
		// of unique id's that we need to get then
		// we have to split the query up, or SqlCE will
		// get upset.
		List<TModel> results = [];
		foreach (var groupOfIds in uniqueIds.InGroupsOf(_maxParams))
		{
			results.AddRange(DoGetAll(groupOfIds.ToArray()));
		}

		return results;
	}

	/// <summary>
	///  perform the actual get, once the main public function
	///  has tidied up the query, and worked out if we need
	///  to do a single or multiple commands.
	/// </summary>
	private IEnumerable<TModel> DoGetAll(params int[] ids)
	{
		var sql = GetBaseQuery(false);
		if (ids.Length == 0)
		{
			sql.Where($"{TableName}.Id > 0");
		}
		else
		{
			sql.Where($"{TableName}.Id in @Ids", new { Ids = ids });
		}

		var result = Database.Fetch<TModelDTO>(sql);
		return umbracoMapper.Map<IEnumerable<TModel>>(result) ?? [];
	}

	public PagedModel<TModel> GetAllPaged(int page, int pageSize, params int[] ids)
	{
		ids = ids.Distinct().ToArray();

		if (ids.Length > _maxParams && page * pageSize > _maxParams)
		{
			// we are asking for things beyond the max params limit 
			// for simplicity of sample, we are just throwing 
			throw new IndexOutOfRangeException("to many results");
		}

		var sql = GetBaseQuery(false);

		if (ids.Length > 0)
			sql.Where($"{TableName}.id in (@Ids)", new { Ids = ids.Take(_maxParams) });

		// if you are going to page, you need to order by something
		sql.OrderBy($"{TableName}.id");

		var results = Database.Page<TModel>(page, pageSize, sql);

		if (ids.Length > _maxParams)
		{
			// again if there are more than max params, guess 
			results.TotalItems = ids.Length;
			results.TotalPages = (long)Math.Ceiling((decimal)ids.Length / pageSize);
		}

		return new PagedModel<TModel>(results.TotalItems, results.Items);
	}

	public PagedModel<TModel> GetPaged(int page, int pageSize, Sql<ISqlContext> sql)
	{
		var results = Database.Page<TModel>(page, pageSize, sql);

		return new PagedModel<TModel>(results.TotalItems, results.Items);
	}

	public virtual TModel? Save(TModel model)
	{
		var dto = umbracoMapper.Map<TModelDTO>(model);
		if (dto is null)
			throw new InvalidCastException("Cannot convert to DTO model");

		using (var transaction = Database.GetTransaction())
		{
			Database.Save(dto);
			transaction.Complete();
		}

		return umbracoMapper.Map<TModel>(dto);
	}

	public virtual void Delete(int id)
	{
		using (var transaction = Database.GetTransaction())
		{
			Database.Delete(id);
			transaction.Complete();
		}
	}

	public virtual int Count()
	{
		var sql = GetBaseQuery(true);
		return Database.ExecuteScalar<int>(sql);
	}
}
