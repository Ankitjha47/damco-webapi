using Damco.Domain;
using Damco.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Damco.Service.BaseService
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {

        private readonly DamcoContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public BaseService(DamcoContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public T Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.created_at = DateTime.Now;
            entities.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.modified_at = DateTime.Now;
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }

        public int Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.deleted_at = DateTime.Now;
            context.Entry(entity).State = EntityState.Modified;
            return context.SaveChanges();
        }
        public int SaveChanges()
        {
            return context.SaveChanges();
        }
    }
}
