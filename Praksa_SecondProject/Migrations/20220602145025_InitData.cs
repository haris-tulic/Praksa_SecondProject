using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Praksa_SecondProject.Migrations
{
    public partial class InitData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Founded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MainGenre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bands",
                columns: new[] { "Id", "Founded", "MainGenre", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heavy Metal", "Metalica" },
                    { 2, new DateTime(1985, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rock", "Guns N Roses" },
                    { 3, new DateTime(1965, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Disco", "ABBA" },
                    { 4, new DateTime(1985, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rock", "Guns N Roses" },
                    { 5, new DateTime(1986, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pop", "A-ha" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "BandId", "Description", "Title" },
                values: new object[,]
                {
                    { 1, 1, "One of the best heavy metal albums ever", "Master Of Puppets" },
                    { 2, 2, "Amazing Rock album with raw sound", "Appetite for Destruction" },
                    { 3, 3, "Very groovy album", "Waterloo" },
                    { 4, 4, "Arguably one of the best albums by Oasis", "Be Here Now" },
                    { 5, 5, "Awesome Debut album by A-Ha", "Hunting Hight and Low" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_BandId",
                table: "Albums",
                column: "BandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Bands");
        }
    }
}
