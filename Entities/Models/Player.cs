using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Player
{
    public Player()
    {

    }
    public Player(string name)
    {
        Id = 0;
        Name = name;
        CreateDate = DateTime.Now;
        UpdateDate= DateTime.Now;   
        StatusId = (int)Enums.Status.Active;    
    }
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public int StatusId { get; set; }

    public virtual ICollection<Game> GameCrossesPlayers { get; } = new List<Game>();

    public virtual ICollection<Game> GameNoughtsPlayers { get; } = new List<Game>();

    public virtual ICollection<Game> GameWinnerPlayers { get; } = new List<Game>();

    public virtual Status Status { get; set; } = null!;
}
