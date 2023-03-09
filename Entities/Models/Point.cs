using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Point
{
    public Point()
    {

    }
    public Point(int gameId, int gameSideId, int x, int y)
    {
        Id = 0;
        XValue = x;
        YValue = y;
        GameId = gameId;
        GameSideId = gameSideId;
        CreateDate = DateTime.Now;
        UpdateDate = DateTime.Now;
        StatusId = (int)Enums.Status.Active;
    }
    public int Id { get; set; }

    public int XValue { get; set; }

    public int YValue { get; set; }

    public int GameId { get; set; }

    public int GameSideId { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public int StatusId { get; set; }

    public virtual Game Game { get; set; } = null!;

    public virtual GameSide GameSide { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;
}
