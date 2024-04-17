using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DoStuff.Core.Data.Models;
using DoStuff.Core.Data.Persistence.Models;

using Umbraco.Cms.Core.Mapping;

namespace DoStuff.Core.Data.Mapping;
internal class ToDoItemMappingDefinitions : IMapDefinition
{
	public void DefineMaps(IUmbracoMapper mapper)
	{
		mapper.Define<ToDoItem, ToDoItemDTO>(
			(source, context) => new ToDoItemDTO()
			{
				Key = source.Key,
				TaskName = source.TaskName,
			},
			(source, target, context) =>
			{
				target.Id = source.Id;
				target.Key = source.Key;
				target.ListKey = source.ListKey;
				target.TaskName = source.TaskName;
				target.Status = (int)source.Status;
			});

		mapper.Define<ToDoItemDTO, ToDoItem>(
			(source, context) => new ToDoItem()
			{
				Key = source.Key,
				TaskName = source.TaskName,
			},
			(source, target, context) =>
			{
				target.Id = source.Id;
				target.Key = source.Key;
				target.ListKey = source.ListKey;
				target.TaskName = source.TaskName;
				target.Status = (ToDoItemStatus)source.Status;
			});
	}
}
