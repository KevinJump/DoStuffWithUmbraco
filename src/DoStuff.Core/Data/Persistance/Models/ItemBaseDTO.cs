using System.ComponentModel.DataAnnotations.Schema;

using Umbraco.Cms.Infrastructure.Persistence.DatabaseAnnotations;

namespace DoStuff.Core.Data.Persistance.Models;

internal class ItemBaseDTO
{
    [Column("id")]
    [PrimaryKeyColumn]
    public int Id { get; set; }

    [Column("key")]
    public required Guid Key { get; set; }
}
