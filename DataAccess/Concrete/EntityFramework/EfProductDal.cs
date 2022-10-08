using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            // Buradaki using IDisposable pattern implementation of C#
            // Bu kullanım sayesinde using bloku bittikten sonra garbage collector newlenen ögeyi siler. (Verimi arttırır)
            using (NorthwindContext context = new NorthwindContext())
            {
                // 1.Veri kaynağı ile ilişkilendir. 2.Ekleme olarak durumunu set et. 3.Ekle
                var addedEntity = context.Entry(entity); // Veri kaynağından gönderilen entity(product)'a bir tane nesneyi eşleştir. (referans olarak) (Yeni ekleme olduğu için eşleşme olmaz.)
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deleteEntity = context.Entry(entity); // Veri kaynağından gönderilen entity(product)'a bir tane nesneyi eşelştir.
                deleteEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList(); // turnary kullanımı (tek satırda if)
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity); // Veri kaynağından gönderilen entity(product)'a bir tane nesneyi eşelştir.
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
