using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class GameSide
{
    public int Id { get; set; }

    public string SideName { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public int StatusId { get; set; }

    public virtual ICollection<Point> Points { get; } = new List<Point>();

    public virtual Status Status { get; set; } = null!;
}
