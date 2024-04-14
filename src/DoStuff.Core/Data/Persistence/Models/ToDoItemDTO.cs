using NPoco;

namespace DoStuff.Core.Data.Persistence.Models;

[TableName(DataConstants.ToDoItemTableName)]
[PrimaryKey("id")]
[ExplicitColumns]
internal class ToDoItemDTO : BaseItemDTO 
{
    [Column("ListKey")]
    public Guid ListKey { get; set; }

    [Column("TaskName")]
    public required string TaskName { get; set; }

    [Column("Status")]
    public int Status { get; set; }
}
