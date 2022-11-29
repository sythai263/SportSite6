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

	[ForeignKey("media_id")]
	public Media? media { get; set; }

	[ForeignKey("user_id")]
	public User? user { get; set; }

	[Column("created_at", TypeName = "datetime")]
	[DataType(DataType.Date)]
	public DateTime createdAt { get; set; }

	[Column("created_by", TypeName = "int")]
	public int createdBy { get; set; }

}