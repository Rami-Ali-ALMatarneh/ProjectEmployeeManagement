using Microsoft.AspNetCore.Mvc;
using ProjectEmployeeManagement.Data;
using ProjectEmployeeManagement.Models;
using ProjectEmployeeManagement.ViewModels;
using System.Net;

namespace ProjectEmployeeManagement.Controllers
    {
    public class HomeController : Controller
        {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HomeController(IEmployeeRepository employeeRepository, IWebHostEnvironment webHostEnvironment)
        {
            _employeeRepository = employeeRepository;            
            _webHostEnvironment= webHostEnvironment;
            }
        public ViewResult Index()
            {
            var Employee = _employeeRepository.GetAllEmployee();
            return View(Employee);
            }
        [Route("/home/Views/{department}")]
        public ViewResult Views( Department department )
            {
            var employeesByDepartment = _employeeRepository.GetEmployeesByDepartment(department);
            return View(employeesByDepartment);
            }
        public ViewResult Service()
            {
            return View("service");
            }
        public ViewResult ViewsAll()
            {
            var Employee = _employeeRepository.GetAllEmployee();
            return View(Employee);
            }
        public ViewResult About()
            {
            return View("About");
            }
        [HttpGet] //win you open create page
        public ViewResult Create()
            {
            return View();            
            }
        public ViewResult Delete(int id )
            {
            _employeeRepository.DeleteEmployee(id);
            var Employees= _employeeRepository.GetAllEmployee();    
            return View("ViewsAll", Employees);
            }
        [HttpPost]//win you create employee
        public IActionResult Create(HomeCreateViewModel model)
            {
          if(ModelState.IsValid)
                {
                string uniquePhotoName = string.IsNullOrEmpty(ProccessUploadFile(model))?string.Empty: ProccessUploadFile(model);
                Employee employeeModel = new Employee()
                    {
                    Name = model.Name,
                    Email = model.Email,
                    department = model.department,
                    Phone = model.Phone,
                    PhotoPath= uniquePhotoName,
                    };

                _employeeRepository.AddEmployee(employeeModel);
                 return RedirectToAction("Details",new{Id=employeeModel.Id});
                }
            return View(model);
            }
        public ViewResult Details(int?id)
            {
            //throw new Exception("Error in this View");
            Employee emp = _employeeRepository.GetEmployee(id??1);
            if(emp == null)
                {
                Response.StatusCode =(int)HttpStatusCode.NotFound;
                return View("ErrorMassage", id);
                }
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
                {
                employee = _employeeRepository.GetEmployee(id ?? 1),
                //pageTitle = "Error 404"
                };
                return View(homeDetailsViewModel);
            }
        [HttpGet]
        public IActionResult Update( int id )
            {
            Employee employee = _employeeRepository.GetEmployee(id);
            HomeEditViewModel model = new HomeEditViewModel()
                {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                department = employee.department,
                Phone = employee.Phone,
                ExistingPhotoPath=employee.PhotoPath
                };
            return View(model);
            }
        [HttpPost]
        public IActionResult Update( HomeEditViewModel model )
            {
            if( ModelState.IsValid )
                {
                Employee employee = _employeeRepository.GetEmployee(model.Id);
                employee.Id = model.Id;
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.department = model.department;
                employee.Phone = model.Phone;
                if (model.Photo != null)
                    {
                    if (model.ExistingPhotoPath != null)
                        {
                        string filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "imags");
                        System.IO.File.Delete(filePath);
                        }
                    employee.PhotoPath = ProccessUploadFile(model);
                    }
                Employee emp=_employeeRepository.UpdateEmployee(employee);  
                return RedirectToAction("Details", new { id = employee.Id });
                }
            return View(model);
            }
        private string ProccessUploadFile( HomeCreateViewModel model )
            {
            string uniqueImgName = null;
            if (model.Photo != null)
                {
                string uploadFile = Path.Combine(_webHostEnvironment.WebRootPath, "Imags");
                uniqueImgName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath= Path.Combine(uploadFile, uniqueImgName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                    model.Photo.CopyTo(fileStream);

                    }
                }
            return uniqueImgName;

            }

        }
    }
