using NPoco;

using Umbraco.Cms.Infrastructure.Persistence.DatabaseAnnotations;

namespace DoStuff.Core.Data.Persistence.Models;
internal class BaseItemDTO
{
	[Column("id")]
	[PrimaryKeyColumn]
	public int Id { get; set; }

	[Column("Key")]
	public required Guid Key { get; set; }


}
