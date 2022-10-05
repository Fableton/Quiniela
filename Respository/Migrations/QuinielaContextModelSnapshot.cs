﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Respository;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(QuinielaContext))]
    partial class QuinielaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Auths.Activity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Activities", "Security");

                    b.HasData(
                        new
                        {
                            Id = "UpdateQuiniela",
                            Description = "Update Quiniela matches"
                        },
                        new
                        {
                            Id = "Index",
                            Description = "Watch Index"
                        },
                        new
                        {
                            Id = "UpdateMatches",
                            Description = "Update matches"
                        },
                        new
                        {
                            Id = "ViewAdminUsers",
                            Description = "View List of Users"
                        },
                        new
                        {
                            Id = "AddAdminUsers",
                            Description = "Add new players"
                        },
                        new
                        {
                            Id = "GenerateLinkAdminUsers",
                            Description = "Generate acces token to user"
                        });
                });

            modelBuilder.Entity("Entities.Auths.Rol", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRoot")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Rols", "Security");

                    b.HasData(
                        new
                        {
                            Id = "Admin",
                            Description = "Root admin",
                            IsRoot = true
                        },
                        new
                        {
                            Id = "Player",
                            Description = "Single PLayer",
                            IsRoot = false
                        });
                });

            modelBuilder.Entity("Entities.MatchGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("CanDraw")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocalGoals")
                        .HasColumnType("int");

                    b.Property<string>("LocalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("QuinielaId")
                        .HasColumnType("int");

                    b.Property<int>("VisitorGoals")
                        .HasColumnType("int");

                    b.Property<string>("VisitorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("LocalId");

                    b.HasIndex("QuinielaId");

                    b.HasIndex("VisitorId");

                    b.ToTable("MatchGames", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CanDraw = true,
                            Date = new DateTime(2022, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Group = "A",
                            LocalGoals = 0,
                            LocalId = "QAT",
                            QuinielaId = 1,
                            VisitorGoals = 0,
                            VisitorId = "ECU"
                        },
                        new
                        {
                            Id = 2,
                            CanDraw = true,
                            Date = new DateTime(2022, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Group = "A",
                            LocalGoals = 0,
                            LocalId = "SEN",
                            QuinielaId = 1,
                            VisitorGoals = 0,
                            VisitorId = "NED"
                        },
                        new
                        {
                            Id = 3,
                            CanDraw = true,
                            Date = new DateTime(2022, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Group = "B",
                            LocalGoals = 0,
                            LocalId = "ENG",
                            QuinielaId = 1,
                            VisitorGoals = 0,
                            VisitorId = "IRN"
                        },
                        new
                        {
                            Id = 4,
                            CanDraw = true,
                            Date = new DateTime(2022, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Group = "B",
                            LocalGoals = 0,
                            LocalId = "USA",
                            QuinielaId = 1,
                            VisitorGoals = 0,
                            VisitorId = "WAL"
                        },
                        new
                        {
                            Id = 5,
                            CanDraw = true,
                            Date = new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Group = "C",
                            LocalGoals = 0,
                            LocalId = "ARG",
                            QuinielaId = 1,
                            VisitorGoals = 0,
                            VisitorId = "KSA"
                        },
                        new
                        {
                            Id = 6,
                            CanDraw = true,
                            Date = new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Group = "C",
                            LocalGoals = 0,
                            LocalId = "MEX",
                            QuinielaId = 1,
                            VisitorGoals = 0,
                            VisitorId = "POL"
                        },
                        new
                        {
                            Id = 7,
                            CanDraw = true,
                            Date = new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Group = "D",
                            LocalGoals = 0,
                            LocalId = "DEN",
                            QuinielaId = 1,
                            VisitorGoals = 0,
                            VisitorId = "TUN"
                        },
                        new
                        {
                            Id = 8,
                            CanDraw = true,
                            Date = new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Group = "D",
                            LocalGoals = 0,
                            LocalId = "FRA",
                            QuinielaId = 1,
                            VisitorGoals = 0,
                            VisitorId = "AUS"
                        },
                        new
                        {
                            Id = 9,
                            CanDraw = true,
                            Date = new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Group = "E",
                            LocalGoals = 0,
                            LocalId = "ESP",
                            QuinielaId = 1,
                            VisitorGoals = 0,
                            VisitorId = "CRC"
                        },
                        new
                        {
                            Id = 10,
                            CanDraw = true,
                            Date = new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Group = "E",
                            LocalGoals = 0,
                            LocalId = "GER",
                            QuinielaId = 1,
                            VisitorGoals = 0,
                            VisitorId = "JPN"
                        },
                        new
                        {
                            Id = 11,
                            CanDraw = true,
                            Date = new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Group = "F",
                            LocalGoals = 0,
                            LocalId = "BEL",
                            QuinielaId = 1,
                            VisitorGoals = 0,
                            VisitorId = "CAN"
                        },
                        new
                        {
                            Id = 12,
                            CanDraw = true,
                            Date = new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Group = "F",
                            LocalGoals = 0,
                            LocalId = "MAR",
                            QuinielaId = 1,
                            VisitorGoals = 0,
                            VisitorId = "CRO"
                        },
                        new
                        {
                            Id = 13,
                            CanDraw = true,
                            Date = new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Group = "G",
                            LocalGoals = 0,
                            LocalId = "SUI",
                            QuinielaId = 1,
                            VisitorGoals = 0,
                            VisitorId = "CMR"
                        },
                        new
                        {
                            Id = 14,
                            CanDraw = true,
                            Date = new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Group = "G",
                            LocalGoals = 0,
                            LocalId = "BRA",
                            QuinielaId = 1,
                            VisitorGoals = 0,
                            VisitorId = "SRB"
                        },
                        new
                        {
                            Id = 15,
                            CanDraw = true,
                            Date = new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Group = "H",
                            LocalGoals = 0,
                            LocalId = "POR",
                            QuinielaId = 1,
                            VisitorGoals = 0,
                            VisitorId = "GHA"
                        },
                        new
                        {
                            Id = 16,
                            CanDraw = true,
                            Date = new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Group = "H",
                            LocalGoals = 0,
                            LocalId = "URU",
                            QuinielaId = 1,
                            VisitorGoals = 0,
                            VisitorId = "KOR"
                        });
                });

            modelBuilder.Entity("Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Players", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "ftrejo"
                        });
                });

            modelBuilder.Entity("Entities.PlayerMatchResult", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("MatchGameId")
                        .HasColumnType("int");

                    b.Property<int>("Result")
                        .HasColumnType("int");

                    b.HasKey("PlayerId", "MatchGameId");

                    b.HasIndex("MatchGameId");

                    b.ToTable("PlayerMatchResult", (string)null);
                });

            modelBuilder.Entity("Entities.Quiniela", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.ToTable("Quinielas", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndDate = new DateTime(2022, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Jornada 1",
                            StartDate = new DateTime(2022, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TournamentId = 1
                        },
                        new
                        {
                            Id = 2,
                            EndDate = new DateTime(2022, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Jornada 2",
                            StartDate = new DateTime(2022, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TournamentId = 1
                        },
                        new
                        {
                            Id = 3,
                            EndDate = new DateTime(2022, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Jornada 3",
                            StartDate = new DateTime(2022, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TournamentId = 1
                        });
                });

            modelBuilder.Entity("Entities.Team", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "QAT",
                            Name = "Catar"
                        },
                        new
                        {
                            Id = "SEN",
                            Name = "Senegal"
                        },
                        new
                        {
                            Id = "ECU",
                            Name = "Ecuador"
                        },
                        new
                        {
                            Id = "NED",
                            Name = "Paises Bajos"
                        },
                        new
                        {
                            Id = "ENG",
                            Name = "Inglaterra"
                        },
                        new
                        {
                            Id = "USA",
                            Name = "Estados Unidos"
                        },
                        new
                        {
                            Id = "IRN",
                            Name = "Iran"
                        },
                        new
                        {
                            Id = "WAL",
                            Name = "Gales"
                        },
                        new
                        {
                            Id = "ARG",
                            Name = "Argentina"
                        },
                        new
                        {
                            Id = "MEX",
                            Name = "Mexico"
                        },
                        new
                        {
                            Id = "KSA",
                            Name = "Arabia Saudita"
                        },
                        new
                        {
                            Id = "POL",
                            Name = "Polonia"
                        },
                        new
                        {
                            Id = "DEN",
                            Name = "Dinamarca"
                        },
                        new
                        {
                            Id = "FRA",
                            Name = "Francia"
                        },
                        new
                        {
                            Id = "TUN",
                            Name = "Tunez"
                        },
                        new
                        {
                            Id = "AUS",
                            Name = "Australia"
                        },
                        new
                        {
                            Id = "ESP",
                            Name = "España"
                        },
                        new
                        {
                            Id = "GER",
                            Name = "Alemania"
                        },
                        new
                        {
                            Id = "CRC",
                            Name = "CostaRica"
                        },
                        new
                        {
                            Id = "JPN",
                            Name = "Japon"
                        },
                        new
                        {
                            Id = "BEL",
                            Name = "Belgica"
                        },
                        new
                        {
                            Id = "MAR",
                            Name = "Marruecos"
                        },
                        new
                        {
                            Id = "CAN",
                            Name = "Canada"
                        },
                        new
                        {
                            Id = "CRO",
                            Name = "Croacia"
                        },
                        new
                        {
                            Id = "SUI",
                            Name = "Suiza"
                        },
                        new
                        {
                            Id = "BRA",
                            Name = "Brasil"
                        },
                        new
                        {
                            Id = "CMR",
                            Name = "Camerun"
                        },
                        new
                        {
                            Id = "SRB",
                            Name = "Serbia"
                        },
                        new
                        {
                            Id = "POR",
                            Name = "Portugal"
                        },
                        new
                        {
                            Id = "URU",
                            Name = "Uruguay"
                        },
                        new
                        {
                            Id = "GHA",
                            Name = "Ghana"
                        },
                        new
                        {
                            Id = "KOR",
                            Name = "Corea del Sur"
                        });
                });

            modelBuilder.Entity("Entities.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tournaments", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Qatar 2022"
                        });
                });

            modelBuilder.Entity("PlayersRols", b =>
                {
                    b.Property<string>("RolId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("RolId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayersRols", "Security");

                    b.HasData(
                        new
                        {
                            RolId = "Admin",
                            PlayerId = 1
                        });
                });

            modelBuilder.Entity("RolsActivity", b =>
                {
                    b.Property<string>("RolId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ActivityId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RolId", "ActivityId");

                    b.HasIndex("ActivityId");

                    b.ToTable("RolsActivity", "Security");

                    b.HasData(
                        new
                        {
                            RolId = "Admin",
                            ActivityId = "UpdateQuiniela"
                        },
                        new
                        {
                            RolId = "Admin",
                            ActivityId = "Index"
                        },
                        new
                        {
                            RolId = "Admin",
                            ActivityId = "UpdateMatches"
                        },
                        new
                        {
                            RolId = "Admin",
                            ActivityId = "ViewAdminUsers"
                        },
                        new
                        {
                            RolId = "Admin",
                            ActivityId = "AddAdminUsers"
                        },
                        new
                        {
                            RolId = "Admin",
                            ActivityId = "GenerateLinkAdminUsers"
                        },
                        new
                        {
                            RolId = "Player",
                            ActivityId = "UpdateQuiniela"
                        });
                });

            modelBuilder.Entity("Entities.MatchGame", b =>
                {
                    b.HasOne("Entities.Team", "Local")
                        .WithMany("LocalGames")
                        .HasForeignKey("LocalId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Entities.Quiniela", "Quiniela")
                        .WithMany("Matches")
                        .HasForeignKey("QuinielaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Entities.Team", "Visitor")
                        .WithMany("VisitorsGames")
                        .HasForeignKey("VisitorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Local");

                    b.Navigation("Quiniela");

                    b.Navigation("Visitor");
                });

            modelBuilder.Entity("Entities.PlayerMatchResult", b =>
                {
                    b.HasOne("Entities.MatchGame", "MatchGame")
                        .WithMany("MatchResults")
                        .HasForeignKey("MatchGameId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Entities.Player", "Player")
                        .WithMany("MatchResults")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("MatchGame");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Entities.Quiniela", b =>
                {
                    b.HasOne("Entities.Tournament", "Tournament")
                        .WithMany("Quinielas")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("PlayersRols", b =>
                {
                    b.HasOne("Entities.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Auths.Rol", null)
                        .WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RolsActivity", b =>
                {
                    b.HasOne("Entities.Auths.Activity", null)
                        .WithMany()
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Auths.Rol", null)
                        .WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.MatchGame", b =>
                {
                    b.Navigation("MatchResults");
                });

            modelBuilder.Entity("Entities.Player", b =>
                {
                    b.Navigation("MatchResults");
                });

            modelBuilder.Entity("Entities.Quiniela", b =>
                {
                    b.Navigation("Matches");
                });

            modelBuilder.Entity("Entities.Team", b =>
                {
                    b.Navigation("LocalGames");

                    b.Navigation("VisitorsGames");
                });

            modelBuilder.Entity("Entities.Tournament", b =>
                {
                    b.Navigation("Quinielas");
                });
#pragma warning restore 612, 618
        }
    }
}
