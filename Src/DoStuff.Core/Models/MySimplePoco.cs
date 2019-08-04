using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Persistence.DatabaseAnnotations;
using Umbraco.Core.Persistence.DatabaseModelDefinitions;

namespace DoStuff.Core.Models
{
    [TableName(DoStuff.Tables.MySimpleTable)]
    [PrimaryKey("id")]
    [ExplicitColumns]
    public class MySimplePoco
    {
        [Column("id")]
        [PrimaryKeyColumn]
        public int Id { get; set; }

        [Column("key")]
        // [Constraint(Default = SystemMethods.NewGuid)]
        [Index(IndexTypes.UniqueNonClustered, Name = "IX_mySimpleKeyIndex")]
        public Guid Key { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("date")]
        public DateTime date { get; set; }

        // a new column, so if after release you needed
        // to add something new to the model
        // you would add it to the base class.

        // for first time installs the CreateTableMigration
        // will create the table with the new coloumn

        // for upgrades the AddColumnMigration will add it
        /*
        [Column("myNewColumn")]
        [NullSetting(NullSetting = NullSettings.Null)]
        public string NewColumn { get; set; }
        */
    }
}
