using DoStuff.Core.Data.Models;

namespace DoStuff.Core.Data.Persistence;

public interface IToDoListRepository : IDoStuffRepositoryBase<ToDoList>
{
	// methods for this repo.
	IEnumerable<ToDoList> GetByNode(Guid nodeKey);
}