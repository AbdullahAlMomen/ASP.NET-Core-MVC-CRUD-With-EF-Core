namespace DotNetCore_MVC_CRUD_with_EFCore
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T entity);
        Task Update(T entity);
        void Delete(T entity);

        Task Save();
    }
}
