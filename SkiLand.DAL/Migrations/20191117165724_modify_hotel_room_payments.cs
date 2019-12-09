using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SkiLand.DAL.Migrations
{
    public partial class modify_hotel_room_payments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotelBookingPayments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookingId = table.Column<long>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Disscount = table.Column<decimal>(nullable: false),
                    IsPercentDisscount = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelBookingPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelBookingPayments_HotelBookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "HotelBookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelBookingPayments_BookingId",
                table: "HotelBookingPayments",
                column: "BookingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelBookingPayments");
        }
    }
}
