using System.Linq.Expressions;

namespace BlazorServerApp.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task Insert(T entity);

        Task<List<T>> GetAll(Expression<Func<T, bool>>? expression = null, string? IncludeProperites = null);
        Task<T?> GetById(int? id);
        Task<T> Get(Expression<Func<T, bool>> expression, string? IncludeProperites = null);
        
        Task Update(T entity);

        Task Delete(int id);
    }
}
