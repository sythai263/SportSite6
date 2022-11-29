using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SportSite6.Models;
[Table("content")]
public class Content
{
	[Key]
	[Column("id", TypeName = "int")]
	public int id { get; set; }

	[Column("heading", TypeName = "varchar(5000)")]
	public string? heading { get; set; }

	[Column("information", TypeName = "text")]
	public string? information { get; set; }

	[Column("display", TypeName = "tinyint")]
	public byte display { get; set; }

	[ForeignKey("media_id")]
	public Media? media { get; set; }

	[ForeignKey("page_id")]
	public Page? page { get; set; }

	[Column("created_at", TypeName = "datetime")]
	[DataType(DataType.Date)]
	public DateTime createdAt { get; set; }

	[Column("created_by", TypeName = "int")]
	public int createdBy { get; set; }

	[Column("updated_at", TypeName = "datetime")]
	[DataType(DataType.Date)]
	public DateTime updatedAt { get; set; }

}