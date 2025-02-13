using ECommerce.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;  // Asenkron işlemler için
using System.Collections.Generic;
using ECommerce.Repository.Repository; // List ekleyelim

/*
 REPOSİTORY KATMANI :
 Veri erişim işlemlerini (CRUD) soyutlar ve kolaylaştırır.
 */
public class RepositoryBase<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;

    public RepositoryBase(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public IQueryable<T> GetAll() => _dbSet;

    public T GetById(int id) => _dbSet.Find(id);

    public IQueryable<T> Find(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate);

    // AddAsync metodunu implement ediyoruz
    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity); 
        await _context.SaveChangesAsync(); 
    }

    
    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
    {
        if (predicate == null)
            return await _dbSet.ToListAsync(); 
        else
            return await _dbSet.Where(predicate).ToListAsync(); 
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
        _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
        _context.SaveChanges();
    }

    public void Add(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> FindAsync(Expression<Func<T, bool>> predicate)
    {
        throw new NotImplementedException();
    }
}
