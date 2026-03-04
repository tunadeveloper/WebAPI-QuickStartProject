using Microsoft.EntityFrameworkCore;
using QuickStartProject.WebAPILayer.Context;

namespace QuickStartProject.WebAPILayer.Repositories
{
    public class RepositoryService<T> : IRepositoryService<T> where T : class
    {
        private readonly ApiContext _context;
        private readonly DbSet<T> _table;
        public RepositoryService(ApiContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
           await _table.AddAsync(entity);
            _context.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _table.Remove(entity);
            _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _table.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _table.FindAsync(id);
        }

        public void Update(T entity)
        {
            _table.Update(entity);
            _context.SaveChangesAsync();
        }
    }
}
