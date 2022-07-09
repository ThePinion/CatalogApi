using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace CatalogApiProject.Models
{
    public class RecordsContext : DbContext
    {
        public RecordsContext(DbContextOptions<RecordsContext> options) : base(options) { }

        public DbSet<Artist> Artists { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<ArtistRole> ArtistRoles { get; set; } = null!;
        public DbSet<Record> Records { get; set; } = null!;
        public DbSet<Track> Tracks { get; set; } = null!;

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Record>().HasKey(e => e.Id);
            modelBuilder.Entity<Track>().HasKey(e => e.Id);

            modelBuilder.Entity<Record>().HasMany(r => r.Tracks).WithOne();
            modelBuilder.Entity<Track>().HasMany(t => t.Subtracks).WithOne();

            modelBuilder.Entity<Record>().Navigation(r => r.Tracks).AutoInclude();
            modelBuilder.Entity<Track>().Navigation(t => t.Subtracks).AutoInclude();
        }
        #endregion
    }
}
