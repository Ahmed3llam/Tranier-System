﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tranier_System.Models;

#nullable disable

namespace Tranier_System.Migrations
{
    [DbContext(typeof(TContext))]
    [Migration("20240229101035_v1")]
    partial class v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tranier_System.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Degree")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("MinDegree")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("course");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Degree = 100,
                            DepartmentId = 2,
                            MinDegree = 60,
                            Name = "JS"
                        },
                        new
                        {
                            Id = 2,
                            Degree = 100,
                            DepartmentId = 1,
                            MinDegree = 60,
                            Name = "Mvc"
                        });
                });

            modelBuilder.Entity("Tranier_System.Models.CrsResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("Degree")
                        .HasColumnType("int");

                    b.Property<int>("TranieeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("TranieeId");

                    b.ToTable("CrsResult");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 2,
                            Degree = 80,
                            TranieeId = 1
                        },
                        new
                        {
                            Id = 2,
                            CourseId = 1,
                            Degree = 90,
                            TranieeId = 2
                        });
                });

            modelBuilder.Entity("Tranier_System.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Manager")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Department");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Manager = "Ahmed",
                            Name = "SD"
                        },
                        new
                        {
                            Id = 2,
                            Manager = "Loai",
                            Name = "OS"
                        });
                });

            modelBuilder.Entity("Tranier_System.Models.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Instructor");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Giza",
                            CourseId = 2,
                            DepartmentId = 1,
                            Image = "2.png",
                            Name = "Islam",
                            Salary = 6543.6499999999996
                        },
                        new
                        {
                            Id = 2,
                            Address = "Tanta",
                            CourseId = 1,
                            DepartmentId = 2,
                            Image = "1.png",
                            Name = "Ali",
                            Salary = 9543.0
                        });
                });

            modelBuilder.Entity("Tranier_System.Models.Trainee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Degree")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Trainee");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Menouf",
                            Degree = 3,
                            DepartmentId = 1,
                            Image = "1.png",
                            Name = "Khalid"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Cairo",
                            Degree = 4,
                            DepartmentId = 2,
                            Image = "2.png",
                            Name = "Moaz"
                        });
                });

            modelBuilder.Entity("Tranier_System.Models.Course", b =>
                {
                    b.HasOne("Tranier_System.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Tranier_System.Models.CrsResult", b =>
                {
                    b.HasOne("Tranier_System.Models.Course", "Course")
                        .WithMany("CrsResult")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tranier_System.Models.Trainee", "Trainee")
                        .WithMany("CrsResult")
                        .HasForeignKey("TranieeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("Tranier_System.Models.Instructor", b =>
                {
                    b.HasOne("Tranier_System.Models.Course", "Course")
                        .WithMany("Instructors")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tranier_System.Models.Department", "Department")
                        .WithMany("Instructors")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Tranier_System.Models.Trainee", b =>
                {
                    b.HasOne("Tranier_System.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Tranier_System.Models.Course", b =>
                {
                    b.Navigation("CrsResult");

                    b.Navigation("Instructors");
                });

            modelBuilder.Entity("Tranier_System.Models.Department", b =>
                {
                    b.Navigation("Instructors");
                });

            modelBuilder.Entity("Tranier_System.Models.Trainee", b =>
                {
                    b.Navigation("CrsResult");
                });
#pragma warning restore 612, 618
        }
    }
}
