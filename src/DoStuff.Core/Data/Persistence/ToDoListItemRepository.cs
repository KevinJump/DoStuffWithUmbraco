using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DoStuff.Core.Data.Models;
using DoStuff.Core.Data.Persistence.Models;

using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Infrastructure.Scoping;
using Umbraco.Extensions;

namespace DoStuff.Core.Data.Persistence;
internal class ToDoItemRepository : DoStuffRepositoryBase<ToDoItem, ToDoItemDTO>
{
	public ToDoItemRepository(
		IScopeAccessor scopeAccessor,
		IProfilingLogger profilingLogger,
		IUmbracoMapper umbracoMapper) 
		: base(scopeAccessor, profilingLogger, umbracoMapper, 
			DataConstants.ToDoItemTableName)
	{ }

	public IEnumerable<ToDoItem>? GetItemsInList(Guid key)
	{
		var sql = GetBaseQuery(false)
			.Where<ToDoItemDTO>(x => x.ListKey == key);

		var results = Database.Fetch<ToDoItemDTO>();

		return umbracoMapper.Map<IEnumerable<ToDoItem>>(results);

	}
}
