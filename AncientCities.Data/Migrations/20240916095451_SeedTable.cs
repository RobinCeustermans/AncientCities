using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AncientCities.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartOf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Population = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EraCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Defunct = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EraDefunct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Capital" },
                    { 2, "Regional capital" },
                    { 3, "Regular city" },
                    { 4, "Trade hub" },
                    { 5, "Port" },
                    { 6, "Town" },
                    { 7, "Village" },
                    { 8, "Hamlet" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Created", "Defunct", "Description", "EraCreated", "EraDefunct", "Name", "PartOf", "Population", "TypeId" },
                values: new object[,]
                {
                    { 1, new DateTime(753, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Greatest city of its time", "BC", null, "Rome", "Roman Empire (after Republic, Kingdom)", 450000, 1 },
                    { 2, new DateTime(859, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "now named Veliky Novgorod, part of Russia", "AD", null, "Novgorod", "Novgorod republic", 40000, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_TypeId",
                table: "Cities",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
