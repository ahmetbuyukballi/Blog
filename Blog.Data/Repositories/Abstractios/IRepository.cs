﻿using Blog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Repositories.Abstractios
{
    public interface IRepository<T> where T : class,IEntityBase,new()
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] inculudeParamters);
        Task AddAsync(T entity);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] inculudeParamters);
        Task<T> GetGuidAsync(Guid Id);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T,bool>> predicate=null);
    }
}
