using Employee_Dapper_Example;

namespace Employee_Dapper_Example.Interface
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task<int> AddEmployee(Employee empdetail);
        Task<bool> DeleteEmployeeById(int id);
        Task<bool> UpdateEmployee(Employee empdetail);
    }
}
