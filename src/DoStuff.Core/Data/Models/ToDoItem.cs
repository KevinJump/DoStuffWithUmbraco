namespace DoStuff.Core.Data.Models;

/// <summary>
///  A todo item
/// </summary>
public class ToDoItem : DoStuffBaseItem
{
	/// <summary>
	///  key of the list that this item belongs to.
	/// </summary>
	public Guid ListKey { get; set; }

	/// <summary>
	///  name of the task to show to user.
	/// </summary>
	public required string TaskName { get; set; }

	/// <summary>
	///  status of the task.
	/// </summary>
	public ToDoItemStatus Status { get; set; }
}
