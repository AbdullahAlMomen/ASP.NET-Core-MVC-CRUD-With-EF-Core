namespace DotNetCore_MVC_CRUD_with_EFCore
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(object id);
        Task Insert(T entity);
        Task Update(T entity);
        void Delete(T entity);

        Task Save();
    }
}
