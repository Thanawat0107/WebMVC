using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P04_RelationDB.Migrations
{
    /// <inheritdoc />
    public partial class CategoryToProductV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ComPonents_FeatureID",
                table: "ComPonents");

            migrationBuilder.DropColumn(
                name: "ComPonent",
                table: "Features");

            migrationBuilder.CreateIndex(
                name: "IX_ComPonents_FeatureID",
                table: "ComPonents",
                column: "FeatureID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ComPonents_FeatureID",
                table: "ComPonents");

            migrationBuilder.AddColumn<int>(
                name: "ComPonent",
                table: "Features",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ComPonents_FeatureID",
                table: "ComPonents",
                column: "FeatureID");
        }
    }
}
