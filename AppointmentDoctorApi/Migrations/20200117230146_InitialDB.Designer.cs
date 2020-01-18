﻿// <auto-generated />
using System;
using AppointmentDoctorApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppointmentDoctorApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200117230146_InitialDB")]
    partial class InitialDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AppointmentDoctorApi.Models.Appointment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("DateTimeReceipt");

                    b.Property<DateTime>("EditedAt");

                    b.Property<long>("Fk_Doctor");

                    b.Property<long>("Fk_Patient");

                    b.Property<bool>("Removed");

                    b.HasKey("Id");

                    b.HasIndex("Fk_Doctor");

                    b.HasIndex("Fk_Patient");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("AppointmentDoctorApi.Models.Doctor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Enum_Category");

                    b.Property<long>("Fk_PlaceOfWork");

                    b.Property<long>("Fk_Speciality");

                    b.Property<long>("Fk_User");

                    b.Property<int>("Rating");

                    b.HasKey("Id");

                    b.HasIndex("Fk_PlaceOfWork");

                    b.HasIndex("Fk_Speciality");

                    b.HasIndex("Fk_User");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("AppointmentDoctorApi.Models.Images", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<bool>("Removed");

                    b.Property<string>("Url")
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("AppointmentDoctorApi.Models.Patient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("Nvarchar(200)");

                    b.Property<long>("Fk_User");

                    b.HasKey("Id");

                    b.HasIndex("Fk_User");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("AppointmentDoctorApi.Models.PlaceOfWork", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NamePlace")
                        .HasColumnType("Nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("PlaceOfWork");
                });

            modelBuilder.Entity("AppointmentDoctorApi.Models.Speciality", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameSpeciality")
                        .HasColumnType("Nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Speciality");
                });

            modelBuilder.Entity("AppointmentDoctorApi.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("EditedAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Enum_Gender");

                    b.Property<int>("Enum_Role");

                    b.Property<long>("Fk_Photo");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("Nvarchar(100)");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(15)");

                    b.Property<bool>("Removed");

                    b.HasKey("Id");

                    b.HasIndex("Fk_Photo");

                    b.ToTable("User");
                });

            modelBuilder.Entity("AppointmentDoctorApi.Models.WorkSchedule", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Fk_Doctor");

                    b.Property<bool>("IsBusy");

                    b.Property<DateTime>("TimeReceipt");

                    b.HasKey("Id");

                    b.HasIndex("Fk_Doctor");

                    b.ToTable("WorkSchedule");
                });

            modelBuilder.Entity("AppointmentDoctorApi.Models.Appointment", b =>
                {
                    b.HasOne("AppointmentDoctorApi.Models.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("Fk_Doctor")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AppointmentDoctorApi.Models.Patient", "Patient")
                        .WithMany("MyAppointments")
                        .HasForeignKey("Fk_Patient")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("AppointmentDoctorApi.Models.Doctor", b =>
                {
                    b.HasOne("AppointmentDoctorApi.Models.PlaceOfWork", "PlaceOfWork")
                        .WithMany()
                        .HasForeignKey("Fk_PlaceOfWork")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AppointmentDoctorApi.Models.Speciality", "Speciality")
                        .WithMany()
                        .HasForeignKey("Fk_Speciality")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AppointmentDoctorApi.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Fk_User")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("AppointmentDoctorApi.Models.Patient", b =>
                {
                    b.HasOne("AppointmentDoctorApi.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Fk_User")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("AppointmentDoctorApi.Models.User", b =>
                {
                    b.HasOne("AppointmentDoctorApi.Models.Images", "Photo")
                        .WithMany()
                        .HasForeignKey("Fk_Photo")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("AppointmentDoctorApi.Models.WorkSchedule", b =>
                {
                    b.HasOne("AppointmentDoctorApi.Models.Doctor", "Doctor")
                        .WithMany("WorkSchedules")
                        .HasForeignKey("Fk_Doctor")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
