﻿// <auto-generated />
using System;
using LDInsurance.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LDInsurance.Migrations
{
    [DbContext(typeof(LDInsuranceContext))]
    [Migration("20210705044128_update3")]
    partial class update3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LDInsurance.Models.Account", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SSN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("LDInsurance.Models.Expense", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("InsuranceRegistrationID")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("InsuranceRegistrationID");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("LDInsurance.Models.Insurance", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("InsuranceTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Period")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int?>("VehicleTypeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("InsuranceTypeID");

                    b.HasIndex("VehicleTypeID");

                    b.ToTable("Insurances");
                });

            modelBuilder.Entity("LDInsurance.Models.InsuranceRegistration", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccountID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("InsuranceID")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int?>("VehicleID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.HasIndex("InsuranceID");

                    b.HasIndex("VehicleID");

                    b.ToTable("InsuranceRegistrations");
                });

            modelBuilder.Entity("LDInsurance.Models.InsuranceType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("InsuranceTypes");
                });

            modelBuilder.Entity("LDInsurance.Models.Report", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccountID")
                        .HasColumnType("int");

                    b.Property<int>("ClaimAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int?>("VehicleID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.HasIndex("VehicleID");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("LDInsurance.Models.Testimonial", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccountID")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.ToTable("Testimonials");
                });

            modelBuilder.Entity("LDInsurance.Models.Vehicle", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccountID")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("VehicleNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VehicleTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Version")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.HasIndex("VehicleTypeID");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("LDInsurance.Models.VehicleType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("VehicleTypes");
                });

            modelBuilder.Entity("LDInsurance.Models.Expense", b =>
                {
                    b.HasOne("LDInsurance.Models.InsuranceRegistration", "InsuranceRegistration")
                        .WithMany("Expenses")
                        .HasForeignKey("InsuranceRegistrationID");

                    b.Navigation("InsuranceRegistration");
                });

            modelBuilder.Entity("LDInsurance.Models.Insurance", b =>
                {
                    b.HasOne("LDInsurance.Models.InsuranceType", "InsuranceType")
                        .WithMany("Insurances")
                        .HasForeignKey("InsuranceTypeID");

                    b.HasOne("LDInsurance.Models.VehicleType", "VehicleType")
                        .WithMany("Insurances")
                        .HasForeignKey("VehicleTypeID");

                    b.Navigation("InsuranceType");

                    b.Navigation("VehicleType");
                });

            modelBuilder.Entity("LDInsurance.Models.InsuranceRegistration", b =>
                {
                    b.HasOne("LDInsurance.Models.Account", "Account")
                        .WithMany("InsuranceRegistrations")
                        .HasForeignKey("AccountID");

                    b.HasOne("LDInsurance.Models.Insurance", "Insurance")
                        .WithMany("InsuranceRegistrations")
                        .HasForeignKey("InsuranceID");

                    b.HasOne("LDInsurance.Models.Vehicle", "Vehicle")
                        .WithMany("InsuranceRegistrations")
                        .HasForeignKey("VehicleID");

                    b.Navigation("Account");

                    b.Navigation("Insurance");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("LDInsurance.Models.Report", b =>
                {
                    b.HasOne("LDInsurance.Models.Account", "Account")
                        .WithMany("Reports")
                        .HasForeignKey("AccountID");

                    b.HasOne("LDInsurance.Models.Vehicle", "Vehicle")
                        .WithMany("Reports")
                        .HasForeignKey("VehicleID");

                    b.Navigation("Account");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("LDInsurance.Models.Testimonial", b =>
                {
                    b.HasOne("LDInsurance.Models.Account", "Account")
                        .WithMany("Testimonials")
                        .HasForeignKey("AccountID");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("LDInsurance.Models.Vehicle", b =>
                {
                    b.HasOne("LDInsurance.Models.Account", "Account")
                        .WithMany("Vehicles")
                        .HasForeignKey("AccountID");

                    b.HasOne("LDInsurance.Models.VehicleType", "VehicleType")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleTypeID");

                    b.Navigation("Account");

                    b.Navigation("VehicleType");
                });

            modelBuilder.Entity("LDInsurance.Models.Account", b =>
                {
                    b.Navigation("InsuranceRegistrations");

                    b.Navigation("Reports");

                    b.Navigation("Testimonials");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("LDInsurance.Models.Insurance", b =>
                {
                    b.Navigation("InsuranceRegistrations");
                });

            modelBuilder.Entity("LDInsurance.Models.InsuranceRegistration", b =>
                {
                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("LDInsurance.Models.InsuranceType", b =>
                {
                    b.Navigation("Insurances");
                });

            modelBuilder.Entity("LDInsurance.Models.Vehicle", b =>
                {
                    b.Navigation("InsuranceRegistrations");

                    b.Navigation("Reports");
                });

            modelBuilder.Entity("LDInsurance.Models.VehicleType", b =>
                {
                    b.Navigation("Insurances");

                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
