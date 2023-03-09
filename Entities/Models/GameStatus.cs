using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class GameStatus
{
    public int Id { get; set; }

    public string GameStatusName { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public int StatusId { get; set; }

    public virtual ICollection<Game> Games { get; } = new List<Game>();

    public virtual Status Status { get; set; } = null!;
}
