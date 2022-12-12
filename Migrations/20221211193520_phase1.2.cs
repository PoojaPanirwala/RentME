using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentME.Migrations
{
    /// <inheritdoc />
    public partial class phase12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "postID1",
                table: "Post",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_postID1",
                table: "Post",
                column: "postID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Post_postID1",
                table: "Post",
                column: "postID1",
                principalTable: "Post",
                principalColumn: "postID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Post_postID1",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_postID1",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "postID1",
                table: "Post");
        }
    }
}
