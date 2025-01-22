using Employee_Dapper_Example.Dtos;

namespace Employee_Dapper_Example.Interface
{
    public interface IEmployeeServices
    {
        Task<List<EmployeeDto>> GetAllEmployees();
        Task<EmployeeDto> GetEmployeeById(int id);
        Task<int> AddEmployee(EmployeeDto empdetail);
        Task<bool> DeleteEmployeeById(int id);
        Task<bool> UpdateEmployee(EmployeeDto empdetail);
    }
}
