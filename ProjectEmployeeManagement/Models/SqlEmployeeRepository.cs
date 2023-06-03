using Microsoft.EntityFrameworkCore;
using ProjectEmployeeManagement.Data;

namespace ProjectEmployeeManagement.Models
    {
    public class SqlEmployeeRepository : IEmployeeRepository
        {
        private readonly AppDbContext _context;

        public SqlEmployeeRepository( AppDbContext appDbContext )
            {
            _context = appDbContext;
            }
        public Employee AddEmployee( Employee employee )
            {
            //employee.Id=count++;
            _context.Employee.Add(employee);
            _context.SaveChanges();
            return employee;
            }
    

        public Employee DeleteEmployee( int id )
            {
            Employee employee = _context.Employee.Find(id);
            if( employee != null )
                {
                _context.Employee.Remove(employee);
                _context.SaveChanges();
                }
            return employee; 
            }
        public IEnumerable<Employee> GetAllEmployee()
            {
            return _context.Employee;
            }

        public Employee GetEmployee( int id )
            {
            return _context.Employee.Find(id);
            }

        public Employee UpdateEmployee( Employee employee )
            {
            var Employee = _context.Employee.Attach(employee);
            Employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return employee;
            }

        public IEnumerable<Employee> GetEmployeesByDepartment( Department department )
            {
            return _context.Employee.Where(emp => emp.department == department);
            }
        }
    }
