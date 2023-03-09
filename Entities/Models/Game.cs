using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Game
{
    public Game()
    {

    }
    public Game(Player CrossesPlayer, Player NoughtsPlayer)
    {
        this.CrossesPlayer = CrossesPlayer;
        this.NoughtsPlayer = NoughtsPlayer;
        Id = 0;
        GameStatusId = (int)Enums.GameStatus.Running;
        CrossesPlayerId = CrossesPlayer.Id;
        NoughtsPlayerId = NoughtsPlayer.Id;
        CreateDate = DateTime.Now;
        UpdateDate = DateTime.Now;
        StatusId = (int)Enums.Status.Active;
        StartTime = DateTime.Now;
    }

    public int Id { get; set; }

    public int GameStatusId { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int CrossesPlayerId { get; set; }

    public int NoughtsPlayerId { get; set; }

    public int? WinnerPlayerId { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public int StatusId { get; set; }

    public virtual Player CrossesPlayer { get; set; } = null!;

    public virtual GameStatus GameStatus { get; set; } = null!;

    public virtual Player NoughtsPlayer { get; set; } = null!;

    public virtual ICollection<Point> Points { get; } = new List<Point>();

    public virtual Status Status { get; set; } = null!;

    public virtual Player? WinnerPlayer { get; set; }
}
