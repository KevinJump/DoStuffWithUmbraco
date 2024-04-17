using DoStuff.Core.Data.Models;

namespace DoStuff.Core.Data.Persistence;
internal interface IToDoItemRepository : IDoStuffRepositoryBase<ToDoItem>
{
	IEnumerable<ToDoItem> GetItemsInList(Guid key);
}