using System.Linq.Expressions;

namespace API_Business.IBusiness
{
    public interface IBusiness<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Expression<Func<T, bool>> expression);
        int Create(T entity);
        int Update(T entity);
        int Delete(T entity);
    }
}
