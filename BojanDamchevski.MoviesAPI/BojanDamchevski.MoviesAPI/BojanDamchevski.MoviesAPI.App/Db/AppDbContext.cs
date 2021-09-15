using BojanDamchevski.MoviesAPI.App.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BojanDamchevski.MoviesAPI.App.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Director>()
                .HasMany(x => x.Movies)
                .WithOne(x => x.Director)
                .HasForeignKey(x => x.DirectorId);

            modelBuilder.Entity<Movie>()
                .HasOne(x => x.Director)
                .WithMany(x => x.Movies)
                .HasForeignKey(x => x.DirectorId);


            modelBuilder.Entity<Movie>()
                .HasData(
                new Movie
                {
                    Id = 1,
                    Description = "description1",
                    Genre = GenreEnum.Action,
                    Title = "ActionMovie",
                    Year = 2000,
                    DirectorId = 1
                },
                new Movie
                {
                    Id = 2,
                    Description = "description1",
                    Genre = GenreEnum.Romance,
                    Title = "RomanceMovie",
                    Year = 2012,
                    DirectorId = 3
                },
                new Movie
                {
                    Id = 3,
                    Description = "Des3",
                    Genre = GenreEnum.Mystery,
                    Title = "MysteryMovie",
                    Year = 2022,
                    DirectorId = 2
                });

            modelBuilder.Entity<Director>()
                .HasData(
                new Director
                {
                    Id = 1,
                    Country = "Country1",
                    FirstName = "Director1",
                    LastName = "Director1Ln"
                },
                new Director
                {
                    Id = 2,
                    Country = "Country2",
                    FirstName = "Director2",
                    LastName = "Director2Ln"
                },
                new Director
                {
                    Id = 3,
                    Country = "Country3",
                    FirstName = "Director3",
                    LastName = "Director3Ln"
                });

        }
    }
}
