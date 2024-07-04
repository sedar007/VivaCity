using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VivaCityWebApi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ajout_level_village : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Villages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "RessourceItemId",
                table: "Ressources",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Villages");

            migrationBuilder.AlterColumn<int>(
                name: "RessourceItemId",
                table: "Ressources",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
