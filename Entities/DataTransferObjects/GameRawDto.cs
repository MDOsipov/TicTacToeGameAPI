using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class GameRawDto
    {
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
    }
}
