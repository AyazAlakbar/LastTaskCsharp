using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface IRepository<T> where T : IEntity
    {
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);

        T Get(Predicate<T> filter = null);
        List<T> GetAll(Predicate<T> filter = null);
    }
}