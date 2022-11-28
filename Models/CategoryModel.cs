using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SportSite.Models;
[Table("category")]
public class Category
{
	[Key]
	[Column("id", TypeName = "int")]
	public int id { get; set; }
	[Column("title", TypeName = "varchar(2000)")]
	public string title { get; set; }
	[Column("description", TypeName = "text")]
	public string description { get; set; }

	[Column("approve", TypeName = "tinyint")]
	public Int16 approve { get; set; }

	[Column("media_id", TypeName = "int")]
	public int mediaID { get; set; }

	[Column("media_type", TypeName = "smallint")]
	public int mediaType { get; set; }

	[Column("created_at", TypeName = "datetime")]
	[DataType(DataType.Date)]
	public DateTime createdAt { get; set; }

	[Column("created_by", TypeName = "int")]
	public int createdBy { get; set; }

}