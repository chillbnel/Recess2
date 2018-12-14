using Microsoft.EntityFrameworkCore.Migrations;

namespace LetsPlay.Migrations
{
    public partial class plz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PostID",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "PostID",
                table: "Comments",
                newName: "PostNumber");

            migrationBuilder.AddColumn<int>(
                name: "CommentsID",
                table: "Posts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CommentsID",
                table: "Posts",
                column: "CommentsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Comments_CommentsID",
                table: "Posts",
                column: "CommentsID",
                principalTable: "Comments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Comments_CommentsID",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CommentsID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CommentsID",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "PostNumber",
                table: "Comments",
                newName: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostID",
                table: "Comments",
                column: "PostID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostID",
                table: "Comments",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
