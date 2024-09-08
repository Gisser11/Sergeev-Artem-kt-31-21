﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Sol.Domain;

#nullable disable

namespace Sol.Domain.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240908132233_final changes (ihope)")]
    partial class finalchangesihope
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Sol.Domain.Entity.AcademicGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Specialty")
                        .HasColumnType("boolean");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("AcademicGroup");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "kt-41-21",
                            Specialty = false,
                            Year = 2021
                        },
                        new
                        {
                            Id = 2,
                            Name = "kt-51-21",
                            Specialty = true,
                            Year = 2021
                        },
                        new
                        {
                            Id = 3,
                            Name = "kt-55-21",
                            Specialty = true,
                            Year = 2021
                        },
                        new
                        {
                            Id = 4,
                            Name = "kt-41-22",
                            Specialty = false,
                            Year = 2022
                        },
                        new
                        {
                            Id = 5,
                            Name = "kt-41-22",
                            Specialty = true,
                            Year = 2022
                        });
                });

            modelBuilder.Entity("Sol.Domain.Entity.Discipline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Specialty")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Discipline");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Матеша1",
                            Specialty = true
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Матеша2",
                            Specialty = true
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Name = "Матеша3",
                            Specialty = true
                        });
                });

            modelBuilder.Entity("Sol.Domain.Entity.ManyToMany.AcademicGroupAndDisciplines", b =>
                {
                    b.Property<int>("AcademicGroupId")
                        .HasColumnType("integer");

                    b.Property<int>("DisciplineId")
                        .HasColumnType("integer");

                    b.HasKey("AcademicGroupId", "DisciplineId");

                    b.HasIndex("DisciplineId");

                    b.ToTable("AcademicGroupAndDisciplines");

                    b.HasData(
                        new
                        {
                            AcademicGroupId = 1,
                            DisciplineId = 1
                        },
                        new
                        {
                            AcademicGroupId = 1,
                            DisciplineId = 2
                        },
                        new
                        {
                            AcademicGroupId = 2,
                            DisciplineId = 3
                        },
                        new
                        {
                            AcademicGroupId = 2,
                            DisciplineId = 1
                        },
                        new
                        {
                            AcademicGroupId = 3,
                            DisciplineId = 1
                        },
                        new
                        {
                            AcademicGroupId = 3,
                            DisciplineId = 2
                        });
                });

            modelBuilder.Entity("Sol.Domain.Entity.PerformanceBool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DisciplineId")
                        .HasColumnType("integer");

                    b.Property<bool>("Result")
                        .HasColumnType("boolean");

                    b.Property<int>("StudentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DisciplineId");

                    b.HasIndex("StudentId");

                    b.ToTable("PerformanceBool");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisciplineId = 1,
                            Result = true,
                            StudentId = 1
                        },
                        new
                        {
                            Id = 2,
                            DisciplineId = 2,
                            Result = false,
                            StudentId = 1
                        },
                        new
                        {
                            Id = 3,
                            DisciplineId = 3,
                            Result = true,
                            StudentId = 1
                        },
                        new
                        {
                            Id = 4,
                            DisciplineId = 3,
                            Result = true,
                            StudentId = 2
                        },
                        new
                        {
                            Id = 5,
                            DisciplineId = 3,
                            Result = true,
                            StudentId = 3
                        },
                        new
                        {
                            Id = 6,
                            DisciplineId = 3,
                            Result = true,
                            StudentId = 4
                        },
                        new
                        {
                            Id = 7,
                            DisciplineId = 1,
                            Result = false,
                            StudentId = 4
                        });
                });

            modelBuilder.Entity("Sol.Domain.Entity.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AcademicGroupId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ThirdName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AcademicGroupId");

                    b.ToTable("Student");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AcademicGroupId = 1,
                            IsDeleted = false,
                            Name = "Iskakov",
                            Surname = "",
                            ThirdName = ""
                        },
                        new
                        {
                            Id = 2,
                            AcademicGroupId = 1,
                            IsDeleted = true,
                            Name = "Ivlev",
                            Surname = "",
                            ThirdName = ""
                        },
                        new
                        {
                            Id = 3,
                            AcademicGroupId = 1,
                            IsDeleted = true,
                            Name = "Ileeeva",
                            Surname = "",
                            ThirdName = ""
                        },
                        new
                        {
                            Id = 4,
                            AcademicGroupId = 2,
                            IsDeleted = false,
                            Name = "Stolov",
                            Surname = "",
                            ThirdName = ""
                        },
                        new
                        {
                            Id = 5,
                            AcademicGroupId = 2,
                            IsDeleted = false,
                            Name = "Krovatov",
                            Surname = "",
                            ThirdName = ""
                        });
                });

            modelBuilder.Entity("Sol.Domain.Entity.ManyToMany.AcademicGroupAndDisciplines", b =>
                {
                    b.HasOne("Sol.Domain.Entity.AcademicGroup", null)
                        .WithMany()
                        .HasForeignKey("AcademicGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sol.Domain.Entity.Discipline", null)
                        .WithMany()
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sol.Domain.Entity.PerformanceBool", b =>
                {
                    b.HasOne("Sol.Domain.Entity.Discipline", "Discipline")
                        .WithMany("PerformanceBools")
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sol.Domain.Entity.Student", "Student")
                        .WithMany("PerformanceBools")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Discipline");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Sol.Domain.Entity.Student", b =>
                {
                    b.HasOne("Sol.Domain.Entity.AcademicGroup", "AcademicGroup")
                        .WithMany("Students")
                        .HasForeignKey("AcademicGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AcademicGroup");
                });

            modelBuilder.Entity("Sol.Domain.Entity.AcademicGroup", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Sol.Domain.Entity.Discipline", b =>
                {
                    b.Navigation("PerformanceBools");
                });

            modelBuilder.Entity("Sol.Domain.Entity.Student", b =>
                {
                    b.Navigation("PerformanceBools");
                });
#pragma warning restore 612, 618
        }
    }
}
