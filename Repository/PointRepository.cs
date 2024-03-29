﻿using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PointRepository : RepositoryBase<Point>, IPointRepository
    {
        public PointRepository(TicTacToeGameContext context)
            :base(context)
        {

        }

        public void AddPoint(Point point)
        {
            Create(point);
        }

        public async Task<Point> GetLastPointByGameId(int gameId)
        {
            int maxId = await FindByCondition(p => p.GameId.Equals(gameId) && p.StatusId.Equals((int)Enums.Status.Active)).Select(p => p.Id).MaxAsync();
            return await FindByCondition(p => p.Id.Equals(maxId)).FirstOrDefaultAsync();
        }

        public async Task<Point> GetPointById(int pointId)
        {
            return await FindByCondition(p => p.Id.Equals(pointId) && p.StatusId.Equals((int)Enums.Status.Active))
                .Include(p => p.GameSide)
                .FirstOrDefaultAsync();    
        }

        public async Task<IEnumerable<Point>> GetPoints()
        {
            return await FindByCondition(p => p.StatusId.Equals((int)Enums.Status.Active)).ToListAsync();
        }

        public async Task<bool> IsTherePoint(int x, int y)
        {
            return await FindByCondition(p => p.XValue.Equals(x) && p.YValue.Equals(y) && p.StatusId.Equals((int)Enums.Status.Active)).AnyAsync();  
        }

        public async Task<bool> IsTherePointByGameId(int gameId)
        {
            return await FindByCondition(p => p.GameId.Equals(gameId) && p.StatusId.Equals((int)Enums.Status.Active)).AnyAsync();
        }

        public async Task<bool> PointExists(int pointId)
        {
            return await FindByCondition(p => p.Id.Equals(pointId) && p.StatusId.Equals((int)Enums.Status.Active)).AnyAsync(); 
        }

        public void UpdatePoint(Point point)
        {
            Update(point);
        }
    }
}
