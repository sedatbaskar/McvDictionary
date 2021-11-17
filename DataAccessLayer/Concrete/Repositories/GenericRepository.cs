using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class //IRepository referans aldım ve T değeri
                                                                      //class olması şartı koydum.
    {
        Context c = new Context(); //Context sınıfından nesne türettim.
        DbSet <T> _object;        //DbSet T değeri alıcağını söyledim ama_object T değeri alması gerekiyor
                                  //bunun içinde bir yapıcı metot oluşturarak _object değişkenine T değerini verdim.
        public GenericRepository()
        {
            _object = c.Set<T>();
        }

        public void Delete(T p)
        {
            _object.Remove(p);
            c.SaveChanges();
                
        }

        public void Insert(T p)
        {
            _object.Add(p);
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            c.SaveChanges();
        }
    }
}
