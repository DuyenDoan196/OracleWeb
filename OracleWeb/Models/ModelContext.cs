using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OracleWeb.Models;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<PayRoll> PayRolls { get; set; }

    public virtual DbSet<Positon> Positons { get; set; }

    public virtual DbSet<Timekeeping> Timekeepings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl)));User Id=K19;Password=oracle;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("K19")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.HasIndex(e => e.PositonId, "IX_Relationship5");

            entity.Property(e => e.EmployeeId)
                .HasColumnType("NUMBER")
                .HasColumnName("Employee_Id");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Birth).HasColumnType("DATE");
            entity.Property(e => e.Gender).HasColumnType("NUMBER");
            entity.Property(e => e.Name).HasMaxLength(60);
            entity.Property(e => e.PositonId)
                .HasColumnType("NUMBER")
                .HasColumnName("Positon_Id");

            entity.HasOne(d => d.Positon).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PositonId)
                .HasConstraintName("has");
        });

        modelBuilder.Entity<PayRoll>(entity =>
        {
            entity.ToTable("PayRoll");

            entity.HasIndex(e => e.EmployeeId, "IX_Relationship6");

            entity.Property(e => e.PayRollId)
                .HasColumnType("NUMBER")
                .HasColumnName("PayRoll_id");
            entity.Property(e => e.Coefficients).HasColumnType("FLOAT");
            entity.Property(e => e.DatePaid)
                .HasColumnType("DATE")
                .HasColumnName("Date_paid");
            entity.Property(e => e.EmployeeId)
                .HasColumnType("NUMBER")
                .HasColumnName("Employee_Id");
            entity.Property(e => e.TotalHourInAMonth)
                .HasColumnType("NUMBER")
                .HasColumnName("Total_Hour_In_a_month");
            entity.Property(e => e.TotalSalary)
                .HasColumnType("NUMBER")
                .HasColumnName("Total_Salary");

            entity.HasOne(d => d.Employee).WithMany(p => p.PayRolls)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_Employee_Payroll");
        });

        modelBuilder.Entity<Positon>(entity =>
        {
            entity.ToTable("Positon");

            entity.Property(e => e.PositonId)
                .HasColumnType("NUMBER")
                .HasColumnName("Positon_Id");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Salary).HasColumnType("FLOAT");
        });

        modelBuilder.Entity<Timekeeping>(entity =>
        {
            entity.ToTable("Timekeeping");

            entity.HasIndex(e => e.EmployeeId, "IX_Relationship7");

            entity.Property(e => e.TimekeepingId)
                .HasColumnType("NUMBER")
                .HasColumnName("Timekeeping_id");
            entity.Property(e => e.CheckIn).HasColumnType("DATE");
            entity.Property(e => e.CheckOut).HasColumnType("DATE");
            entity.Property(e => e.EmployeeId)
                .HasColumnType("NUMBER")
                .HasColumnName("Employee_Id");
            entity.Property(e => e.TotalHours).HasColumnType("NUMBER");

            entity.HasOne(d => d.Employee).WithMany(p => p.Timekeepings)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_Employee_TimeKeeping");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
