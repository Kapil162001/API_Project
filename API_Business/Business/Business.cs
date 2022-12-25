using API_Business.IBusiness;
using API_Repository.IRepository;
using System.Linq.Expressions;

namespace API_Business.Business
{
    public class Business<T> : IBusiness<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        public Business(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<T>> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<T> GetById(Expression<Func<T, bool>> expression)
        {
            return _repository.GetById(expression);
        }
        public int Create(T entity)
        {
            return _repository.Create(entity);
        }

        public int Delete(T entity)
        {
            return _repository.Delete(entity);
        }

        public int Update(T entity)
        {
            return _repository.Update(entity);
        }
    }
}
