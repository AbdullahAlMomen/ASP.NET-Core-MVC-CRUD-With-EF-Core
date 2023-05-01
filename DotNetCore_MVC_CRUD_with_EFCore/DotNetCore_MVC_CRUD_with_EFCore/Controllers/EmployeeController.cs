using DotNetCore_MVC_CRUD_with_EFCore.Data;
using DotNetCore_MVC_CRUD_with_EFCore.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace DotNetCore_MVC_CRUD_with_EFCore.Controllers
{
    public class EmployeeController : Controller
    {
        private MVCDemoDbContext _mvcDemoDbContext;
        public EmployeeController(MVCDemoDbContext mvcDemoDbContext)
        {
            _mvcDemoDbContext= mvcDemoDbContext;
        }

        public async Task<IActionResult> GetEmployess()
        {
            var employees = await _mvcDemoDbContext.Employees.ToListAsync();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Employee employee) {

           await _mvcDemoDbContext.Employees.AddAsync(employee);
            await _mvcDemoDbContext.SaveChangesAsync();
            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var employee = await _mvcDemoDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var employee = await _mvcDemoDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            
            if (employee != null)
            {
                var _employee = await _mvcDemoDbContext.Employees.FirstOrDefaultAsync(x => x.Id == employee.Id);
                _employee.Name = employee.Name;
                _employee.Email = employee.Email;
                _employee.Salary= employee.Salary;
                _employee.DateOfBirthd = employee.DateOfBirthd;
            }
            await _mvcDemoDbContext.SaveChangesAsync();
            return RedirectToAction("GetEmployess");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var employee = await _mvcDemoDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee != null)
            {

                _mvcDemoDbContext.Employees.Remove(employee);

            }
            return View(employee);

        }

        [HttpPost]
        public async Task<IActionResult> Delete(Employee employee)
        {
            
            if (employee != null)
            {
                var _employee = await _mvcDemoDbContext.Employees.FirstOrDefaultAsync(x => x.Id == employee.Id);

                _mvcDemoDbContext.Employees.Remove(_employee);
                _mvcDemoDbContext.SaveChangesAsync();


            }
            return RedirectToAction("GetEmployess");
        }
    }
}
