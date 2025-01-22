using Employee_Dapper_Example.Dtos;
using Employee_Dapper_Example;
using Employee_Dapper_Example.Interface;

namespace Employee_Dapper_Example.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        IEmployeeRepository repository;
        public EmployeeServices(IEmployeeRepository _repository) 
        { 
            repository = _repository;
        }
        public async Task<int> AddEmployee(EmployeeDto empdetail)
        {
            Employee emp = new Employee();
            emp.empid = empdetail.empid; 
            emp.empname = empdetail.empname;
            emp.empsalary = empdetail.empsalary;
            var res = await repository.AddEmployee(emp);
            return res;
        }

        public async Task<bool> DeleteEmployeeById(int id)
        {
           await repository.DeleteEmployeeById(id);
           return true;
        }

        public async Task<List<EmployeeDto>> GetAllEmployees()
        {
           List<EmployeeDto> employees = new List<EmployeeDto>();
           var res = await repository.GetAllEmployees();
            foreach (Employee emp in res)
            {
                EmployeeDto empDto = new EmployeeDto();
                empDto.empid = emp.empid;
                empDto.empname = emp.empname;
                empDto.empsalary= emp.empsalary;
                employees.Add(empDto);
            }
            return employees;
        }

        public async Task<EmployeeDto> GetEmployeeById(int id)
        {
          
           var employee = await repository.GetEmployeeById(id);
            EmployeeDto emp = new EmployeeDto();
            emp.empid = employee.empid;
            emp.empname = employee.empname;
            emp.empsalary = employee.empsalary;
            return emp;
        }

        public async Task<bool> UpdateEmployee(EmployeeDto empdetail)
        {
            Employee emp = new Employee();
            emp.empid = empdetail.empid;
            emp.empsalary = empdetail.empsalary; 
            emp.empname= empdetail.empname;
            await repository.UpdateEmployee(emp);
            return true;
        }
    }
}
