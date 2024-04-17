using DoStuff.Core.Data.Models;
using DoStuff.Core.Data.Persistence.Models;

using Umbraco.Cms.Core.Mapping;

namespace DoStuff.Core.Data.Mapping;
internal class ToDoListMappingDefinitionss : IMapDefinition
{
	public void DefineMaps(IUmbracoMapper mapper)
	{
		mapper.Define<ToDoList, ToDoListDTO>(
			(source, context) => new ToDoListDTO()
			{
				Name = source.Name,
				Key = source.Key
			},
			(source, target, context) =>
			{
				target.Id = source.Id;
				target.Name = source.Name;
				target.Key = source.Key;
				target.Owner = source.Owner;
				target.NodeKey = source.NodeKey;
				target.Status = (int)source.Status;
			});

		mapper.Define<ToDoListDTO, ToDoList>(
			(source, context) => new ToDoList()
			{
				Name = source.Name,
				Key = source.Key
			},
			(source, target, context) =>
			{
				target.Id = source.Id;
				target.Name = source.Name;
				target.Key = source.Key;
				target.Owner = source.Owner;
				target.NodeKey = source.NodeKey;
				target.Status = (ToDoListStatus)source.Status;
			});
	}
}
