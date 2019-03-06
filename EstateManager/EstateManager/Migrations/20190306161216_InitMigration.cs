using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstateManager.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quality = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: true),
                    Longitude = table.Column<double>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    CellPhone = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EstateId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    PubDate = table.Column<DateTime>(nullable: false),
                    SignDate = table.Column<DateTime>(nullable: true),
                    CloseDate = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EstateId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MainPhotoId = table.Column<int>(nullable: true),
                    OwnerId = table.Column<int>(nullable: false),
                    Surface = table.Column<float>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    RoomsCount = table.Column<int>(nullable: false),
                    BuildDate = table.Column<DateTime>(nullable: true),
                    FloorCount = table.Column<int>(nullable: false),
                    FloorNumber = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: true),
                    Longitude = table.Column<double>(nullable: true),
                    EnergyEfficiency = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estate_Photo_MainPhotoId",
                        column: x => x.MainPhotoId,
                        principalTable: "Photo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estate_Person_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contract_EstateId",
                table: "Contract",
                column: "EstateId");

            migrationBuilder.CreateIndex(
                name: "IX_Estate_MainPhotoId",
                table: "Estate",
                column: "MainPhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estate_OwnerId",
                table: "Estate",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_EstateId",
                table: "Photo",
                column: "EstateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Estate_EstateId",
                table: "Contract",
                column: "EstateId",
                principalTable: "Estate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Estate_EstateId",
                table: "Photo",
                column: "EstateId",
                principalTable: "Estate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Estate_EstateId",
                table: "Photo");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "Estate");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
