using DotNetCore_MVC_CRUD_with_EFCore.Models.Domain;

namespace DotNetCore_MVC_CRUD_with_EFCore
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetById(Guid EmployeeID);
        Task Insert(Employee employee);
        Task Update(Employee employee);
        void  Delete(Employee employee);
        Task Save();
    }
}
