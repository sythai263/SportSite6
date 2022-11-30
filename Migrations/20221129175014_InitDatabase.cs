using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportSite6.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "media",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(2000)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    original_name = table.Column<string>(type: "varchar(2000)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    source = table.Column<string>(type: "varchar(2000)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    alt_text = table.Column<string>(type: "varchar(2000)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    media_type = table.Column<short>(type: "smallint", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_media", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone = table.Column<string>(type: "varchar(15)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    gender = table.Column<int>(type: "int", nullable: false),
                    birthday = table.Column<DateTime>(type: "date", nullable: false),
                    role = table.Column<string>(type: "enum('Admin', 'User')", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(2000)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    slug = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    display = table.Column<sbyte>(type: "tinyint", nullable: false),
                    media_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                    table.ForeignKey(
                        name: "FK_category_media_media_id",
                        column: x => x.media_id,
                        principalTable: "media",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "evaluation",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    content = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    rate = table.Column<short>(type: "smallint", nullable: false),
                    media_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evaluation", x => x.id);
                    table.ForeignKey(
                        name: "FK_evaluation_media_media_id",
                        column: x => x.media_id,
                        principalTable: "media",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_evaluation_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "page",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(2000)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    slug = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    heading = table.Column<string>(type: "varchar(5000)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    approve = table.Column<sbyte>(type: "tinyint", nullable: false),
                    media_id = table.Column<int>(type: "int", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_page", x => x.id);
                    table.ForeignKey(
                        name: "FK_page_category_category_id",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_page_media_media_id",
                        column: x => x.media_id,
                        principalTable: "media",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "content",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    heading = table.Column<string>(type: "varchar(5000)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    information = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    display = table.Column<sbyte>(type: "tinyint", nullable: false),
                    media_id = table.Column<int>(type: "int", nullable: true),
                    page_id = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_content", x => x.id);
                    table.ForeignKey(
                        name: "FK_content_media_media_id",
                        column: x => x.media_id,
                        principalTable: "media",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_content_page_page_id",
                        column: x => x.page_id,
                        principalTable: "page",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_category_media_id",
                table: "category",
                column: "media_id");

            migrationBuilder.CreateIndex(
                name: "IX_content_media_id",
                table: "content",
                column: "media_id");

            migrationBuilder.CreateIndex(
                name: "IX_content_page_id",
                table: "content",
                column: "page_id");

            migrationBuilder.CreateIndex(
                name: "IX_evaluation_media_id",
                table: "evaluation",
                column: "media_id");

            migrationBuilder.CreateIndex(
                name: "IX_evaluation_user_id",
                table: "evaluation",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_page_category_id",
                table: "page",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_page_media_id",
                table: "page",
                column: "media_id");

						migrationBuilder.Sql(@"
ALTER TABLE user ALTER gender SET DEFAULT 0;
ALTER TABLE user ALTER role SET DEFAULT 'User';
ALTER TABLE media ALTER media_type SET DEFAULT 0;
ALTER TABLE media ALTER created_by SET DEFAULT 0;
ALTER TABLE media ALTER created_at SET DEFAULT NOW();
ALTER TABLE category ALTER display SET DEFAULT 1;
ALTER TABLE page ALTER approve SET DEFAULT 0;
ALTER TABLE page ALTER created_at SET DEFAULT NOW();
ALTER TABLE page ALTER created_by SET DEFAULT 0;
ALTER TABLE page ALTER updated_at SET DEFAULT NOW();
ALTER TABLE content ALTER display SET DEFAULT 0;
ALTER TABLE content ALTER created_at SET DEFAULT NOW();
ALTER TABLE content ALTER created_by SET DEFAULT 0;
ALTER TABLE content ALTER updated_at SET DEFAULT NOW();
ALTER TABLE evaluation ALTER rate SET DEFAULT 5;
ALTER TABLE evaluation ALTER created_at SET DEFAULT NOW();
ALTER TABLE evaluation ALTER created_by SET DEFAULT 0;
", true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "content");

            migrationBuilder.DropTable(
                name: "evaluation");

            migrationBuilder.DropTable(
                name: "page");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "media");
        }
    }
}
