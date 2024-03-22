using Entidades.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> option) : base(option) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Table
            modelBuilder.Entity<Client>().ToTable("Clients");
            modelBuilder.Entity<Reservation>().ToTable("Reservations");
            modelBuilder.Entity<Room>().ToTable("Rooms");

            #endregion
            #region Keys
            modelBuilder.Entity<Client>().HasKey(c => c.Id);
            modelBuilder.Entity<Reservation>().HasKey(r => r.Id);
            modelBuilder.Entity<Room>().HasKey(r => r.Id);

            #endregion
            #region Relationship
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Client)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.IdClient);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Room)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.IdRoom);
            #endregion
            #region Properties
            #region ClientRegion
            modelBuilder.Entity<Client>().Property(c => c.FirstName).HasMaxLength(50);
            modelBuilder.Entity<Client>().Property(c => c.LastName).HasMaxLength(50);
            modelBuilder.Entity<Client>().Property(c => c.DocumentId).HasMaxLength(20);
            #endregion
            #endregion
        }

    }
}
