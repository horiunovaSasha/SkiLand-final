using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SkiLand.DAL.Migrations
{
    public partial class main_db_scheme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquipmentRentals",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentRentals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentStates",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExcursionAgencies",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ContactInformation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcursionAgencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExcursionServices",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcursionServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelaxComplexes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Raiting = table.Column<float>(nullable: false),
                    ContactInformation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelaxComplexes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelaxServises",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Duration = table.Column<string>(nullable: true),
                    NeededEquipment = table.Column<string>(nullable: true),
                    Contraindication = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelaxServises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomAmenities",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAmenities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    EquipmentTypeId = table.Column<long>(nullable: true),
                    EquipmentStateId = table.Column<long>(nullable: true),
                    EquipmentRentalId = table.Column<long>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipments_EquipmentRentals_EquipmentRentalId",
                        column: x => x.EquipmentRentalId,
                        principalTable: "EquipmentRentals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipments_EquipmentStates_EquipmentStateId",
                        column: x => x.EquipmentStateId,
                        principalTable: "EquipmentStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipments_EquipmentTypes_EquipmentTypeId",
                        column: x => x.EquipmentTypeId,
                        principalTable: "EquipmentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExcurisionBookings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExcursionServiceId = table.Column<long>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    IsConfirmed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcurisionBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExcurisionBookings_ExcursionServices_ExcursionServiceId",
                        column: x => x.ExcursionServiceId,
                        principalTable: "ExcursionServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExcursionAgencyServices",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExcursionAgencyId = table.Column<long>(nullable: true),
                    ExcursionServiceId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcursionAgencyServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExcursionAgencyServices_ExcursionAgencies_ExcursionAgencyId",
                        column: x => x.ExcursionAgencyId,
                        principalTable: "ExcursionAgencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExcursionAgencyServices_ExcursionServices_ExcursionServiceId",
                        column: x => x.ExcursionServiceId,
                        principalTable: "ExcursionServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Raiting = table.Column<float>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    PhotoId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotels_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Raiting = table.Column<float>(nullable: false),
                    TimeOpen = table.Column<DateTime>(nullable: false),
                    TimeClose = table.Column<DateTime>(nullable: false),
                    PhotoId = table.Column<long>(nullable: true),
                    ContactInformation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurants_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RelaxServiceBookings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RelaxServiseId = table.Column<long>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    DateAndTime = table.Column<DateTime>(nullable: false),
                    IsConfirmed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelaxServiceBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelaxServiceBookings_RelaxServises_RelaxServiseId",
                        column: x => x.RelaxServiseId,
                        principalTable: "RelaxServises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RelaxServiceRelaxComplexes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RelaxServiseId = table.Column<long>(nullable: true),
                    RelaxComplexId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelaxServiceRelaxComplexes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelaxServiceRelaxComplexes_RelaxComplexes_RelaxComplexId",
                        column: x => x.RelaxComplexId,
                        principalTable: "RelaxComplexes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RelaxServiceRelaxComplexes_RelaxServises_RelaxServiseId",
                        column: x => x.RelaxServiseId,
                        principalTable: "RelaxServises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentBookings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    EquipmentId = table.Column<long>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    IsConfirmed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentBookings_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HotelRooms",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HotelId = table.Column<long>(nullable: true),
                    RoomsCount = table.Column<int>(nullable: false),
                    RoomTypeId = table.Column<long>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelRooms_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HotelRooms_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantBookings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    DateAndTime = table.Column<DateTime>(nullable: false),
                    PeopleCount = table.Column<int>(nullable: false),
                    RestaurantId = table.Column<long>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    IsConfirmed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantBookings_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HotelBookings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HotelRoomId = table.Column<long>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    IsConfirmed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelBookings_HotelRooms_HotelRoomId",
                        column: x => x.HotelRoomId,
                        principalTable: "HotelRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HotelRoomAmenities",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HotelRoomId = table.Column<long>(nullable: true),
                    RoomAmenityId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRoomAmenities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelRoomAmenities_HotelRooms_HotelRoomId",
                        column: x => x.HotelRoomId,
                        principalTable: "HotelRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HotelRoomAmenities_RoomAmenities_RoomAmenityId",
                        column: x => x.RoomAmenityId,
                        principalTable: "RoomAmenities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SeasonRoomPricings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    HotelRoomId = table.Column<long>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonRoomPricings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeasonRoomPricings_HotelRooms_HotelRoomId",
                        column: x => x.HotelRoomId,
                        principalTable: "HotelRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentBookings_EquipmentId",
                table: "EquipmentBookings",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_EquipmentRentalId",
                table: "Equipments",
                column: "EquipmentRentalId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_EquipmentStateId",
                table: "Equipments",
                column: "EquipmentStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_EquipmentTypeId",
                table: "Equipments",
                column: "EquipmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExcurisionBookings_ExcursionServiceId",
                table: "ExcurisionBookings",
                column: "ExcursionServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExcursionAgencyServices_ExcursionAgencyId",
                table: "ExcursionAgencyServices",
                column: "ExcursionAgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExcursionAgencyServices_ExcursionServiceId",
                table: "ExcursionAgencyServices",
                column: "ExcursionServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelBookings_HotelRoomId",
                table: "HotelBookings",
                column: "HotelRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoomAmenities_HotelRoomId",
                table: "HotelRoomAmenities",
                column: "HotelRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoomAmenities_RoomAmenityId",
                table: "HotelRoomAmenities",
                column: "RoomAmenityId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRooms_HotelId",
                table: "HotelRooms",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRooms_RoomTypeId",
                table: "HotelRooms",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_PhotoId",
                table: "Hotels",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_RelaxServiceBookings_RelaxServiseId",
                table: "RelaxServiceBookings",
                column: "RelaxServiseId");

            migrationBuilder.CreateIndex(
                name: "IX_RelaxServiceRelaxComplexes_RelaxComplexId",
                table: "RelaxServiceRelaxComplexes",
                column: "RelaxComplexId");

            migrationBuilder.CreateIndex(
                name: "IX_RelaxServiceRelaxComplexes_RelaxServiseId",
                table: "RelaxServiceRelaxComplexes",
                column: "RelaxServiseId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantBookings_RestaurantId",
                table: "RestaurantBookings",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_PhotoId",
                table: "Restaurants",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_SeasonRoomPricings_HotelRoomId",
                table: "SeasonRoomPricings",
                column: "HotelRoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentBookings");

            migrationBuilder.DropTable(
                name: "ExcurisionBookings");

            migrationBuilder.DropTable(
                name: "ExcursionAgencyServices");

            migrationBuilder.DropTable(
                name: "HotelBookings");

            migrationBuilder.DropTable(
                name: "HotelRoomAmenities");

            migrationBuilder.DropTable(
                name: "RelaxServiceBookings");

            migrationBuilder.DropTable(
                name: "RelaxServiceRelaxComplexes");

            migrationBuilder.DropTable(
                name: "RestaurantBookings");

            migrationBuilder.DropTable(
                name: "SeasonRoomPricings");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "ExcursionAgencies");

            migrationBuilder.DropTable(
                name: "ExcursionServices");

            migrationBuilder.DropTable(
                name: "RoomAmenities");

            migrationBuilder.DropTable(
                name: "RelaxComplexes");

            migrationBuilder.DropTable(
                name: "RelaxServises");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "HotelRooms");

            migrationBuilder.DropTable(
                name: "EquipmentRentals");

            migrationBuilder.DropTable(
                name: "EquipmentStates");

            migrationBuilder.DropTable(
                name: "EquipmentTypes");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "RoomTypes");

            migrationBuilder.DropTable(
                name: "Photos");
        }
    }
}
