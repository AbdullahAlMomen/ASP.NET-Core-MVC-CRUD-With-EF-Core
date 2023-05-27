using DotNetCore_MVC_CRUD_with_EFCore.Data;
using DotNetCore_MVC_CRUD_with_EFCore.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace DotNetCore_MVC_CRUD_with_EFCore.Controllers
{
    public class EmployeeController : Controller
    {
        
        public readonly IUnitOfWork _unitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;           
        }

      
        public  IActionResult GetEmployess()
        {
            var employees =  _unitOfWork.EmployeeRepository.GetAll();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Employee employee)
        {

            _unitOfWork.EmployeeRepository.Insert(employee);
            _unitOfWork.Save();
            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(id);
            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(id);
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {

            await _unitOfWork.EmployeeRepository.Update(employee);

            return RedirectToAction("GetEmployess");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(id);

            return View(employee);

        }

        [HttpPost]
        public async Task<IActionResult> Delete(Employee employee)
        {

            _unitOfWork.EmployeeRepository.Delete(employee);
             _unitOfWork.Save();
            return RedirectToAction("GetEmployess");
        }
    }
}
