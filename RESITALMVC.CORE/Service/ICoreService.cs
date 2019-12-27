using RESITALMVC.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESITALMVC.CORE.Service
{
    public interface ICoreService<T> where T:CoreEntity
    {
        void Add(T item);
        void Add(List<T> item);
        void Update(T item);
        void Remove(T item);
        T GetById(Guid id);
        List<T> GetActive();
        List<T> GetAll();

    }
}
