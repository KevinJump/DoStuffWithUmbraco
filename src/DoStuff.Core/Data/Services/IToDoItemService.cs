using DoStuff.Core.Data.Models;

namespace DoStuff.Core.Data.Services;
public interface IToDoItemService : IDoStuffServiceBase<ToDoItem>
{
	IEnumerable<ToDoItem> GetItemsInList(Guid key);
}