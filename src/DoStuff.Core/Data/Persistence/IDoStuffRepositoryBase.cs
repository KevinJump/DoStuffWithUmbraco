using NPoco;

using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Infrastructure.Persistence;

namespace DoStuff.Core.Data.Persistence;
internal interface IDoStuffRepositoryBase<TModel> where TModel : class
{
	int Count();
	void Delete(int id);
	TModel? Get(int id);
	IEnumerable<TModel> GetAll(params int[] ids);
	PagedModel<TModel> GetAllPaged(int page, int pageSize, params int[] ids);
	PagedModel<TModel> GetPaged(int page, int pageSize, Sql<ISqlContext> sql);
	TModel? Save(TModel model);
}