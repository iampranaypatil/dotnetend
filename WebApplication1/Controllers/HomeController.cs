using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using BOL;
using BLL;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        HRManager Service = new HRManager();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Get All Employees
        public IActionResult List()
        {

            List<Employee> employees = Service.AllEmployees();
            Console.WriteLine(employees);
            this.ViewBag.Employees = employees;
            return View();
        }

        //Add New Employee
        
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        //empId | name         | email                    | password | location    | joinDate   | salary
        public IActionResult Register(int empId, string name, string email, string password, string location,string joinDate, double salary)
        {
            Employee employee = new Employee(empId,name,email,password,location, DateOnly.Parse(joinDate), salary);
            bool inserted= Service.AddNewEMP(employee);
            if (inserted)
            {
                Console.WriteLine("New Employee with Name: '" + employee.name + "' inserted succesfully ");
            }
            else
                Console.WriteLine("Not Inserted");

            return RedirectToAction("List");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}