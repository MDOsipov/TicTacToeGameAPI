using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Status
{
    public int Id { get; set; }

    public string StatusName { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public virtual ICollection<GameSide> GameSides { get; } = new List<GameSide>();

    public virtual ICollection<GameStatus> GameStatuses { get; } = new List<GameStatus>();

    public virtual ICollection<Game> Games { get; } = new List<Game>();

    public virtual ICollection<Player> Players { get; } = new List<Player>();

    public virtual ICollection<Point> Points { get; } = new List<Point>();
}
