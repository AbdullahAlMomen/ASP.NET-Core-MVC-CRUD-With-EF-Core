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
        private readonly IGenericRepository<Employee> _genericRepository;
       

       

        public EmployeeController(MVCDemoDbContext mvcDemoDbContext)
        {
            _mvcDemoDbContext = mvcDemoDbContext;
            _genericRepository = new GenericRepository<Employee>(_mvcDemoDbContext);
        }

        
        public async Task<IActionResult> GetEmployess()
        {
            var employees = await _genericRepository.GetAll();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Employee employee) {

          await _genericRepository.Insert(employee);
            await _genericRepository.Save();
            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var employee = await _genericRepository.GetById(id);
            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var employee = await _genericRepository.GetById(id);
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            
          await _genericRepository.Update(employee);
           
            return RedirectToAction("GetEmployess");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var employee = await _genericRepository.GetById(id);

            return View(employee);

        }

        [HttpPost]
        public async Task<IActionResult> Delete(Employee employee)
        {

             _genericRepository.Delete(employee);
            await _genericRepository.Save();
            return RedirectToAction("GetEmployess");
        }
    }
}
