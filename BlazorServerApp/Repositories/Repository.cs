using System.Linq.Expressions;

namespace BlazorServerApp.Repositories;
public class Repository<T> : IRepository<T> where T : class
{
    protected readonly Applicationdbcontext _context;
    protected readonly DbSet<T> _dbSet;
    public Repository(Applicationdbcontext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }
    public virtual async Task Insert(T entity)
    {
        var createdEntity = await _dbSet.AddAsync(entity);

        await _context.SaveChangesAsync();
        _context.ChangeTracker.Clear();
    }
    public async Task<List<T>> GetAll(Expression<Func<T, bool>>? expression = null, string? IncludeProperites = null)
    {
        IQueryable<T> entities = _dbSet;

        if (expression != null)
        {
            entities = entities.Where(expression);
        }

        if (!string.IsNullOrEmpty(IncludeProperites))
        {
            foreach (var item in IncludeProperites.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                entities = entities.Include(item);
            }
        }

        return await entities.ToListAsync();
    }
    public async Task<T> Get(Expression<Func<T, bool>> expression, string? IncludeProperites = null)
    {
        IQueryable<T> entityFromDB = _dbSet.AsNoTracking();

        if (!string.IsNullOrEmpty(IncludeProperites))
        {
            foreach (var item in IncludeProperites.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                entityFromDB = entityFromDB.Include(item);
            }
        }
        T? value = await entityFromDB.FirstOrDefaultAsync(expression);

        return value;
    }

    public async Task Update(T entity)
    {
        _dbSet.Update(entity);

        await _context.SaveChangesAsync();
        _context.ChangeTracker.Clear();
    }
    public async Task Delete(int id)
    {
        T? entityFromDb = await GetById(id);

        if (entityFromDb is not null)
        {
            _dbSet.Remove(entityFromDb);

            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }
    }

    public async Task<T?> GetById(int? id)
    {
        T? entity =await _dbSet.FindAsync(id);
        return entity;
    }
}
