using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VivaCityWebApi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class update3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ressources_Users_Id",
                table: "Ressources");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Ressources",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ressources_UserId",
                table: "Ressources",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ressources_Users_UserId",
                table: "Ressources",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ressources_Users_UserId",
                table: "Ressources");

            migrationBuilder.DropIndex(
                name: "IX_Ressources_UserId",
                table: "Ressources");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Ressources");

            migrationBuilder.AddForeignKey(
                name: "FK_Ressources_Users_Id",
                table: "Ressources",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
