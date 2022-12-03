using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportSite6.Migrations
{
	public partial class AddViewsToPage : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
					name: "FK_page_category_category_id",
					table: "page");

			migrationBuilder.DropForeignKey(
					name: "FK_page_media_media_id",
					table: "page");

			migrationBuilder.AlterColumn<int>(
					name: "media_id",
					table: "page",
					type: "int",
					nullable: false,
					defaultValue: 0,
					oldClrType: typeof(int),
					oldType: "int",
					oldNullable: true);

			migrationBuilder.AlterColumn<int>(
					name: "category_id",
					table: "page",
					type: "int",
					nullable: false,
					defaultValue: 0,
					oldClrType: typeof(int),
					oldType: "int",
					oldNullable: true);

			migrationBuilder.AddColumn<int>(
					name: "views",
					table: "page",
					type: "int",
					nullable: false,
					defaultValue: 0);

			migrationBuilder.AddForeignKey(
					name: "FK_page_category_category_id",
					table: "page",
					column: "category_id",
					principalTable: "category",
					principalColumn: "id",
					onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
					name: "FK_page_media_media_id",
					table: "page",
					column: "media_id",
					principalTable: "media",
					principalColumn: "id",
					onDelete: ReferentialAction.Cascade);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
					name: "FK_page_category_category_id",
					table: "page");

			migrationBuilder.DropForeignKey(
					name: "FK_page_media_media_id",
					table: "page");

			migrationBuilder.DropColumn(
					name: "views",
					table: "page");

			migrationBuilder.AlterColumn<int>(
					name: "media_id",
					table: "page",
					type: "int",
					nullable: true,
					oldClrType: typeof(int),
					oldType: "int");

			migrationBuilder.AlterColumn<int>(
					name: "category_id",
					table: "page",
					type: "int",
					nullable: true,
					oldClrType: typeof(int),
					oldType: "int");

			migrationBuilder.AddForeignKey(
					name: "FK_page_category_category_id",
					table: "page",
					column: "category_id",
					principalTable: "category",
					principalColumn: "id");

			migrationBuilder.AddForeignKey(
					name: "FK_page_media_media_id",
					table: "page",
					column: "media_id",
					principalTable: "media",
					principalColumn: "id");
		}
	}
}
