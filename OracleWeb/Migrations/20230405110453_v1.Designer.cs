﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using OracleWeb.Models;

#nullable disable

namespace OracleWeb.Migrations
{
    [DbContext(typeof(ModelContext))]
    [Migration("20230405110453_v1")]
    partial class v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("K19")
                .UseCollation("USING_NLS_COMP")
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OracleWeb.Models.Employee", b =>
                {
                    b.Property<decimal>("EmployeeId")
                        .HasColumnType("NUMBER")
                        .HasColumnName("Employee_Id");

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<DateTime?>("Birth")
                        .HasColumnType("DATE");

                    b.Property<decimal?>("Gender")
                        .HasColumnType("NUMBER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("NVARCHAR2(60)");

                    b.Property<decimal?>("PositonId")
                        .HasColumnType("NUMBER")
                        .HasColumnName("Positon_Id");

                    b.Property<bool>("isDelete")
                        .HasColumnType("NUMBER(1)");

                    b.HasKey("EmployeeId");

                    b.HasIndex(new[] { "PositonId" }, "IX_Relationship5");

                    b.ToTable("Employee", "K19");
                });

            modelBuilder.Entity("OracleWeb.Models.PayRoll", b =>
                {
                    b.Property<decimal>("PayRollId")
                        .HasColumnType("NUMBER")
                        .HasColumnName("PayRoll_id");

                    b.Property<decimal?>("Coefficients")
                        .HasColumnType("FLOAT");

                    b.Property<DateTime?>("DatePaid")
                        .HasColumnType("DATE")
                        .HasColumnName("Date_paid");

                    b.Property<decimal?>("EmployeeId")
                        .HasColumnType("NUMBER")
                        .HasColumnName("Employee_Id");

                    b.Property<decimal?>("TotalHourInAMonth")
                        .HasColumnType("NUMBER")
                        .HasColumnName("Total_Hour_In_a_month");

                    b.Property<decimal?>("TotalSalary")
                        .HasColumnType("NUMBER")
                        .HasColumnName("Total_Salary");

                    b.Property<bool>("isDelete")
                        .HasColumnType("NUMBER(1)");

                    b.HasKey("PayRollId");

                    b.HasIndex(new[] { "EmployeeId" }, "IX_Relationship6");

                    b.ToTable("PayRoll", "K19");
                });

            modelBuilder.Entity("OracleWeb.Models.Positon", b =>
                {
                    b.Property<decimal>("PositonId")
                        .HasColumnType("NUMBER")
                        .HasColumnName("Positon_Id");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("FLOAT");

                    b.Property<bool>("isDelete")
                        .HasColumnType("NUMBER(1)");

                    b.HasKey("PositonId");

                    b.ToTable("Positon", "K19");
                });

            modelBuilder.Entity("OracleWeb.Models.Timekeeping", b =>
                {
                    b.Property<decimal>("TimekeepingId")
                        .HasColumnType("NUMBER")
                        .HasColumnName("Timekeeping_id");

                    b.Property<DateTime?>("CheckIn")
                        .HasColumnType("DATE");

                    b.Property<DateTime?>("CheckOut")
                        .HasColumnType("DATE");

                    b.Property<decimal?>("EmployeeId")
                        .HasColumnType("NUMBER")
                        .HasColumnName("Employee_Id");

                    b.Property<decimal?>("TotalHours")
                        .HasColumnType("NUMBER");

                    b.Property<bool>("isDelete")
                        .HasColumnType("NUMBER(1)");

                    b.HasKey("TimekeepingId");

                    b.HasIndex(new[] { "EmployeeId" }, "IX_Relationship7");

                    b.ToTable("Timekeeping", "K19");
                });

            modelBuilder.Entity("OracleWeb.Models.Employee", b =>
                {
                    b.HasOne("OracleWeb.Models.Positon", "Positon")
                        .WithMany("Employees")
                        .HasForeignKey("PositonId")
                        .HasConstraintName("has");

                    b.Navigation("Positon");
                });

            modelBuilder.Entity("OracleWeb.Models.PayRoll", b =>
                {
                    b.HasOne("OracleWeb.Models.Employee", "Employee")
                        .WithMany("PayRolls")
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("FK_Employee_Payroll");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("OracleWeb.Models.Timekeeping", b =>
                {
                    b.HasOne("OracleWeb.Models.Employee", "Employee")
                        .WithMany("Timekeepings")
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("FK_Employee_TimeKeeping");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("OracleWeb.Models.Employee", b =>
                {
                    b.Navigation("PayRolls");

                    b.Navigation("Timekeepings");
                });

            modelBuilder.Entity("OracleWeb.Models.Positon", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
