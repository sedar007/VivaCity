using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VivaCityWebApi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "batiment_id_seq");

            migrationBuilder.CreateSequence(
                name: "cout_id_seq");

            migrationBuilder.CreateSequence(
                name: "ressource_id_seq");

            migrationBuilder.CreateSequence(
                name: "ressource_item_id_seq");

            migrationBuilder.CreateSequence(
                name: "user_id_seq");

            migrationBuilder.CreateSequence(
                name: "village_id_seq");

            migrationBuilder.CreateTable(
                name: "RessourceItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('ressource_item_id_seq')"),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Picture = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RessourceItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('user_id_seq')"),
                    Pseudo = table.Column<string>(type: "text", nullable: false),
                    Scores = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ressources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('ressource_id_seq')"),
                    RessourceItemId = table.Column<int>(type: "integer", nullable: false),
                    Nbr = table.Column<double>(type: "double precision", nullable: false),
                    Max = table.Column<double>(type: "double precision", nullable: false),
                    UserDaoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ressources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ressources_RessourceItem_RessourceItemId",
                        column: x => x.RessourceItemId,
                        principalTable: "RessourceItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ressources_Users_UserDaoId",
                        column: x => x.UserDaoId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Villages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('village_id_seq')"),
                    UserDaoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Villages_Users_UserDaoId",
                        column: x => x.UserDaoId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Couts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('cout_id_seq')"),
                    Nbr = table.Column<int>(type: "integer", nullable: false),
                    RessourceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Couts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Couts_Ressources_RessourceId",
                        column: x => x.RessourceId,
                        principalTable: "Ressources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Batiments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('batiment_id_seq')"),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    coutId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batiments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Batiments_Couts_coutId",
                        column: x => x.coutId,
                        principalTable: "Couts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Batiments_coutId",
                table: "Batiments",
                column: "coutId");

            migrationBuilder.CreateIndex(
                name: "IX_Couts_RessourceId",
                table: "Couts",
                column: "RessourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Ressources_RessourceItemId",
                table: "Ressources",
                column: "RessourceItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Ressources_UserDaoId",
                table: "Ressources",
                column: "UserDaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Villages_UserDaoId",
                table: "Villages",
                column: "UserDaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Batiments");

            migrationBuilder.DropTable(
                name: "Villages");

            migrationBuilder.DropTable(
                name: "Couts");

            migrationBuilder.DropTable(
                name: "Ressources");

            migrationBuilder.DropTable(
                name: "RessourceItem");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropSequence(
                name: "batiment_id_seq");

            migrationBuilder.DropSequence(
                name: "cout_id_seq");

            migrationBuilder.DropSequence(
                name: "ressource_id_seq");

            migrationBuilder.DropSequence(
                name: "ressource_item_id_seq");

            migrationBuilder.DropSequence(
                name: "user_id_seq");

            migrationBuilder.DropSequence(
                name: "village_id_seq");
        }
    }
}
