using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BeltExam.Migrations
{
    public partial class AuctionModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Balance",
                table: "Users",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Auctions",
                columns: table => new
                {
                    idAuction = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Finished = table.Column<bool>(nullable: false),
                    Product = table.Column<string>(nullable: true),
                    StartingBid = table.Column<float>(nullable: false),
                    TimeRemaining = table.Column<TimeSpan>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    idUser = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.idAuction);
                    table.ForeignKey(
                        name: "FK_Auctions_Users_idUser",
                        column: x => x.idUser,
                        principalTable: "Users",
                        principalColumn: "idUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bids",
                columns: table => new
                {
                    idBid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Amount = table.Column<double>(nullable: false),
                    HighestBid = table.Column<bool>(nullable: false),
                    idAuction = table.Column<int>(nullable: false),
                    idUser = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.idBid);
                    table.ForeignKey(
                        name: "FK_Bids_Auctions_idAuction",
                        column: x => x.idAuction,
                        principalTable: "Auctions",
                        principalColumn: "idAuction",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bids_Users_idUser",
                        column: x => x.idUser,
                        principalTable: "Users",
                        principalColumn: "idUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_idUser",
                table: "Auctions",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_idAuction",
                table: "Bids",
                column: "idAuction");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_idUser",
                table: "Bids",
                column: "idUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bids");

            migrationBuilder.DropTable(
                name: "Auctions");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Users");
        }
    }
}
