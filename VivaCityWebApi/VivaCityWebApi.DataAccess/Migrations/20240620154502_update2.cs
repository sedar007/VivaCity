using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VivaCityWebApi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ressources_RessourceItem_Id",
                table: "Ressources");

            migrationBuilder.AddColumn<int>(
                name: "RessourceItemId",
                table: "Ressources",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ressources_RessourceItemId",
                table: "Ressources",
                column: "RessourceItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ressources_RessourceItem_RessourceItemId",
                table: "Ressources",
                column: "RessourceItemId",
                principalTable: "RessourceItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ressources_RessourceItem_RessourceItemId",
                table: "Ressources");

            migrationBuilder.DropIndex(
                name: "IX_Ressources_RessourceItemId",
                table: "Ressources");

            migrationBuilder.DropColumn(
                name: "RessourceItemId",
                table: "Ressources");

            migrationBuilder.AddForeignKey(
                name: "FK_Ressources_RessourceItem_Id",
                table: "Ressources",
                column: "Id",
                principalTable: "RessourceItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
