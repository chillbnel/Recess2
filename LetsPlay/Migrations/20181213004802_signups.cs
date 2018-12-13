using Microsoft.EntityFrameworkCore.Migrations;

namespace LetsPlay.Migrations
{
    public partial class signups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Signups",
                table: "Signups");

            migrationBuilder.DropIndex(
                name: "IX_Signups_PostID",
                table: "Signups");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Signups",
                table: "Signups",
                columns: new[] { "PostID", "Username" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Signups",
                table: "Signups");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Signups",
                table: "Signups",
                columns: new[] { "Username", "PostID" });

            migrationBuilder.CreateIndex(
                name: "IX_Signups_PostID",
                table: "Signups",
                column: "PostID",
                unique: true);
        }
    }
}
