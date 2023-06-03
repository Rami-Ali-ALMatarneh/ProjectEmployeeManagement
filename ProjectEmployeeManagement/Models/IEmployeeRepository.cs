namespace ProjectEmployeeManagement.Models
    {
    public interface IEmployeeRepository
        {
        public Employee GetEmployee( int id );  //get Employee
        public IEnumerable<Employee> GetAllEmployee(); //GetAllEmployee
        public Employee AddEmployee( Employee employee );
        public Employee UpdateEmployee( Employee employee );
        public Employee DeleteEmployee( int id );
        public IEnumerable<Employee> GetEmployeesByDepartment( Department department );
        }
    }
