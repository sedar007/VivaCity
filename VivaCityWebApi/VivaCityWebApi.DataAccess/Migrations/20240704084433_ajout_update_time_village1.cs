using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VivaCityWebApi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ajout_update_time_village1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "updatedAt",
                table: "Villages",
                newName: "UpdatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Villages",
                newName: "updatedAt");
        }
    }
}
