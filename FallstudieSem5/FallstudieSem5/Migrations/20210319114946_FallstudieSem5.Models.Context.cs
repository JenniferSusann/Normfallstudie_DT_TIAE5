using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FallstudieSem5.Migrations
{
    public partial class FallstudieSem5ModelsContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangerLevel", x => x.DangerLevelId);
                });

            migrationBuilder.CreateTable(
                name: "HouseNumber",
                columns: table => new
                {
                    HouseNumberID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseNumber", x => x.HouseNumberID);
                });

            migrationBuilder.CreateTable(
                name: "Title",
                columns: table => new
                {
                    TitleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Title", x => x.TitleId);
                });

            migrationBuilder.CreateTable(
                name: "Hazard",
                columns: table => new
                {
                    HazardId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DangerLevelId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hazard", x => x.HazardId);
                    table.ForeignKey(
                        name: "FK_Hazard_DangerLevel_DangerLevelId",
                        column: x => x.DangerLevelId,
                        principalTable: "DangerLevel",
                        principalColumn: "DangerLevelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Street",
                columns: table => new
                {
                    StreetId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    HouseNumberID = table.Column<long>(type: "bigint", nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Street", x => x.StreetId);
                    table.ForeignKey(
                        name: "FK_Street_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Street_HouseNumber_HouseNumberID",
                        column: x => x.HouseNumberID,
                        principalTable: "HouseNumber",
                        principalColumn: "HouseNumberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address_Street_StreetId",
                        column: x => x.StreetId,
                        principalTable: "Street",
                        principalColumn: "StreetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Object",
                columns: table => new
                {
                    ObjectId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripton = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Object", x => x.ObjectId);
                    table.ForeignKey(
                        name: "FK_Object_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HazardObject",
                columns: table => new
                {
                    HazardsHazardId = table.Column<long>(type: "bigint", nullable: false),
                    ObjectsObjectId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HazardObject", x => new { x.HazardsHazardId, x.ObjectsObjectId });
                    table.ForeignKey(
                        name: "FK_HazardObject_Hazard_HazardsHazardId",
                        column: x => x.HazardsHazardId,
                        principalTable: "Hazard",
                        principalColumn: "HazardId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HazardObject_Object_ObjectsObjectId",
                        column: x => x.ObjectsObjectId,
                        principalTable: "Object",
                        principalColumn: "ObjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleId = table.Column<long>(type: "bigint", nullable: false),
                    ObjectId = table.Column<long>(type: "bigint", nullable: true),
                    AddressId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Person_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_Object_ObjectId",
                        column: x => x.ObjectId,
                        principalTable: "Object",
                        principalColumn: "ObjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_Title_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Title",
                        principalColumn: "TitleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObjectOwner",
                columns: table => new
                {
                    ObjectOwnerId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectOwner", x => x.ObjectOwnerId);
                    table.ForeignKey(
                        name: "FK_ObjectOwner_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyOwner",
                columns: table => new
                {
                    PropertyOwnerId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyOwner", x => x.PropertyOwnerId);
                    table.ForeignKey(
                        name: "FK_PropertyOwner_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    PersonId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffId);
                    table.ForeignKey(
                        name: "FK_Staff_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_StreetId",
                table: "Address",
                column: "StreetId");

            migrationBuilder.CreateIndex(
                name: "IX_Hazard_DangerLevelId",
                table: "Hazard",
                column: "DangerLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_HazardObject_ObjectsObjectId",
                table: "HazardObject",
                column: "ObjectsObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Object_AddressId",
                table: "Object",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectOwner_PersonId",
                table: "ObjectOwner",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_AddressId",
                table: "Person",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_ObjectId",
                table: "Person",
                column: "ObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_TitleId",
                table: "Person",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyOwner_PersonId",
                table: "PropertyOwner",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_PersonId",
                table: "Staff",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Street_CityId",
                table: "Street",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Street_HouseNumberID",
                table: "Street",
                column: "HouseNumberID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HazardObject");

            migrationBuilder.DropTable(
                name: "ObjectOwner");

            migrationBuilder.DropTable(
                name: "PropertyOwner");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Hazard");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "DangerLevel");

            migrationBuilder.DropTable(
                name: "Object");

            migrationBuilder.DropTable(
                name: "Title");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Street");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "HouseNumber");
        }
    }
}
