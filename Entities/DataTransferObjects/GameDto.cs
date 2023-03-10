using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class GameDto
    {
        public string? GameStatus { get; set; }

        public string CrossesPlayerName { get; set; }

        public string NoughtsPlayerName { get; set; }

        public string? WinnerPlayerName { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }
    }
}
