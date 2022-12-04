using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportSite6.Migrations
{
    public partial class ModifyForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_evaluation_media_media_id",
                table: "evaluation");

            migrationBuilder.RenameColumn(
                name: "media_id",
                table: "evaluation",
                newName: "page_id");

            migrationBuilder.RenameIndex(
                name: "IX_evaluation_media_id",
                table: "evaluation",
                newName: "IX_evaluation_page_id");

            migrationBuilder.AddForeignKey(
                name: "FK_evaluation_page_page_id",
                table: "evaluation",
                column: "page_id",
                principalTable: "page",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_evaluation_page_page_id",
                table: "evaluation");

            migrationBuilder.RenameColumn(
                name: "page_id",
                table: "evaluation",
                newName: "media_id");

            migrationBuilder.RenameIndex(
                name: "IX_evaluation_page_id",
                table: "evaluation",
                newName: "IX_evaluation_media_id");

            migrationBuilder.AddForeignKey(
                name: "FK_evaluation_media_media_id",
                table: "evaluation",
                column: "media_id",
                principalTable: "media",
                principalColumn: "id");
        }
    }
}
