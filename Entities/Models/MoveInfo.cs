using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class MoveInfo
    {
        [Range((int)Enums.GameSide.Crosses, (int)Enums.GameSide.Noughts)]
        public int GameSideId { get; set; }

        [Range(0, 2)]
        public int X { get; set; }

        [Range(0, 2)]
        public int Y { get; set; }  
    }
}
