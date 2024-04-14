namespace DoStuff.Core.Data.Models;
public class DoStuffBaseItem
{
	/// <summary>
	///  the internal (DB) id of this item
	/// </summary>
	public int Id { get; set; }

	/// <summary>
	///  the internal Key (GUID) of this item
	/// </summary>
	public required Guid Key { get; set; }
}
