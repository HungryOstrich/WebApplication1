using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class AA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Entry",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Entry_CreatedById",
                table: "Entry",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Entry_AspNetUsers_CreatedById",
                table: "Entry",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entry_AspNetUsers_CreatedById",
                table: "Entry");

            migrationBuilder.DropIndex(
                name: "IX_Entry_CreatedById",
                table: "Entry");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Entry");
        }
    }
}
