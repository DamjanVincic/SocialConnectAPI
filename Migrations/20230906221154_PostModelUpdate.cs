using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialConnectAPI.Migrations
{
    /// <inheritdoc />
    public partial class PostModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbUserDTO_Posts_PostId",
                table: "DbUserDTO");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Posts_PostId",
                table: "Tag");

            migrationBuilder.DropTable(
                name: "DbCommentDTO");

            migrationBuilder.DropIndex(
                name: "IX_DbUserDTO_PostId",
                table: "DbUserDTO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "DbUserDTO");

            migrationBuilder.RenameTable(
                name: "Tag",
                newName: "Tags");

            migrationBuilder.RenameIndex(
                name: "IX_Tag_PostId",
                table: "Tags",
                newName: "IX_Tags_PostId");

            migrationBuilder.AddColumn<int>(
                name: "LikeCount",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Posts_PostId",
                table: "Tags",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Posts_PostId",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "LikeCount",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tag");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_PostId",
                table: "Tag",
                newName: "IX_Tag_PostId");

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "DbUserDTO",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DbCommentDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbCommentDTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbCommentDTO_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DbCommentDTO_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbUserDTO_PostId",
                table: "DbUserDTO",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_DbCommentDTO_PostId",
                table: "DbCommentDTO",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_DbCommentDTO_UserId",
                table: "DbCommentDTO",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DbUserDTO_Posts_PostId",
                table: "DbUserDTO",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Posts_PostId",
                table: "Tag",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
