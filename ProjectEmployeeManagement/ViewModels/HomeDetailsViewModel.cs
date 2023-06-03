using ProjectEmployeeManagement.Models;

namespace ProjectEmployeeManagement.ViewModels
    {
    public class HomeDetailsViewModel
        {
        //internal IEnumerable<Employee> Employees;
        public Employee employee { get; set; }
        public string pageTitle { get; set; }=string.Empty; 
        }
    }
