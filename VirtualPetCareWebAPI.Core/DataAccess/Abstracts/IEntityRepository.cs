﻿using VirtualPetCareWebAPI.Entity.Abstracts;
using System.Linq.Expressions;

namespace VirtualPetCareWebAPI.DataAccess.Abstracts
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
