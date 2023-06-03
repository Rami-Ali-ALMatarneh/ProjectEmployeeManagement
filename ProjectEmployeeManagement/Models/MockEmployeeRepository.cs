namespace ProjectEmployeeManagement.Models
    {
    public class MockEmployeeRepository : IEmployeeRepository
        {
       private  List<Employee> _employees;
        public MockEmployeeRepository()
        {
           
            _employees = new List<Employee>();
            
        }
        public Employee AddEmployee( Employee employee )
            {
            employee.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add( employee );
            return employee;
            }

        public Employee DeleteEmployee( int id )
            {
            throw new NotImplementedException();
            }

        public IEnumerable<Employee> GetAllByDepartment( Department department )
            {
            throw new NotImplementedException();
            }

        public IEnumerable<Employee> GetAllEmployee()
            {
            return _employees;
            }

        public Employee GetEmployee( int id )
            {
            return _employees.FirstOrDefault(E => E.Id == id);
            }

        public IEnumerable<Employee> GetEmployeesByDepartment( Department department )
            {
            throw new NotImplementedException();
            }

        public Employee UpdateEmployee( Employee employee )
            {
            throw new NotImplementedException();
            }
        }
    }
