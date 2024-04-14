namespace DoStuff.Core.Data.Models;

public class ToDoList : DoStuffBaseItem
{
	/// <summary>
	///  name of the list.
	/// </summary>
	public required string Name { get; set; }

	/// <summary>
	///  status of the list
	/// </summary>
	public ToDoListStatus Status { get; set; }

	/// <summary>
	///  key of the umbraco node that this item is assigned to.
	/// </summary>
	public Guid? NodeKey { get; set; }

	/// <summary>
	///  username? of the user who created the list ?
	/// </summary>
	public string? Owner { get; set; }

}
