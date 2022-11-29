using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SportSite6.Models;
[Table("media")]
public class Media
{
	[Key]
	[Column("id", TypeName = "int")]
	public int id { get; set; }
	[Column("title", TypeName = "varchar(2000)")]
	public string? title { get; set; }
	[Column("original_name", TypeName = "varchar(2000)")]
	public string? originalName { get; set; }

	[Column("source", TypeName = "varchar(2000)")]
	public string? source { get; set; }

	[Column("alt_text", TypeName = "varchar(2000)")]
	public string? altText { get; set; }

	[Column("media_type", TypeName = "smallint")]
	public int mediaType { get; set; }

	[Column("created_at", TypeName = "datetime")]
	[DataType(DataType.Date)]
	public DateTime createdAt { get; set; }

	[Column("created_by", TypeName = "int")]
	public int createdBy { get; set; }


}