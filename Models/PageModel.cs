using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SportSite6.Models;
[Table("page")]
public class Page
{
	[Key]
	[Column("id", TypeName = "int")]
	public int id { get; set; }

	[Column("title", TypeName = "varchar(2000)")]
	public string? title { get; set; }

	[Column("slug", TypeName = "varchar(255)")]
	public string? slug { get; set; }

	[Column("heading", TypeName = "varchar(5000)")]
	public string? heading { get; set; }

	[Column("description", TypeName = "text")]
	public string? description { get; set; }

	[Column("approve", TypeName = "tinyint")]
	public byte approve { get; set; }

	[Column("media_id", TypeName = "int")]
	public int mediaID { get; set; }

	// [ForeignKey("media_id")]
	public Media? media { get; set; }

	[Column("category_id", TypeName = "int")]
	public int categoryID { get; set; }

	// [ForeignKey("category_id")]
	public Category? category { get; set; }

	[Column("created_at", TypeName = "datetime")]
	[DataType(DataType.Date)]
	public DateTime createdAt { get; set; }

	[Column("created_by", TypeName = "int")]
	public int createdBy { get; set; }

	[Column("updated_at", TypeName = "datetime")]
	[DataType(DataType.Date)]
	public DateTime updatedAt { get; set; }

}