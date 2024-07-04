using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VivaCityWebApi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ajout_picture_batiment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Batiments",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Batiments");
        }
    }
}
