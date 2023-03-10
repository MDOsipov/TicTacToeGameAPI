using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IGameRepository
    {
        Task<bool> AreThereRunningGames();
        Task<bool> GameExists(int gameId);
        Task<Game> GetRunningGame();
        Task<Game> GetGameById(int gameId);
        Task<IEnumerable<Game>> GetFinishedGames();
        void AddGame(Game game);
        void UpdateGame(Game game); 
        void DeleteGame(Game game); 
    }
}
