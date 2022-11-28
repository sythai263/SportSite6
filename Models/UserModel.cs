using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportSite.Models;

[Table("user")]
public class User
{
	[Key]
	[Column("id", TypeName = "int")]
	public int id { get; set; }
	[Column("username", TypeName = "varchar(50)")]
	public string? username { get; set; }
	[Column("password", TypeName = "varchar(255)")]
	public string? password { get; set; }
	[Column("name", TypeName = "varchar(255)")]
	public string? name { get; set; }

	[Column("phone", TypeName = "varchar(15)")]
	public string? phone { get; set; }
	[Column("email", TypeName = "varchar(255)")]
	public string? email { get; set; }

	[Column("gender", TypeName = "int")]
	public int gender { get; set; }

	[DataType(DataType.Date)]
	[Column("birthday", TypeName = "date")]
	public DateTime birthday { get; set; }

	[Column("role", TypeName = "enum('Admin', 'User')")]
	[EnumDataType(typeof(RoleEnum))]
	public object? role { get; set; }


}