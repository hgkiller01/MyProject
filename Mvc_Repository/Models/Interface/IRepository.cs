﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Mvc_Repository.Models.Interface
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        
        void Create(TEntity instance);
        void Update(TEntity instance);
        void Delete(TEntity instance);
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll();
        void SaveChanges();
    }
}