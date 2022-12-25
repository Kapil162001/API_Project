using API_Repository.DataContext;
using API_Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace API_Repository.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDBContext _dBContext;
        private DbSet<T> dbSet;
        public GenericRepository(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
            this.dbSet = _dBContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetById(Expression<Func<T, bool>> expression)
        {
            return await dbSet.FirstOrDefaultAsync(expression);
        }

        public int Create(T entity)
        {
            dbSet.Add(entity);
            return Save();
        }

        public int Update(T entity)
        {
            dbSet.Update(entity);
            return Save();
        }

        public int Delete(T entity)
        {
            dbSet.Remove(entity);
            return Save();
        }

        public int Save()
        {
            return _dBContext.SaveChanges();
        }
    }
}
