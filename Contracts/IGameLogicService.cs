using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IGameLogicService
    {
        Task<Game> CreateNewGame(string crossesPlayerName, string noughtPlayerName);
        Task StopGameExplicitly();
        Task<Point> MakeAMove(int gameSideId, int x, int y);
        Task<Game?> CheckForGameover();
    }
}
