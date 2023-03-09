using System;
using System.Collections.Generic;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities;

public partial class TicTacToeGameContext : DbContext
{
    public TicTacToeGameContext()
    {
    }

    public TicTacToeGameContext(DbContextOptions<TicTacToeGameContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<GameSide> GameSides { get; set; }

    public virtual DbSet<GameStatus> GameStatuses { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<Point> Points { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>(entity =>
        {
            entity.ToTable("game");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.CrossesPlayerId).HasColumnName("crosses_player_id");
            entity.Property(e => e.EndTime)
                .HasColumnType("datetime")
                .HasColumnName("end_time");
            entity.Property(e => e.GameStatusId).HasColumnName("game_status_id");
            entity.Property(e => e.NoughtsPlayerId).HasColumnName("noughts_player_id");
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("start_time");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");
            entity.Property(e => e.WinnerPlayerId).HasColumnName("winner_player_id");

            entity.HasOne(d => d.CrossesPlayer).WithMany(p => p.GameCrossesPlayers)
                .HasForeignKey(d => d.CrossesPlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_game_player");

            entity.HasOne(d => d.GameStatus).WithMany(p => p.Games)
                .HasForeignKey(d => d.GameStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_game_game_status");

            entity.HasOne(d => d.NoughtsPlayer).WithMany(p => p.GameNoughtsPlayers)
                .HasForeignKey(d => d.NoughtsPlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_game_player1");

            entity.HasOne(d => d.Status).WithMany(p => p.Games)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_game_status");

            entity.HasOne(d => d.WinnerPlayer).WithMany(p => p.GameWinnerPlayers)
                .HasForeignKey(d => d.WinnerPlayerId)
                .HasConstraintName("FK_game_player2");

            entity.HasQueryFilter(g => g.StatusId.Equals((int)Enums.Status.Active));
            entity.HasQueryFilter(g => g.CrossesPlayer.StatusId.Equals((int)Enums.Status.Active));
            entity.HasQueryFilter(g => g.NoughtsPlayer.StatusId.Equals((int)Enums.Status.Active));
           
        });

        modelBuilder.Entity<GameSide>(entity =>
        {
            entity.ToTable("game_side");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.SideName)
                .HasMaxLength(50)
                .HasColumnName("side_name");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");

            entity.HasOne(d => d.Status).WithMany(p => p.GameSides)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_game_side_status");

            entity.HasData(
                new GameSide()
                {
                    Id = 1,
                    SideName = "Crosses",
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    StatusId = (int)Enums.Status.Active
                },
                new GameSide()
                {
                    Id = 2,
                    SideName = "Noughts",
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    StatusId = (int)Enums.Status.Active
                }
            );
        });

        modelBuilder.Entity<GameStatus>(entity =>
        {
            entity.ToTable("game_status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.GameStatusName)
                .HasMaxLength(50)
                .HasColumnName("game_status_name");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");

            entity.HasOne(d => d.Status).WithMany(p => p.GameStatuses)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_game_status_status");

            entity.HasData(
                new GameStatus()
                {
                    Id = 1,
                    GameStatusName = "Running",
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    StatusId = 1
                },
                new GameStatus()
                {
                    Id = 2,
                    GameStatusName = "Finished",
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    StatusId = 1
                }
            );
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.ToTable("player");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");

            entity.HasOne(d => d.Status).WithMany(p => p.Players)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_player_status");

            entity.HasQueryFilter(p => p.StatusId.Equals((int)Enums.Status.Active));
        });

        modelBuilder.Entity<Point>(entity =>
        {
            entity.ToTable("point");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.GameId).HasColumnName("game_id");
            entity.Property(e => e.GameSideId).HasColumnName("game_side_id");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");
            entity.Property(e => e.XValue).HasColumnName("x_value");
            entity.Property(e => e.YValue).HasColumnName("y_value");

            entity.HasOne(d => d.Game).WithMany(p => p.Points)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_point_game");

            entity.HasOne(d => d.GameSide).WithMany(p => p.Points)
                .HasForeignKey(d => d.GameSideId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_point_game_side");

            entity.HasOne(d => d.Status).WithMany(p => p.Points)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_point_status");

            entity.HasQueryFilter(p => p.StatusId.Equals((int)Enums.Status.Active));
            entity.HasQueryFilter(p => p.Game.StatusId.Equals((int)Enums.Status.Active));
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.StatusName)
                .HasMaxLength(50)
                .HasColumnName("status_name");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");

            entity.HasData(
                new Status()
                {
                    Id = 1,
                    StatusName = "Active",
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                },
                new Status()
                {
                    Id = 2,
                    StatusName = "Not active",
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                }
            );
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
