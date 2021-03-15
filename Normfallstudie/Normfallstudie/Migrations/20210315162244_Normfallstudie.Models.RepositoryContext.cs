using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Normfallstudie.Migrations
{
    public partial class NormfallstudieModelsRepositoryContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "DangerLevel",
                columns: table => new
                {
                    DangerLevelId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangerLevel", x => x.DangerLevelId);
                });

            migrationBuilder.CreateTable(
                name: "Hazard",
                columns: table => new
                {
                    HazardId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hazard", x => x.HazardId);
                });

            migrationBuilder.CreateTable(
                name: "HouseNumber",
                columns: table => new
                {
                    HouseNumberID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseNumber", x => x.HouseNumberID);
                });

            migrationBuilder.CreateTable(
                name: "Object",
                columns: table => new
                {
                    ObjectId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripton = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Object", x => x.ObjectId);
                });

            migrationBuilder.CreateTable(
                name: "ObjectOwner",
                columns: table => new
                {
                    ObjectOwnerId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectOwner", x => x.ObjectOwnerId);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "PropertyOwner",
                columns: table => new
                {
                    PropertyOwnerId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyOwner", x => x.PropertyOwnerId);
                });

            migrationBuilder.CreateTable(
                name: "staff",
                columns: table => new
                {
                    StaffId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staff", x => x.StaffId);
                });

            migrationBuilder.CreateTable(
                name: "Street",
                columns: table => new
                {
                    StreetId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseNumber = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Street", x => x.StreetId);
                    table.ForeignKey(
                        name: "FK_Street_HouseNumber_HouseNumber",
                        column: x => x.HouseNumber,
                        principalTable: "HouseNumber",
                        principalColumn: "HouseNumberID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Street_HouseNumber",
                table: "Street",
                column: "HouseNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "DangerLevel");

            migrationBuilder.DropTable(
                name: "Hazard");

            migrationBuilder.DropTable(
                name: "Object");

            migrationBuilder.DropTable(
                name: "ObjectOwner");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "PropertyOwner");

            migrationBuilder.DropTable(
                name: "staff");

            migrationBuilder.DropTable(
                name: "Street");

            migrationBuilder.DropTable(
                name: "HouseNumber");
        }
    }
}
