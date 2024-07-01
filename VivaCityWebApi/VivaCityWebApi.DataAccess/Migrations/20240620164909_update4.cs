using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VivaCityWebApi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class update4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ressources_Users_UserId",
                table: "Ressources");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Ressources",
                newName: "VillageId");

            migrationBuilder.RenameIndex(
                name: "IX_Ressources_UserId",
                table: "Ressources",
                newName: "IX_Ressources_VillageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ressources_Villages_VillageId",
                table: "Ressources",
                column: "VillageId",
                principalTable: "Villages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ressources_Villages_VillageId",
                table: "Ressources");

            migrationBuilder.RenameColumn(
                name: "VillageId",
                table: "Ressources",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ressources_VillageId",
                table: "Ressources",
                newName: "IX_Ressources_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ressources_Users_UserId",
                table: "Ressources",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
