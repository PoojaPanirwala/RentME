using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentME.Migrations
{
    /// <inheritdoc />
    public partial class phase11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    placeAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    postalcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressID);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    carID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    carName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    carModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usedmiles = table.Column<int>(type: "int", nullable: false),
                    purchasedate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cartype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ownerid = table.Column<int>(type: "int", nullable: false),
                    carimages = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.carID);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    postID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    postType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    addedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    addedBy = table.Column<int>(type: "int", nullable: false),
                    typeid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.postID);
                });

            migrationBuilder.CreateTable(
                name: "Rented",
                columns: table => new
                {
                    rentedID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rentedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rentedFrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rentedDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rented", x => x.rentedID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Rented");
        }
    }
}
