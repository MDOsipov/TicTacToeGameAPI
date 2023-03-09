using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class 
    {
        protected TicTacToeGameContext ticTacToeGameContext { get; set; }

        public RepositoryBase(TicTacToeGameContext context)
        {
            ticTacToeGameContext = context;
        }

        public IQueryable<T> FindAll() => ticTacToeGameContext.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => ticTacToeGameContext.Set<T>().Where(expression).AsNoTracking();
        public void Create(T entity) => ticTacToeGameContext.Set<T>().Add(entity);
        public void Update(T entity) => ticTacToeGameContext.Set<T>().Update(entity);
        public void Delete(T entity) => ticTacToeGameContext.Set<T>().Remove(entity);
    }
    
}
