﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Contexts;

namespace DataAccessLayer.Concrete.Repository
{
    //Bu GenericRepository<T> sınıfı, genellikle veritabanı işlemlerinin soyutlanması ve tekrar kullanılabilir bir yapı oluşturulması amacıyla kullanılır.
    // Sınıfı kullanacak olanlar, bu sınıfı belirli bir varlık (entity) tipi için özel işlemleri gerçekleştirmek üzere uyarlayabilirler.
    public class GenericRepository<T> : IGenericDal<T> where T : class, new()
    {
        public void Delete(T t)
        {
            using var context = new AgricultureContext();
            context.Remove(t);
            context.SaveChanges();
        }

        public T GetById(int id)
        {
            using var context = new AgricultureContext();
            return context.Set<T>().Find(id);
        }

        public List<T> GetListAll()
        {
            using var context = new AgricultureContext();
            return context.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            using var context = new AgricultureContext();
            context.Add(t);
            context.SaveChanges();
        }

        public void Update(T t)
        {
            using var context = new AgricultureContext();
            context.Update(t);
            context.SaveChanges();
        }
    }
}
