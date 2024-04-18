using DoStuff.Core.Data.Models;

namespace DoStuff.Core.Data.Services;

public interface IToDoListService : IDoStuffServiceBase<ToDoList>
{
	IEnumerable<ToDoList> GetByNode(Guid nodeKey);
}