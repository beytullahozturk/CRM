using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    // Generic COnstraints : Generic kısılama, Tür parametrelerinde kısıtlama
    // where T:class, IEntity, new() => Referans tip olabilir. IEntity implemente eden nesne olabilir. New'lenebilir olmalıdır.
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null); // Expression: filtreler yazabilmek için.
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
