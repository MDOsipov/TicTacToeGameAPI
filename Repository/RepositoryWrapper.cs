using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly TicTacToeGameContext _ticTacToeGameContext;
        private IPlayerRepository _player;
        private IGameRepository _game;
        private IPointRepository _point;
        private IGameStatusRepository _gameStatus;
        private IGameSideRepository _gameSide;


        public RepositoryWrapper(TicTacToeGameContext ticTacToeGameContext)
        {
            _ticTacToeGameContext = ticTacToeGameContext;   
        }

        public IPlayerRepository Player
        {
            get
            {
                if (_player is null)
                {
                    _player = new PlayerRepository(_ticTacToeGameContext);
                }
                return _player; 
            }
        }

        public IGameRepository Game
        {
            get
            {
                if (_game is null)
                {
                    _game = new GameRepository(_ticTacToeGameContext);
                }
                return _game;
            }
        }

        public IPointRepository Point
        {
            get
            {
                if (_point is null)
                {
                    _point = new PointRepository(_ticTacToeGameContext);
                }
                return _point;
            }
        }

        public IGameStatusRepository GameStatus
        {
            get
            {
                if (_gameStatus is null)
                {
                    _gameStatus = new GameStatusRepository(_ticTacToeGameContext);
                }
                return _gameStatus;
            }
        }

        public IGameSideRepository GameSide
        {
            get
            {
                if (_gameSide is null)
                {
                    _gameSide = new GameSideRepository(_ticTacToeGameContext);
                }
                return _gameSide;
            }
        }

        public async Task Save()
        {
            await _ticTacToeGameContext.SaveChangesAsync();
        }
    }
}
