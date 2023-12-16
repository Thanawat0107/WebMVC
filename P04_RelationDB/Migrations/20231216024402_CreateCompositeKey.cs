using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P04_RelationDB.Migrations
{
    /// <inheritdoc />
    public partial class CreateCompositeKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComPonentProducts",
                columns: table => new
                {
                    ComponentId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComPonentProducts", x => new { x.ProductId, x.ComponentId });
                    table.ForeignKey(
                        name: "FK_ComPonentProducts_ComPonents_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "ComPonents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComPonentProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComPonentProducts_ComponentId",
                table: "ComPonentProducts",
                column: "ComponentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComPonentProducts");
        }
    }
}
