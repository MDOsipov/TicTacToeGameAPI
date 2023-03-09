using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        Task Save();
        IPlayerRepository Player { get; }
        IGameRepository Game { get; }
        IPointRepository Point { get; }
    }
}
