using NPoco;

namespace DoStuff.Core.Data.Persistence.Models;

[TableName(DataConstants.ToDoListTableName)]
[PrimaryKey("id")]
[ExplicitColumns]
internal class ToDoListDTO : BaseItemDTO
{
    [Column("ListName")]
    public required string Name { get; set; }

    [Column("Status")]
    public int Status { get; set; }

    [Column("NodeKey")]
    public Guid? NodeKey { get; set; }

    [Column("Owner")]
    public string? Owner { get; set; }
}
