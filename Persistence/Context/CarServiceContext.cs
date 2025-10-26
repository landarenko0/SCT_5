using Microsoft.EntityFrameworkCore;
using Persistence.Models;

namespace Persistence.Context;

public partial class CarServiceContext(DbContextOptions<CarServiceContext> options) : DbContext(options)
{
    internal virtual DbSet<EmployeeDto> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
