using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public static class Enums
    {
        public enum Status
        {
            Active = 1,
            NotActive = 2
        }

        public enum GameStatus
        {
            Running = 1,
            Finished = 2
        }

        public enum GameSide
        {
            Crosses = 1,
            Noughts = 2
        }
    }
}
