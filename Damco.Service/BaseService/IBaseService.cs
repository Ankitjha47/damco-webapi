using Damco.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Damco.Service.BaseService
{
    public interface IBaseService<T> where T : BaseEntity
    {
        T Insert(T entity);
        T Update(T entity);
        int Delete(T entity);
        int SaveChanges();
    }
}
