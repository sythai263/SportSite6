using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SportSite6.Models;
[Table("category")]
public class Category
{
	[Key]
	[Column("id", TypeName = "int")]
	public int id { get; set; }

	[Column("title", TypeName = "varchar(2000)")]
	public string? title { get; set; }

	[Column("slug", TypeName = "varchar(255)")]
	public string? slug { get; set; }

	[Column("description", TypeName = "text")]
	public string? description { get; set; }

	[Column("display", TypeName = "tinyint")]
	public byte display { get; set; }

	[ForeignKey("media_id")]
	public Media? media { get; set; }

}