using DoStuff.Core.Data.Models;
using DoStuff.Core.Data.Persistence.Models;

using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Infrastructure.Scoping;
using Umbraco.Extensions;

namespace DoStuff.Core.Data.Persistence;
internal class ToDoListRepository : DoStuffRepositoryBase<ToDoListDTO, ToDoList>,
	IToDoListRepository
{
	public ToDoListRepository(
		IScopeAccessor scopeAccessor,
		IProfilingLogger profilingLogger,
		IUmbracoMapper umbracoMapper)
		: base(scopeAccessor, profilingLogger, umbracoMapper,
			DataConstants.ToDoListTableName)
	{ }

	public IEnumerable<ToDoList> GetByNode(Guid nodeKey)
	{
		var sql = GetBaseQuery(false)
			.Where<ToDoListDTO>(x => x.NodeKey == nodeKey);

		var results = Database.Fetch<ToDoListDTO>(sql);

		return umbracoMapper.Map<IEnumerable<ToDoList>>(results) ?? [];
	}
}
