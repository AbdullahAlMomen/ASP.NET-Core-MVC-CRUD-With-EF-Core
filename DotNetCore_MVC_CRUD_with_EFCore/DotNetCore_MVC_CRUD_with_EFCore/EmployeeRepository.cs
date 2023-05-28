using DotNetCore_MVC_CRUD_with_EFCore.Data;
using DotNetCore_MVC_CRUD_with_EFCore.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DotNetCore_MVC_CRUD_with_EFCore
{
    public class EmployeeRepository :GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly MVCDemoDbContext _mvcDemoDbContext;
       
        public EmployeeRepository(MVCDemoDbContext mvcDemoDbContext):base(mvcDemoDbContext) 
        {
           
        }

       
    }
}
