﻿// <auto-generated />
using System;
using GtrTrainingHr.web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GtrTrainingHr.web.Migrations
{
    [DbContext(typeof(GtrDbContext))]
    partial class GtrDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GtrTrainingHr.web.Models.Attendance", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AttStatus")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CompanyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("EmpId")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTime>("InTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OutTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dtDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("EmpId");

                    b.ToTable("attendances");
                });

            modelBuilder.Entity("GtrTrainingHr.web.Models.AttendanceSummary", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Absent")
                        .HasColumnType("int");

                    b.Property<string>("CompanyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("EmpId")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("Late")
                        .HasColumnType("int");

                    b.Property<int>("Present")
                        .HasColumnType("int");

                    b.Property<string>("SalaryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Weekend")
                        .HasColumnType("int");

                    b.Property<int>("dtMonth")
                        .HasColumnType("int");

                    b.Property<int>("dtYear")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("EmpId");

                    b.HasIndex("SalaryId");

                    b.ToTable("attendanceSummaries");
                });

            modelBuilder.Entity("GtrTrainingHr.web.Models.Company", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<double>("Basic")
                        .HasColumnType("float");

                    b.Property<string>("ComName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<double>("HRent")
                        .HasColumnType("float");

                    b.Property<bool>("IsInactive")
                        .HasColumnType("bit");

                    b.Property<double>("Medical")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("companies");
                });

            modelBuilder.Entity("GtrTrainingHr.web.Models.Department", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("CompanyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("DeptName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("GtrTrainingHr.web.Models.Designation", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("CompanyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("DesigName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("designations");
                });

            modelBuilder.Entity("GtrTrainingHr.web.Models.Employee", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<double>("Basic")
                        .HasColumnType("float");

                    b.Property<string>("CompanyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("DeptId")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("DesigId")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("EmpName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<double>("Gross")
                        .HasColumnType("float");

                    b.Property<double>("HRent")
                        .HasColumnType("float");

                    b.Property<double>("Medical")
                        .HasColumnType("float");

                    b.Property<double>("Others")
                        .HasColumnType("float");

                    b.Property<string>("ShiftId")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTime>("dtJoin")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("DeptId");

                    b.HasIndex("DesigId");

                    b.HasIndex("ShiftId");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("GtrTrainingHr.web.Models.Salary", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("AbsentAmount")
                        .HasColumnType("float");

                    b.Property<double>("Basic")
                        .HasColumnType("float");

                    b.Property<string>("CompanyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("EmpId")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<double>("Gross")
                        .HasColumnType("float");

                    b.Property<double>("HRent")
                        .HasColumnType("float");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<double>("Medical")
                        .HasColumnType("float");

                    b.Property<double>("PaidAmount")
                        .HasColumnType("float");

                    b.Property<double>("PayableAmount")
                        .HasColumnType("float");

                    b.Property<int>("dtMonth")
                        .HasColumnType("int");

                    b.Property<int>("dtYear")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("EmpId");

                    b.ToTable("salarys");
                });

            modelBuilder.Entity("GtrTrainingHr.web.Models.Shift", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("CompanyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTime>("ShiftIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ShiftLate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShiftName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ShiftOut")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("shifts");
                });

            modelBuilder.Entity("GtrTrainingHr.web.Models.Attendance", b =>
                {
                    b.HasOne("GtrTrainingHr.web.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GtrTrainingHr.web.Models.Employee", "Emp")
                        .WithMany()
                        .HasForeignKey("EmpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Emp");
                });

            modelBuilder.Entity("GtrTrainingHr.web.Models.AttendanceSummary", b =>
                {
                    b.HasOne("GtrTrainingHr.web.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GtrTrainingHr.web.Models.Employee", "Emp")
                        .WithMany()
                        .HasForeignKey("EmpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GtrTrainingHr.web.Models.Salary", "Salary")
                        .WithMany()
                        .HasForeignKey("SalaryId");

                    b.Navigation("Company");

                    b.Navigation("Emp");

                    b.Navigation("Salary");
                });

            modelBuilder.Entity("GtrTrainingHr.web.Models.Department", b =>
                {
                    b.HasOne("GtrTrainingHr.web.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("GtrTrainingHr.web.Models.Designation", b =>
                {
                    b.HasOne("GtrTrainingHr.web.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("GtrTrainingHr.web.Models.Employee", b =>
                {
                    b.HasOne("GtrTrainingHr.web.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GtrTrainingHr.web.Models.Department", "Dept")
                        .WithMany()
                        .HasForeignKey("DeptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GtrTrainingHr.web.Models.Designation", "Desig")
                        .WithMany()
                        .HasForeignKey("DesigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GtrTrainingHr.web.Models.Shift", "Shift")
                        .WithMany()
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Dept");

                    b.Navigation("Desig");

                    b.Navigation("Shift");
                });

            modelBuilder.Entity("GtrTrainingHr.web.Models.Salary", b =>
                {
                    b.HasOne("GtrTrainingHr.web.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GtrTrainingHr.web.Models.Employee", "Emp")
                        .WithMany()
                        .HasForeignKey("EmpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Emp");
                });

            modelBuilder.Entity("GtrTrainingHr.web.Models.Shift", b =>
                {
                    b.HasOne("GtrTrainingHr.web.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });
#pragma warning restore 612, 618
        }
    }
}
