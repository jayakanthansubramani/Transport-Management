using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TransportManagement.Models
{
    public partial class TransportManagementContext : DbContext
    {
        public TransportManagementContext()
        {
        }

        public TransportManagementContext(DbContextOptions<TransportManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Route> Routes { get; set; } = null!;
        public virtual DbSet<Vehicle> Vehicles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-LPJJ8J9;Database=TransportManagement;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.Password)
                    .HasMaxLength(80)
                    .IsFixedLength();

                entity.Property(e => e.UserName)
                    .HasMaxLength(80)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Employee_Name");

                entity.Property(e => e.Location)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.VehicleId).HasColumnName("Vehicle_ID");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("FK__Employee__Vehicl__5629CD9C");
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.HasKey(e => e.RoutetId)
                    .HasName("PK__Route__64D88DF0B815A705");

                entity.ToTable("Route");

                entity.Property(e => e.RoutetId).HasColumnName("RoutetID");

                entity.Property(e => e.RouteNo)
                    .HasMaxLength(20)
                    .HasColumnName("RouteNO")
                    .IsFixedLength();

                entity.Property(e => e.Stop1)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Stop_1");

                entity.Property(e => e.Stop2)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Stop_2");

                entity.Property(e => e.VehicleNo).HasColumnName("Vehicle_No");

                entity.HasOne(d => d.VehicleNoNavigation)
                    .WithMany(p => p.Routes)
                    .HasForeignKey(d => d.VehicleNo)
                    .HasConstraintName("FK__Route__Vehicle_N__534D60F1");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("Vehicle");

                entity.Property(e => e.VehicleId).HasColumnName("VehicleID");

                entity.Property(e => e.AvailableSeats).HasColumnName("Available_seats");

                entity.Property(e => e.Operable)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleNo)
                    .HasMaxLength(20)
                    .HasColumnName("Vehicle_No")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
