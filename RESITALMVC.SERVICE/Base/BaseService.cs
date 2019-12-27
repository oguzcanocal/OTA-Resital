using RESITALMVC.CORE.Entity;
using RESITALMVC.CORE.Service;
using RESITALMVC.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RESITALMVC.SERVICE.Base
{
    public class BaseService<T> : ICoreService<T> where T : CoreEntity
    {
        private static ResitalContext _db;
        public static ResitalContext db
        {
            get
            {
                if (_db == null)
                {
                    _db = new ResitalContext();
                }

                return _db;
            }
        }
        public void Add(T item)
        {
            db.Set<T>().Add(item);
            db.SaveChanges();
        }

        public void Add(List<T> item)
        {
            db.Set<T>().AddRange(item);
            db.SaveChanges();
        }

        public List<T> GetActive()
        {
            return db.Set<T>().Where(x => x.Status == RESITALMVC.CORE.Enums.Status.Actived).ToList();
        }

        public List<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public T GetById(Guid id)
        {
            return db.Set<T>().Find(id);
        }

        public void Remove(T item)
        {
            item.Status = RESITALMVC.CORE.Enums.Status.Deleted;
            Update(item);
        }

        public void Update(T item)
        {
            T updated = db.Set<T>().Find(item.ID);
            DbEntityEntry entry = db.Entry(updated);
            entry.CurrentValues.SetValues(item);
            db.SaveChanges();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Any(exp);
        }

        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Where(exp).FirstOrDefault();
        }
    }
}
