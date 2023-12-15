using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWeb2024.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        // GENERIC REPOSITORY
        // T - Category

        // GET ALL CATEGORIES:
        IEnumerable<T> GetAll();

        // GET SINGLE INDIVIDUAL CATEGORY:
        T Get(Expression<Func<T, bool>> filter);

        // ADD CATEGORY:
        void Add(T entity);

        // DELETE CATEGORY:
        void Remove(T entity);

        // DELETE CATEGORIES:
        void RemoveRange(IEnumerable<T> entity);
    }
}
