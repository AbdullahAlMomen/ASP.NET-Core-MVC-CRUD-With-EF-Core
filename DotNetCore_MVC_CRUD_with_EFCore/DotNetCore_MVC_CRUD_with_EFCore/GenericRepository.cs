using DotNetCore_MVC_CRUD_with_EFCore.Data;
using Microsoft.EntityFrameworkCore;

namespace DotNetCore_MVC_CRUD_with_EFCore
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DbSet<T> _entities;
        private string _errorMessage = string.Empty;
        private bool _isDisposed;
        
        public readonly MVCDemoDbContext _mvcDemoDbContext;
        public GenericRepository(MVCDemoDbContext context)
        {
            _mvcDemoDbContext = context;
        }
       
       
        public virtual IEnumerable<T> GetAll()
        {
            
            return _mvcDemoDbContext.Set<T>().ToList();
        }

        public virtual T GetById(object id)
        {
            return _mvcDemoDbContext.Set<T>().Find(id);
        }

        public virtual void Insert(T entity)
        {
            _mvcDemoDbContext.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _mvcDemoDbContext.Set<T>().Remove(entity);
        }

        public virtual async Task Save()
        {
            await _mvcDemoDbContext.SaveChangesAsync();
        }

        public virtual async Task Update(T entity)
        {
            _mvcDemoDbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await Save();
        }

       
    }
}
