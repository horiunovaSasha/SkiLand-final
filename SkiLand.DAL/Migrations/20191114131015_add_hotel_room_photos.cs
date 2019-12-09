using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SkiLand.DAL.Migrations
{
    public partial class add_hotel_room_photos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Adults",
                table: "HotelRooms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Children",
                table: "HotelRooms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "HotelRoomPhotos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoomId = table.Column<long>(nullable: true),
                    PhotoId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRoomPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelRoomPhotos_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HotelRoomPhotos_HotelRooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "HotelRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoomPhotos_PhotoId",
                table: "HotelRoomPhotos",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoomPhotos_RoomId",
                table: "HotelRoomPhotos",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelRoomPhotos");

            migrationBuilder.DropColumn(
                name: "Adults",
                table: "HotelRooms");

            migrationBuilder.DropColumn(
                name: "Children",
                table: "HotelRooms");
        }
    }
}
