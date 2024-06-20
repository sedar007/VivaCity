using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VivaCityWebApi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batiments_Couts_Id",
                table: "Batiments");

            migrationBuilder.AddColumn<int>(
                name: "CoutId",
                table: "Batiments",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Batiments_CoutId",
                table: "Batiments",
                column: "CoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batiments_Couts_CoutId",
                table: "Batiments",
                column: "CoutId",
                principalTable: "Couts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batiments_Couts_CoutId",
                table: "Batiments");

            migrationBuilder.DropIndex(
                name: "IX_Batiments_CoutId",
                table: "Batiments");

            migrationBuilder.DropColumn(
                name: "CoutId",
                table: "Batiments");

            migrationBuilder.AddForeignKey(
                name: "FK_Batiments_Couts_Id",
                table: "Batiments",
                column: "Id",
                principalTable: "Couts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
