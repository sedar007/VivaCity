using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VivaCityWebApi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class jointure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batiments_Couts_coutId",
                table: "Batiments");

            migrationBuilder.DropForeignKey(
                name: "FK_Ressources_RessourceItem_RessourceItemId",
                table: "Ressources");

            migrationBuilder.DropForeignKey(
                name: "FK_Ressources_Users_UserDaoId",
                table: "Ressources");

            migrationBuilder.DropForeignKey(
                name: "FK_Villages_Users_UserDaoId",
                table: "Villages");

            migrationBuilder.DropIndex(
                name: "IX_Ressources_RessourceItemId",
                table: "Ressources");

            migrationBuilder.DropIndex(
                name: "IX_Ressources_UserDaoId",
                table: "Ressources");

            migrationBuilder.DropIndex(
                name: "IX_Batiments_coutId",
                table: "Batiments");

            migrationBuilder.DropColumn(
                name: "RessourceItemId",
                table: "Ressources");

            migrationBuilder.DropColumn(
                name: "UserDaoId",
                table: "Ressources");

            migrationBuilder.DropColumn(
                name: "coutId",
                table: "Batiments");

            migrationBuilder.RenameColumn(
                name: "UserDaoId",
                table: "Villages",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Villages_UserDaoId",
                table: "Villages",
                newName: "IX_Villages_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "RessourceId",
                table: "Couts",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "VillageId",
                table: "Batiments",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Batiments_VillageId",
                table: "Batiments",
                column: "VillageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batiments_Couts_Id",
                table: "Batiments",
                column: "Id",
                principalTable: "Couts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Batiments_Villages_VillageId",
                table: "Batiments",
                column: "VillageId",
                principalTable: "Villages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ressources_RessourceItem_Id",
                table: "Ressources",
                column: "Id",
                principalTable: "RessourceItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ressources_Users_Id",
                table: "Ressources",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Villages_Users_UserId",
                table: "Villages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batiments_Couts_Id",
                table: "Batiments");

            migrationBuilder.DropForeignKey(
                name: "FK_Batiments_Villages_VillageId",
                table: "Batiments");

            migrationBuilder.DropForeignKey(
                name: "FK_Ressources_RessourceItem_Id",
                table: "Ressources");

            migrationBuilder.DropForeignKey(
                name: "FK_Ressources_Users_Id",
                table: "Ressources");

            migrationBuilder.DropForeignKey(
                name: "FK_Villages_Users_UserId",
                table: "Villages");

            migrationBuilder.DropIndex(
                name: "IX_Batiments_VillageId",
                table: "Batiments");

            migrationBuilder.DropColumn(
                name: "VillageId",
                table: "Batiments");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Villages",
                newName: "UserDaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Villages_UserId",
                table: "Villages",
                newName: "IX_Villages_UserDaoId");

            migrationBuilder.AddColumn<int>(
                name: "RessourceItemId",
                table: "Ressources",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserDaoId",
                table: "Ressources",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RessourceId",
                table: "Couts",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "coutId",
                table: "Batiments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ressources_RessourceItemId",
                table: "Ressources",
                column: "RessourceItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Ressources_UserDaoId",
                table: "Ressources",
                column: "UserDaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Batiments_coutId",
                table: "Batiments",
                column: "coutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batiments_Couts_coutId",
                table: "Batiments",
                column: "coutId",
                principalTable: "Couts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ressources_RessourceItem_RessourceItemId",
                table: "Ressources",
                column: "RessourceItemId",
                principalTable: "RessourceItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ressources_Users_UserDaoId",
                table: "Ressources",
                column: "UserDaoId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Villages_Users_UserDaoId",
                table: "Villages",
                column: "UserDaoId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
