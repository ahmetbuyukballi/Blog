using Blog.Core;
using Blog.Data.Context;
using Blog.Data.Repositories.Abstractios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Repositories.Concretes
{
    public class Repository<T>:IRepository<T> where T : class,IEntityBase,new()
    {
        public readonly AppDbContext _dbContext;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        private DbSet<T> Table { get=>_dbContext.Set<T>(); }

        public async Task<List<T>> GetAllAsync(Expression<Func<T,bool>> predicate=null, params Expression<Func<T, object>>[] inculudeParamters)
        {
            IQueryable<T> query = Table;
            if(predicate != null)
            {
               query=query.Where(predicate);
            }
            if (inculudeParamters.Any())
            {
                foreach(var item  in inculudeParamters)
                {
                    query=query.Include(item);
                }
            }
            return await query.ToListAsync();
        }
        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] inculudeParamters)
        {
            IQueryable<T> query=Table;
            if(predicate != null)
            {
                query=query.Where(predicate);
            }
            if (inculudeParamters.Any())
            {
                foreach (var item in inculudeParamters)
                {
                    query=query.Include(item);
                }
            }
            return await query.SingleOrDefaultAsync();
        }

        public async Task<T> GetGuidAsync(Guid Id)
        {
          return await Table.FindAsync(Id);            
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(()=>Table.Update(entity));
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            return await Table.CountAsync(predicate);
        }
    }
}
