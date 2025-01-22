using Employee_Dapper_Example.Dtos;

namespace Employee_Dapper_Example.Interface
{
    public interface IDepartmentServices
    {
        Task<List<DepartmentDto>> GetDepartmentDetails();
        Task<DepartmentDto> GetDepartmentById(int deptid);
        Task<int> AddDepartment(DepartmentDto deptdetail);
        Task<bool> DeleteDepartmentById(int deptid);
        Task<bool> UpdateDepartment(DepartmentDto deptdetail);
    }
}
