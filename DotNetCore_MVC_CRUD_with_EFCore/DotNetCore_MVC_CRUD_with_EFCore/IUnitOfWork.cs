using Microsoft.EntityFrameworkCore;

namespace DotNetCore_MVC_CRUD_with_EFCore
{
    public interface IUnitOfWork
    {

        //TContext Context { get; }      
        //void CreateTransaction();   
        //void Commit();      
        //void Rollback();
        IEmployeeRepository EmployeeRepository { get; }
        void Save();
    }
}
