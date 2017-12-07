using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WeddingPlanner.Models;

namespace WeddingPlanner.Migrations
{
    [DbContext(typeof(WedPlannerContext))]
    [Migration("20171116233621_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("WeddingPlanner.Models.RSVP", b =>
                {
                    b.Property<int>("idRSVP")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("idUser");

                    b.Property<int>("idWedding");

                    b.HasKey("idRSVP");

                    b.HasIndex("idUser");

                    b.HasIndex("idWedding");

                    b.ToTable("rsvp");
                });

            modelBuilder.Entity("WeddingPlanner.Models.Users", b =>
                {
                    b.Property<int>("idUser")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("idUser");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WeddingPlanner.Models.Weddings", b =>
                {
                    b.Property<int>("idWedding")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Bride");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Groom");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("idUser");

                    b.HasKey("idWedding");

                    b.HasIndex("idUser");

                    b.ToTable("weddings");
                });

            modelBuilder.Entity("WeddingPlanner.Models.RSVP", b =>
                {
                    b.HasOne("WeddingPlanner.Models.Users", "Guest")
                        .WithMany("Guests")
                        .HasForeignKey("idUser")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WeddingPlanner.Models.Weddings", "Wedding")
                        .WithMany("Guests")
                        .HasForeignKey("idWedding")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WeddingPlanner.Models.Weddings", b =>
                {
                    b.HasOne("WeddingPlanner.Models.Users", "host")
                        .WithMany("Weddings")
                        .HasForeignKey("idUser")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
