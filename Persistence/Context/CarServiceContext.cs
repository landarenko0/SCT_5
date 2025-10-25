using Microsoft.EntityFrameworkCore;
using Persistence.Models;

namespace Persistence.Context;

public partial class CarServiceContext(DbContextOptions<CarServiceContext> options) : DbContext(options)
{
    internal virtual DbSet<EmployeeDto> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql("Host=192.168.250.133;Port=5432;Database=sct_2025;Username=sct_2025_g5;Password=SCT&2025%5");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("fastfood_3", "order_status", ["new", "preparing", "ready", "completed", "cancelled"])
            .HasPostgresEnum("fastfood_3", "payment_method", ["cash", "card", "online"])
            .HasPostgresEnum("fastfood_3", "payment_status", ["pending", "completed", "failed", "refunded"])
            .HasPostgresEnum("hospital_2", "bed_status_t", ["free", "occupied", "maintenance"])
            .HasPostgresEnum("hospital_2", "discharge_status_t", ["alive", "dead", "transferred", "left_against_medical_advice", "unknown"])
            .HasPostgresEnum("hospital_2", "gender_t", ["male", "female"])
            .HasPostgresExtension("productstore_1", "pgcrypto");

        modelBuilder.Entity<EmployeeDto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employees_pkey");

            entity.ToTable("employees", "carservice_5");

            entity.HasIndex(e => new { e.FirstName, e.LastName }, "employees_first_name_last_name_idx").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Salary).HasColumnName("salary");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
