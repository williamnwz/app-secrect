using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppSecrect.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    facebookId = table.Column<string>(nullable: true),
                    login = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "friends",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    MeId = table.Column<Guid>(nullable: false),
                    friend = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_friends", x => x.id);
                    table.ForeignKey(
                        name: "FK_friends_users_friend",
                        column: x => x.friend,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_friends_users_MeId",
                        column: x => x.MeId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    responsableId = table.Column<Guid>(nullable: false),
                    create = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.id);
                    table.ForeignKey(
                        name: "FK_posts_users_responsableId",
                        column: x => x.responsableId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    PostId = table.Column<Guid>(nullable: false),
                    create = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    ResponsableId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_comments_posts_PostId",
                        column: x => x.PostId,
                        principalTable: "posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comments_users_ResponsableId",
                        column: x => x.ResponsableId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comments_PostId",
                table: "comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_ResponsableId",
                table: "comments",
                column: "ResponsableId");

            migrationBuilder.CreateIndex(
                name: "IX_friends_friend",
                table: "friends",
                column: "friend");

            migrationBuilder.CreateIndex(
                name: "IX_friends_MeId",
                table: "friends",
                column: "MeId");

            migrationBuilder.CreateIndex(
                name: "IX_posts_responsableId",
                table: "posts",
                column: "responsableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "friends");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
