using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SportSite6.Models;
[Table("evaluation")]
public class Evaluation
{
	[Key]
	[Column("id", TypeName = "int")]
	public int id { get; set; }

	[Column("content", TypeName = "text")]
	public string? content { get; set; }

	[Column("rate", TypeName = "smallint")]
	public short rate { get; set; }

	[ForeignKey("page_id")]
	[Column("page_id", TypeName = "int")]
	public int? pageID { get; set; }

	public Page? page { get; set; }

	[ForeignKey("user_id")]
	[Column("user_id", TypeName = "int")]
	public int? userID { get; set; }

	public User? user { get; set; }

	[Column("created_at", TypeName = "datetime")]
	[DataType(DataType.Date)]
	public DateTime createdAt { get; set; }

	[Column("created_by", TypeName = "int")]
	public int createdBy { get; set; }

}