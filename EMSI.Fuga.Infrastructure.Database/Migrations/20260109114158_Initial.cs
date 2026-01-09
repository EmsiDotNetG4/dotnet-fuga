using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMSI.Fuga.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlightDAO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartureFrom = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    ArrivalTo = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalSeats = table.Column<int>(type: "integer", nullable: false),
                    AvailableSeats = table.Column<int>(type: "integer", nullable: false),
                    PlaneNumber = table.Column<int>(type: "integer", nullable: false),
                    DirectFlight = table.Column<bool>(type: "boolean", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightDAO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PassengerDAO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Tel = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Nationality = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PassportNumber = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassengerDAO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookingDAO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    PassengerId = table.Column<Guid>(type: "uuid", nullable: false),
                    FlightId = table.Column<Guid>(type: "uuid", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CheckingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CancellationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SeatNumber = table.Column<int>(type: "integer", nullable: false),
                    NumberOfKg = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDAO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingDAO_FlightDAO_FlightId",
                        column: x => x.FlightId,
                        principalTable: "FlightDAO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingDAO_PassengerDAO_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "PassengerDAO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingDAO_FlightId",
                table: "BookingDAO",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDAO_PassengerId",
                table: "BookingDAO",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_PassengerDAO_Email",
                table: "PassengerDAO",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PassengerDAO_Tel",
                table: "PassengerDAO",
                column: "Tel",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingDAO");

            migrationBuilder.DropTable(
                name: "FlightDAO");

            migrationBuilder.DropTable(
                name: "PassengerDAO");
        }
    }
}
