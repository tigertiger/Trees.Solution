using Microsoft.EntityFrameworkCore.Migrations;

namespace Trees.Solution.Migrations
{
    public partial class bud : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "PlantId", "Description", "Farm", "Strain", "Type" },
                values: new object[] { 2, "This shit right here tho...PHEW buddy. Get ready!", "GUD Gardens", "In The Pines", "Sativa" });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "PlantId", "Description", "Farm", "Strain", "Type" },
                values: new object[] { 3, "Special Weapon will destroy you.", "Deep Creek Gardens", "Special Weapon", "Sativa" });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "PlantId", "Description", "Farm", "Strain", "Type" },
                values: new object[] { 4, "I know what a GRAPE is. What the fuck is a grape FRUIT?", "Fox Hollow Flora", "Grape Fluff", "Indica" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 4);
        }
    }
}
