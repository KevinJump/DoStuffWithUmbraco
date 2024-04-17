using Umbraco.Cms.Core.Models;

namespace DoStuff.Core.Data.Services;
internal interface IDoStuffServiceBase<TModel> where TModel : class
{
	int Count();
	void Delete(int id);
	TModel? Get(int id);
	IEnumerable<TModel> GetAll(params int[] ids);
	PagedModel<TModel> GetAllPaged(int page, int pageSize, params int[] ids);
	TModel? Save(TModel item);
}