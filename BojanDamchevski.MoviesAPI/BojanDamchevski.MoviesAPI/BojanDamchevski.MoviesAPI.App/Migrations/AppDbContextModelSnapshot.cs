﻿// <auto-generated />
using BojanDamchevski.MoviesAPI.App.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BojanDamchevski.MoviesAPI.App.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BojanDamchevski.MoviesAPI.App.Models.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Directors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Country = "Country1",
                            FirstName = "Director1",
                            LastName = "Director1Ln"
                        },
                        new
                        {
                            Id = 2,
                            Country = "Country2",
                            FirstName = "Director2",
                            LastName = "Director2Ln"
                        },
                        new
                        {
                            Id = 3,
                            Country = "Country3",
                            FirstName = "Director3",
                            LastName = "Director3Ln"
                        });
                });

            modelBuilder.Entity("BojanDamchevski.MoviesAPI.App.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DirectorId")
                        .HasColumnType("int");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "description1",
                            DirectorId = 1,
                            Genre = 5,
                            Title = "ActionMovie",
                            Year = 2000
                        },
                        new
                        {
                            Id = 2,
                            Description = "description1",
                            DirectorId = 3,
                            Genre = 3,
                            Title = "RomanceMovie",
                            Year = 2012
                        },
                        new
                        {
                            Id = 3,
                            Description = "Des3",
                            DirectorId = 2,
                            Genre = 4,
                            Title = "MysteryMovie",
                            Year = 2022
                        });
                });

            modelBuilder.Entity("BojanDamchevski.MoviesAPI.App.Models.Movie", b =>
                {
                    b.HasOne("BojanDamchevski.MoviesAPI.App.Models.Director", "Director")
                        .WithMany("Movies")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Director");
                });

            modelBuilder.Entity("BojanDamchevski.MoviesAPI.App.Models.Director", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
