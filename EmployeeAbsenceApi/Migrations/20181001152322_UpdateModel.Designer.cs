﻿// <auto-generated />
using System;
using HRSystemApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeAbsenceApi.Migrations
{
    [DbContext(typeof(HRSystemContext))]
    [Migration("20181001152322_UpdateModel")]
    partial class UpdateModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065");

            modelBuilder.Entity("EmployeeAttendanceApi.Models.AnnualLeavePermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApprovedBy");

                    b.Property<DateTime>("ApprovedDate");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<DateTime>("End");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("MealReimbursement");

                    b.Property<string>("Name");

                    b.Property<DateTime>("Start");

                    b.Property<string>("Status");

                    b.Property<int>("StatusCode");

                    b.Property<int>("TotalDays");

                    b.Property<int>("TransportReimbursement");

                    b.Property<string>("Type");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("AnnualLeavePermissions");
                });

            modelBuilder.Entity("EmployeeAttendanceApi.Models.AnnualLeaveUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("CurrentAnnualLeave");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("TotalAnnualLeave");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AnnualLeaveUser");
                });

            modelBuilder.Entity("EmployeeAttendanceApi.Models.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Status");

                    b.Property<int>("StatusCode");

                    b.Property<DateTime>("TimeIn");

                    b.Property<DateTime?>("TimeOut");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<string>("UserCode")
                        .IsRequired();

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("EmployeeAttendanceApi.Models.OverTimePermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApprovedBy");

                    b.Property<DateTime>("ApprovedDate");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<DateTime>("End");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("MealReimbursement");

                    b.Property<string>("Name");

                    b.Property<DateTime>("Start");

                    b.Property<string>("Status");

                    b.Property<int>("StatusCode");

                    b.Property<int>("TransportReimbursement");

                    b.Property<string>("Type");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("OverTimePermissions");
                });

            modelBuilder.Entity("EmployeeAttendanceApi.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("EmployeeAttendanceApi.Models.SickLeavePermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApprovedBy");

                    b.Property<DateTime>("ApprovedDate");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<DateTime>("End");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<string>("ProofOfSickness");

                    b.Property<DateTime>("Start");

                    b.Property<string>("Status");

                    b.Property<int>("StatusCode");

                    b.Property<string>("Type");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("SickLeavePermissions");
                });

            modelBuilder.Entity("EmployeeAttendanceApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email");

                    b.Property<string>("FullName");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EmployeeAttendanceApi.Models.UserRole", b =>
                {
                    b.Property<int>("RoleId");

                    b.Property<int>("UserId");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("EmployeeAttendanceApi.Models.AnnualLeaveUser", b =>
                {
                    b.HasOne("EmployeeAttendanceApi.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("EmployeeAttendanceApi.Models.Attendance", b =>
                {
                    b.HasOne("EmployeeAttendanceApi.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("EmployeeAttendanceApi.Models.UserRole", b =>
                {
                    b.HasOne("EmployeeAttendanceApi.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EmployeeAttendanceApi.Models.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
