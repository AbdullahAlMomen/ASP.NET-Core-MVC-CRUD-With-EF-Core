using DotNetCore_MVC_CRUD_with_EFCore.Data;
using Microsoft.EntityFrameworkCore;

namespace DotNetCore_MVC_CRUD_with_EFCore
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DbSet<T> table = null;
        private readonly MVCDemoDbContext _mvcDemoDbContext;

        public GenericRepository(MVCDemoDbContext mvcDemoDbContext)
        {
            _mvcDemoDbContext = mvcDemoDbContext;
            table = mvcDemoDbContext.Set<T>();
        }

        public async void Delete(T entity)
        {
            table.Remove(entity);

        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync();
        }

        public async Task<T> GetById(object id)
        {
          return await table.FindAsync(id);
        }

        public async Task Insert(T entity)
        {
           await table.AddAsync(entity);
        }

        public async Task Save()
        {
            await _mvcDemoDbContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            table.Attach(entity);
           _mvcDemoDbContext.Entry(entity).State= EntityState.Modified;
            await Save();
        }
    }
}
