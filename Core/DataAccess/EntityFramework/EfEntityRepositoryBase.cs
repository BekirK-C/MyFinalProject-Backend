using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext> : IEntityRepository<TEntity> where TEntity : class, IEntity, new() where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            // Buradaki using IDisposable pattern implementation of C#
            // Bu kullanım sayesinde using bloku bittikten sonra garbage collector newlenen ögeyi siler. (Verimi arttırır)
            using (TContext context = new TContext())
            {
                // 1.Veri kaynağı ile ilişkilendir. 2.Ekleme olarak durumunu set et. 3.Ekle
                var addedEntity = context.Entry(entity); // Veri kaynağından gönderilen entity(product)'a bir tane nesneyi eşleştir. (referans olarak) (Yeni ekleme olduğu için eşleşme olmaz.)
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deleteEntity = context.Entry(entity); // Veri kaynağından gönderilen entity(product)'a bir tane nesneyi eşelştir.
                deleteEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList(); // turnary kullanımı (tek satırda if)
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity); // Veri kaynağından gönderilen entity(product)'a bir tane nesneyi eşelştir.
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
