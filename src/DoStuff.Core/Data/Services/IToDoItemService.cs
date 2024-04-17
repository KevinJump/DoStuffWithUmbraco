using DoStuff.Core.Data.Models;

namespace DoStuff.Core.Data.Services;
internal interface IToDoItemService : IDoStuffServiceBase<ToDoItem>
{
	IEnumerable<ToDoItem> GetItemsInList(Guid key);
}