using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace API_Repository.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Expression<Func<T, bool>> expression);
        int Create(T entity);
        int Update(T entity);
        int Delete(T entity);
        int Save();
    }
}
