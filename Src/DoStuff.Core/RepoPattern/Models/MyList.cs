using NPoco;

using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace DoStuff.Core.RepoPattern.Models
{
    [TableName(RepoPattern.MyListTable)]
    [PrimaryKey("id")]
    [ExplicitColumns]
    public class MyList
    {
        [Column("id")]
        [PrimaryKeyColumn]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Completed")]
        public bool Completed { get; set; }
    }
}
