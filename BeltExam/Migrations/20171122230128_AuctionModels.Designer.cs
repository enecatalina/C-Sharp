using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BeltExam.Models;

namespace BeltExam.Migrations
{
    [DbContext(typeof(BeltExamContext))]
    [Migration("20171122230128_AuctionModels")]
    partial class AuctionModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("BeltExam.Models.Auctions", b =>
                {
                    b.Property<int>("idAuction")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("Finished");

                    b.Property<string>("Product");

                    b.Property<float>("StartingBid");

                    b.Property<TimeSpan>("TimeRemaining");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("idUser");

                    b.HasKey("idAuction");

                    b.HasIndex("idUser");

                    b.ToTable("Auctions");
                });

            modelBuilder.Entity("BeltExam.Models.Bids", b =>
                {
                    b.Property<int>("idBid")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<bool>("HighestBid");

                    b.Property<int>("idAuction");

                    b.Property<int>("idUser");

                    b.HasKey("idBid");

                    b.HasIndex("idAuction");

                    b.HasIndex("idUser");

                    b.ToTable("Bids");
                });

            modelBuilder.Entity("BeltExam.Models.Users", b =>
                {
                    b.Property<int>("idUser")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Balance");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("idUser");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BeltExam.Models.Auctions", b =>
                {
                    b.HasOne("BeltExam.Models.Users", "User")
                        .WithMany("Auctions")
                        .HasForeignKey("idUser")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BeltExam.Models.Bids", b =>
                {
                    b.HasOne("BeltExam.Models.Auctions", "Auctions")
                        .WithMany("Bids")
                        .HasForeignKey("idAuction")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BeltExam.Models.Users", "User")
                        .WithMany("Bids")
                        .HasForeignKey("idUser")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
