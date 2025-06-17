using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<HouseCommittee> HouseCommittees { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Resident> Residents { get; set; }
        public DbSet<RepairType> RepairTypes { get; set; }
        public DbSet<RepairStatus> RepairStatuses { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<MeetingAttendance> MeetingAttendances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Building - HouseCommittee: Cascade delete on Building
            modelBuilder.Entity<HouseCommittee>()
                .HasOne(hc => hc.Building)
                .WithMany(b => b.HouseCommittees)
                .HasForeignKey(hc => hc.BuildingId)
                .OnDelete(DeleteBehavior.Cascade);

            // Resident - HouseCommittee: Restrict delete to avoid multiple cascade paths
            modelBuilder.Entity<HouseCommittee>()
                .HasOne(hc => hc.Resident)
                .WithMany()
                .HasForeignKey(hc => hc.ResidentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Apartment relationships
            modelBuilder.Entity<Apartment>()
                .HasOne(a => a.HouseCommittee)
                .WithMany()
                .HasForeignKey(a => a.HouseCommitteeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Apartment>()
                .HasOne(a => a.Building)
                .WithMany(b => b.Apartments)
                .HasForeignKey(a => a.BuildingId)
                .OnDelete(DeleteBehavior.Cascade);

            // Resident - Apartment relationship
            modelBuilder.Entity<Resident>()
                .HasOne(r => r.Apartment)
                .WithMany(a => a.Residents)
                .HasForeignKey(r => r.ApartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Repair relationships
            modelBuilder.Entity<Repair>()
                .HasOne(r => r.Resident)
                .WithMany(r2 => r2.Repairs)
                .HasForeignKey(r => r.ResidentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Repair>()
                .HasOne(r => r.RepairType)
                .WithMany(rt => rt.Repairs)
                .HasForeignKey(r => r.RepairTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Repair>()
                .HasOne(r => r.RepairStatus)
                .WithMany(rs => rs.Repairs)
                .HasForeignKey(r => r.RepairStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            // Meeting and MeetingAttendance relationships
            modelBuilder.Entity<MeetingAttendance>()
                .HasOne(ma => ma.Meeting)
                .WithMany(m => m.Attendances)
                .HasForeignKey(ma => ma.MeetingId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MeetingAttendance>()
                .HasOne(ma => ma.Resident)
                .WithMany(r => r.MeetingAttendances)
                .HasForeignKey(ma => ma.ResidentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}