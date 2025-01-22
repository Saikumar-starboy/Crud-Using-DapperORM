using Azure.Core;
using Employee_Dapper_Example.Dtos;
using Employee_Dapper_Example.Entities;
using Employee_Dapper_Example.Interface;

namespace Employee_Dapper_Example.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        IDepartmentRepository _repo;
        public DepartmentServices(IDepartmentRepository repo)
        {
            _repo = repo;
        }
        public async Task<int> AddDepartment(DepartmentDto deptdetail)
        {
            Department dept = new Department();
            dept.deptname = deptdetail.deptname;
            dept.deptid = deptdetail.deptid;
            dept.deptlocation = deptdetail.deptlocation;
            var insertid = await _repo.AddDepartment(dept);
            return insertid;
        }

        public async Task<bool> DeleteDepartmentById(int deptid)
        {
            await _repo.DeleteDepartmentById(deptid);
            return true;
        }

        public async Task<DepartmentDto> GetDepartmentById(int deptid)
        {
            var deptdata = await _repo.GetDepartmentById(deptid);
            DepartmentDto dto = new DepartmentDto();
            dto.deptid = deptdata.deptid;
            dto.deptname =deptdata.deptname;
            dto.deptlocation = deptdata.deptlocation;
            return dto;
        }

        public async Task<List<DepartmentDto>> GetDepartmentDetails()
        {
            List<DepartmentDto> deptlist = new List<DepartmentDto>();
            var deptdata = await _repo.GetDepartmentDetails();
            foreach(Department dept in deptdata)
            {
                DepartmentDto dto = new DepartmentDto();
                dto.deptid = dept.deptid;
                dto.deptname = dept.deptname;
                dto.deptlocation = dept.deptlocation;
                deptlist.Add(dto);
            }
            return deptlist;
        }

        public async Task<bool> UpdateDepartment(DepartmentDto deptdetail)
        {
            Department dept = new Department();
            dept.deptid = deptdetail.deptid;
            dept.deptname =deptdetail.deptname;
            dept.deptlocation = deptdetail.deptlocation;
            await _repo.UpdateDepartment(dept);
            return true;
        }
    }
}
