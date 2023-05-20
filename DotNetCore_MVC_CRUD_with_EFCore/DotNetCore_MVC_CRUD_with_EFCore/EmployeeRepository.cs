using DotNetCore_MVC_CRUD_with_EFCore.Data;
using DotNetCore_MVC_CRUD_with_EFCore.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DotNetCore_MVC_CRUD_with_EFCore
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MVCDemoDbContext _mvcDemoDbContext;
       
        public EmployeeRepository(MVCDemoDbContext mvcDemoDbContext)
        {
            _mvcDemoDbContext = mvcDemoDbContext;
        }

        public void  Delete(Employee employee)
        {
            if (employee != null)
            {
                 _mvcDemoDbContext.Employees.Remove(employee);

            }
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var employees = await _mvcDemoDbContext.Employees.ToListAsync();
            return employees;
        }

        public async Task<Employee> GetById(Guid EmployeeID)
        {
            var employee = await _mvcDemoDbContext.Employees.FirstOrDefaultAsync(x => x.Id == EmployeeID);
            if (employee != null)
            {
                return employee;
            }
            return employee;
        }

        public async Task Insert(Employee employee)
        {
            await _mvcDemoDbContext.Employees.AddAsync(employee);
        }

        public async Task Save()
        {
           await _mvcDemoDbContext.SaveChangesAsync();
        }

        public async Task Update(Employee employee)
        {
            
            if (employee != null)
            {
                var _employee = await GetById( employee.Id);
                _employee.Name = employee.Name;
                _employee.Email = employee.Email;
                _employee.Salary = employee.Salary;
                _employee.DateOfBirthd = employee.DateOfBirthd;
            }
           await Save();
        }
    }
}
