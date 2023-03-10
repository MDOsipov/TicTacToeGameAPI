﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace TicTacToeGameWebService.Migrations
{
    [DbContext(typeof(TicTacToeGameContext))]
    [Migration("20230308103331_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("create_date");

                    b.Property<int>("CrossesPlayerId")
                        .HasColumnType("int")
                        .HasColumnName("crosses_player_id");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime")
                        .HasColumnName("end_time");

                    b.Property<int>("GameStatusId")
                        .HasColumnType("int")
                        .HasColumnName("game_status_id");

                    b.Property<int>("NoughtsPlayerId")
                        .HasColumnType("int")
                        .HasColumnName("noughts_player_id");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("datetime")
                        .HasColumnName("start_time");

                    b.Property<int>("StatusId")
                        .HasColumnType("int")
                        .HasColumnName("status_id");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("update_date");

                    b.Property<int?>("WinnerPlayerId")
                        .HasColumnType("int")
                        .HasColumnName("winner_player_id");

                    b.HasKey("Id");

                    b.HasIndex("CrossesPlayerId");

                    b.HasIndex("GameStatusId");

                    b.HasIndex("NoughtsPlayerId");

                    b.HasIndex("StatusId");

                    b.HasIndex("WinnerPlayerId");

                    b.ToTable("game", (string)null);
                });

            modelBuilder.Entity("Entities.Models.GameSide", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("create_date");

                    b.Property<string>("SideName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("side_name");

                    b.Property<int>("StatusId")
                        .HasColumnType("int")
                        .HasColumnName("status_id");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("update_date");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("game_side", (string)null);
                });

            modelBuilder.Entity("Entities.Models.GameStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("create_date");

                    b.Property<string>("GameStatusName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("game_status_name");

                    b.Property<int>("StatusId")
                        .HasColumnType("int")
                        .HasColumnName("status_id");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("update_date");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("game_status", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2023, 3, 8, 13, 33, 31, 470, DateTimeKind.Local).AddTicks(3137),
                            GameStatusName = "Running",
                            StatusId = 1,
                            UpdateDate = new DateTime(2023, 3, 8, 13, 33, 31, 470, DateTimeKind.Local).AddTicks(3148)
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2023, 3, 8, 13, 33, 31, 470, DateTimeKind.Local).AddTicks(3150),
                            GameStatusName = "Finished",
                            StatusId = 1,
                            UpdateDate = new DateTime(2023, 3, 8, 13, 33, 31, 470, DateTimeKind.Local).AddTicks(3151)
                        });
                });

            modelBuilder.Entity("Entities.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("create_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.Property<int>("StatusId")
                        .HasColumnType("int")
                        .HasColumnName("status_id");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("update_date");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("player", (string)null);
                });

            modelBuilder.Entity("Entities.Models.Point", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("create_date");

                    b.Property<int>("GameId")
                        .HasColumnType("int")
                        .HasColumnName("game_id");

                    b.Property<int>("GameSideId")
                        .HasColumnType("int")
                        .HasColumnName("game_side_id");

                    b.Property<int>("StatusId")
                        .HasColumnType("int")
                        .HasColumnName("status_id");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("update_date");

                    b.Property<int>("XValue")
                        .HasColumnType("int")
                        .HasColumnName("x_value");

                    b.Property<int>("YValue")
                        .HasColumnType("int")
                        .HasColumnName("y_value");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("GameSideId");

                    b.HasIndex("StatusId");

                    b.ToTable("point", (string)null);
                });

            modelBuilder.Entity("Entities.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("create_date");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("status_name");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("update_date");

                    b.HasKey("Id");

                    b.ToTable("status", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2023, 3, 8, 13, 33, 31, 471, DateTimeKind.Local).AddTicks(2369),
                            StatusName = "Active",
                            UpdateDate = new DateTime(2023, 3, 8, 13, 33, 31, 471, DateTimeKind.Local).AddTicks(2374)
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2023, 3, 8, 13, 33, 31, 471, DateTimeKind.Local).AddTicks(2376),
                            StatusName = "Not active",
                            UpdateDate = new DateTime(2023, 3, 8, 13, 33, 31, 471, DateTimeKind.Local).AddTicks(2377)
                        });
                });

            modelBuilder.Entity("Entities.Models.Game", b =>
                {
                    b.HasOne("Entities.Models.Player", "CrossesPlayer")
                        .WithMany("GameCrossesPlayers")
                        .HasForeignKey("CrossesPlayerId")
                        .IsRequired()
                        .HasConstraintName("FK_game_player");

                    b.HasOne("Entities.Models.GameStatus", "GameStatus")
                        .WithMany("Games")
                        .HasForeignKey("GameStatusId")
                        .IsRequired()
                        .HasConstraintName("FK_game_game_status");

                    b.HasOne("Entities.Models.Player", "NoughtsPlayer")
                        .WithMany("GameNoughtsPlayers")
                        .HasForeignKey("NoughtsPlayerId")
                        .IsRequired()
                        .HasConstraintName("FK_game_player1");

                    b.HasOne("Entities.Models.Status", "Status")
                        .WithMany("Games")
                        .HasForeignKey("StatusId")
                        .IsRequired()
                        .HasConstraintName("FK_game_status");

                    b.HasOne("Entities.Models.Player", "WinnerPlayer")
                        .WithMany("GameWinnerPlayers")
                        .HasForeignKey("WinnerPlayerId")
                        .HasConstraintName("FK_game_player2");

                    b.Navigation("CrossesPlayer");

                    b.Navigation("GameStatus");

                    b.Navigation("NoughtsPlayer");

                    b.Navigation("Status");

                    b.Navigation("WinnerPlayer");
                });

            modelBuilder.Entity("Entities.Models.GameSide", b =>
                {
                    b.HasOne("Entities.Models.Status", "Status")
                        .WithMany("GameSides")
                        .HasForeignKey("StatusId")
                        .IsRequired()
                        .HasConstraintName("FK_game_side_status");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Entities.Models.GameStatus", b =>
                {
                    b.HasOne("Entities.Models.Status", "Status")
                        .WithMany("GameStatuses")
                        .HasForeignKey("StatusId")
                        .IsRequired()
                        .HasConstraintName("FK_game_status_status");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Entities.Models.Player", b =>
                {
                    b.HasOne("Entities.Models.Status", "Status")
                        .WithMany("Players")
                        .HasForeignKey("StatusId")
                        .IsRequired()
                        .HasConstraintName("FK_player_status");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Entities.Models.Point", b =>
                {
                    b.HasOne("Entities.Models.Game", "Game")
                        .WithMany("Points")
                        .HasForeignKey("GameId")
                        .IsRequired()
                        .HasConstraintName("FK_point_game");

                    b.HasOne("Entities.Models.GameSide", "GameSide")
                        .WithMany("Points")
                        .HasForeignKey("GameSideId")
                        .IsRequired()
                        .HasConstraintName("FK_point_game_side");

                    b.HasOne("Entities.Models.Status", "Status")
                        .WithMany("Points")
                        .HasForeignKey("StatusId")
                        .IsRequired()
                        .HasConstraintName("FK_point_status");

                    b.Navigation("Game");

                    b.Navigation("GameSide");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Entities.Models.Game", b =>
                {
                    b.Navigation("Points");
                });

            modelBuilder.Entity("Entities.Models.GameSide", b =>
                {
                    b.Navigation("Points");
                });

            modelBuilder.Entity("Entities.Models.GameStatus", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("Entities.Models.Player", b =>
                {
                    b.Navigation("GameCrossesPlayers");

                    b.Navigation("GameNoughtsPlayers");

                    b.Navigation("GameWinnerPlayers");
                });

            modelBuilder.Entity("Entities.Models.Status", b =>
                {
                    b.Navigation("GameSides");

                    b.Navigation("GameStatuses");

                    b.Navigation("Games");

                    b.Navigation("Players");

                    b.Navigation("Points");
                });
#pragma warning restore 612, 618
        }
    }
}