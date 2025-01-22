using Employee_Dapper_Example.Dtos;
using Employee_Dapper_Example.Entities;

namespace Employee_Dapper_Example.Interface
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetDepartmentDetails();
        Task<Department> GetDepartmentById(int deptid);
        Task<int> AddDepartment(Department deptdetail);
        Task<bool> DeleteDepartmentById(int deptid);
        Task<bool> UpdateDepartment(Department deptdetail);
    }
}
