using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Entities;
using CustomExceptions;

namespace GameLogicService
{
    public class GameLogicService : IGameLogicService
    {
        private readonly IRepositoryWrapper _repository;
        public GameLogicService(IRepositoryWrapper wrapper)
        {
            _repository = wrapper;
        }

        public async Task<Game> CreateNewGame(string crossesPlayerName, string noughtPlayerName)
        {
            // Check if there is a running game (in this case throw an exception)
            if (await _repository.Game.AreThereRunningGames())
                throw new RunningGameExistsException("There is already one running game. It's impossible to add a second one");

            // Creating objects of players and a game
            var crossesPlayer = new Player(crossesPlayerName);
            var noughtPlayer = new Player(noughtPlayerName);
            var newGame = new Game(crossesPlayer, noughtPlayer);

            // Add them to context
            _repository.Game.AddGame(newGame);
            // Save
            await _repository.Save();
            // Return new game object
            return newGame;
        }

        public async Task<Point> MakeAMove(int gameSideId, int x, int y)
        {
            // Check if there is a running game
            if (!await _repository.Game.AreThereRunningGames())
                throw new NoRunningGamesExistException("There are no running games");

            // Then get the game
            Game CurrentGame = await _repository.Game.GetRunningGame();

            // Check if it's a suitable game side to make a move
            if (await GetLastMoveGameSide(CurrentGame.Id) == gameSideId)
            {
                string gameSide = gameSideId == (int)Enums.GameSide.Crosses ? "crosses" : "noughts";
                throw new WrongTurnException($"Now it's not a turn of {gameSide} to make a move");
            }
            
            // Check if a choosen point is occupied
            if (await _repository.Point.IsTherePoint(x, y))
                throw new PlaceOccupiedException("Point with these coordinates is already occupied");

            // Create a point object
            Point newPoint = new Point(CurrentGame.Id, gameSideId, x, y);

            // Add
            _repository.Point.AddPoint(newPoint);
            // Save
            await _repository.Save();
            // Return new object
            return newPoint;
        }

        public async Task StopGameExplicitly()
        {
            // Check if there is a running game
            if (!await _repository.Game.AreThereRunningGames())
                throw new NoRunningGamesExistException("There are no running games");

            // Then get the game
            var gameToStop = await _repository.Game.GetRunningGame();

            // Finish the game
            await FinishTheGame(gameToStop);
        }

        public async Task<Game?> CheckForGameover()
        {
            // Check if there is a running game
            if (!await _repository.Game.AreThereRunningGames())
                throw new NoRunningGamesExistException("There are no running games");

            // Then get the game
            Game currentGame = await _repository.Game.GetRunningGame();

            // Get points for different game sides
            var crossesPoints = currentGame.Points.Where(p => p.GameSideId.Equals((int)Enums.GameSide.Crosses)).ToList();
            var noughtsPoints = currentGame.Points.Where(p => p.GameSideId.Equals((int)Enums.GameSide.Noughts)).ToList();

            // Check winning combinations for different game sides
            // If one side is successful set a winning player and return updated game object
            if (CheckForCombinations(crossesPoints))
            {
                return await FinishTheGame(currentGame, currentGame.CrossesPlayerId);
            }
            else if (CheckForCombinations(noughtsPoints))
            {
                return await FinishTheGame(currentGame, currentGame.NoughtsPlayerId);
            }

            // In another case return null
            return null;
        }

        private async Task<Game> FinishTheGame(Game game, int winnerPlayerId = 0)
        {
            // Switch game status to Finished and set other parameters
            if (winnerPlayerId != 0)
                game.WinnerPlayerId = winnerPlayerId;

            game.EndTime = DateTime.Now;
            game.UpdateDate = DateTime.Now;
            game.GameStatusId = (int)Enums.GameStatus.Finished;

            // Switch game players status to Not Active and set other parameters
            var crossesPlayer = game.CrossesPlayer;
            crossesPlayer.UpdateDate = DateTime.Now;
            crossesPlayer.StatusId = (int)Enums.Status.NotActive;

            var noughtsPlayer = game.NoughtsPlayer;
            noughtsPlayer.UpdateDate = DateTime.Now;
            noughtsPlayer.StatusId = (int)Enums.Status.NotActive;

            var points = game.Points;
            foreach (var point in points)
            {
                point.UpdateDate = DateTime.Now;
                point.StatusId = (int)Enums.Status.NotActive;
                _repository.Point.UpdatePoint(point);
            }

            // Update entities
            _repository.Player.UpdatePlayer(crossesPlayer);
            _repository.Player.UpdatePlayer(noughtsPlayer);
            _repository.Game.UpdateGame(game);

            await _repository.Save();
            return game;
        }

        private bool CheckForCombinations(List<Point> points)
        {
            for (int i = 0; i < 3; i++)
            {
                if (points.Where(p => p.YValue.Equals(i)).Count().Equals(3))
                    return true;
            }

            for (int i = 0; i < 3; i++)
            {
                if (points.Where(p => p.XValue.Equals(i)).Count().Equals(3))
                    return true;
            }

            if ((points.Where(p => p.XValue.Equals(0) && p.YValue.Equals(0)).Any() &&
                points.Where(p => p.XValue.Equals(1) && p.YValue.Equals(1)).Any() &&
                points.Where(p => p.XValue.Equals(2) && p.YValue.Equals(2)).Any()) ||
                (points.Where(p => p.XValue.Equals(2) && p.YValue.Equals(0)).Any() &&
                points.Where(p => p.XValue.Equals(1) && p.YValue.Equals(1)).Any() &&
                points.Where(p => p.XValue.Equals(0) && p.YValue.Equals(2)).Any()))
            {
                return true;
            }

            return false;
        }

        private async Task<int> GetLastMoveGameSide(int gameId)
        {
            // Check if there are created points for this game
            if (!await _repository.Point.IsTherePointByGameId(gameId))
                return 0;

            // Get game side that made a move the last
            Point lastPoint = await _repository.Point.GetLastPointByGameId(gameId);
            return lastPoint.GameSideId;
        }
    }
}
