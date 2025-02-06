using Blog.Data.Context;
using Blog.Data.Repositories.Abstractios;
using Blog.Data.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.UnitOFWork
{
    public class UnitOFWork : IUnitOFWork
    {
        private readonly AppDbContext _dbContext;

        public UnitOFWork(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }

        public int Save()
        {
           return _dbContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        IRepository<T> IUnitOFWork.GetRepository<T>()
        {
            return new Repository<T>(_dbContext);
        }
    }
}
