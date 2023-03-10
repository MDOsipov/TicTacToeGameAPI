using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPointRepository
    {
        void AddPoint(Point point);
        void UpdatePoint(Point point);
        Task<Point> GetPointById(int pointId);
        Task<IEnumerable<Point>> GetPoints();
        Task<bool> PointExists(int pointId);
        Task<bool> IsTherePoint(int x, int y);
        Task<bool> IsTherePointByGameId(int gameId);
        Task<Point> GetLastPointByGameId(int gameId);
    }
}
