using Microsoft.EntityFrameworkCore.Migrations;

namespace SkiLand.DAL.Migrations
{
    public partial class add_hotel_stars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Stars",
                table: "Hotels",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stars",
                table: "Hotels");
        }
    }
}
