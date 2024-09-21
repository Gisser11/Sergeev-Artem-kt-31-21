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
    [Migration("20240921090333_tried again")]
    partial class triedagain
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
                        .HasColumnType("integer")
                        .HasColumnName("pk_cd_AcademicGroup_academic_group_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("c_name")
                        .HasComment("Имя студента");

                    b.Property<int>("Specialty")
                        .HasColumnType("integer")
                        .HasColumnName("n_specialty");

                    b.Property<int>("Year")
                        .HasColumnType("integer")
                        .HasColumnName("n_year");

                    b.HasKey("Id");

                    b.ToTable("AcademicGroup");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "kt-41-21",
                            Specialty = 1,
                            Year = 2021
                        },
                        new
                        {
                            Id = 2,
                            Name = "kt-51-21",
                            Specialty = 1,
                            Year = 2021
                        },
                        new
                        {
                            Id = 3,
                            Name = "kt-55-21",
                            Specialty = 2,
                            Year = 2021
                        },
                        new
                        {
                            Id = 4,
                            Name = "kt-41-22",
                            Specialty = 2,
                            Year = 2022
                        },
                        new
                        {
                            Id = 5,
                            Name = "kt-41-22",
                            Specialty = 1,
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
                        .HasColumnType("bool")
                        .HasColumnName("b_deleted")
                        .HasComment("Существует ли студент");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_name")
                        .HasComment("Имя студента");

                    b.Property<int>("Specialty")
                        .HasColumnType("int4")
                        .HasColumnName("n_speciality")
                        .HasComment("Специальность студента");

                    b.HasKey("Id")
                        .HasName("pk_cd_discipline_discipline_id");

                    b.ToTable("Discipline");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Матеша1",
                            Specialty = 1
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Матеша2",
                            Specialty = 2
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Name = "Матеша3",
                            Specialty = 3
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

            modelBuilder.Entity("Sol.Domain.Entity.PerfomanceMark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DisciplineId")
                        .HasColumnType("int4")
                        .HasColumnName("fk_cd_perfomance_marks_discipline_id")
                        .HasComment("вторичный ключ");

                    b.Property<int>("Result")
                        .HasColumnType("int4")
                        .HasColumnName("n_result")
                        .HasComment("Первичный ключ");

                    b.Property<int>("StudentId")
                        .HasColumnType("int4")
                        .HasColumnName("fk_cd_perfomance_marks_student_id")
                        .HasComment("вторичный ключ");

                    b.HasKey("Id")
                        .HasName("cd_cd_perfomance_marks_perf_marks_id");

                    b.HasIndex(new[] { "DisciplineId" }, "fk_discipline_id");

                    b.HasIndex(new[] { "StudentId" }, "fk_student_id");

                    b.ToTable("PerfomanceMark");
                });

            modelBuilder.Entity("Sol.Domain.Entity.PerformanceBool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int4")
                        .HasComment("Первичный ключ");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DisciplineId")
                        .HasColumnType("int4")
                        .HasComment("вторичный ключ");

                    b.Property<bool>("Result")
                        .HasColumnType("bool")
                        .HasColumnName("b_result")
                        .HasComment("Первичный ключ");

                    b.Property<int>("StudentId")
                        .HasColumnType("int4")
                        .HasComment("вторичный ключ");

                    b.HasKey("Id")
                        .HasName("pk_cd_perfomance_bools_perf_bools_id");

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
                        .HasColumnType("integer")
                        .HasColumnName("pk_cd_Student_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AcademicGroupId")
                        .HasColumnType("int4")
                        .HasColumnName("i_academic_group")
                        .HasComment("группа студента");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bool")
                        .HasColumnName("b_deleted")
                        .HasComment("существует ли студента");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("c_name")
                        .HasComment("Имя студента");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("с_surname")
                        .HasComment("Фамилия студента");

                    b.Property<string>("ThirdName")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("c_thirdname")
                        .HasComment("Фамилия студента");

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

            modelBuilder.Entity("Sol.Domain.Entity.PerfomanceMark", b =>
                {
                    b.HasOne("Sol.Domain.Entity.Discipline", "Discipline")
                        .WithMany("PerformanceMarks")
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_discipline_id");

                    b.HasOne("Sol.Domain.Entity.Student", "Student")
                        .WithMany("PerfomanceMarks")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_student_id");

                    b.Navigation("Discipline");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Sol.Domain.Entity.PerformanceBool", b =>
                {
                    b.HasOne("Sol.Domain.Entity.Discipline", "Discipline")
                        .WithMany("PerformanceBools")
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_discipline_id");

                    b.HasOne("Sol.Domain.Entity.Student", "Student")
                        .WithMany("PerformanceBools")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_student_id");

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

                    b.Navigation("PerformanceMarks");
                });

            modelBuilder.Entity("Sol.Domain.Entity.Student", b =>
                {
                    b.Navigation("PerfomanceMarks");

                    b.Navigation("PerformanceBools");
                });
#pragma warning restore 612, 618
        }
    }
}
