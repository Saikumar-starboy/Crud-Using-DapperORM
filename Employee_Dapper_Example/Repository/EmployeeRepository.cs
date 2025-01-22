using Dapper;
using Employee_Dapper_Example.Interface;
using Employee_Dapper_Example.utils;
using System.Data;

namespace Employee_Dapper_Example.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        IEmpConnectionFactory connectionFactory;
        public EmployeeRepository(IEmpConnectionFactory _connectionFactory) {
            connectionFactory = _connectionFactory;
        }
        public async Task<int> AddEmployee(Employee empdetail)
        {
            using (IDbConnection con = connectionFactory.HotelManagementSqlConnectionString())
            {
                var p = new DynamicParameters();
                p.Add("@empname", empdetail.empname);
                p.Add("@empsalary", empdetail.empsalary);
                p.Add("@new_identity", DbType.Int32, direction: ParameterDirection.Output); // Correct parameter name

                await con.ExecuteAsync(StoredProcedureNames.AddEmployee, p, commandType: CommandType.StoredProcedure); // Use ExecuteAsync

                int insertedId = p.Get<int>("@new_identity");

                return insertedId;
            }
        }

        public async Task<bool> DeleteEmployeeById(int id)
        {
            using(IDbConnection con = connectionFactory.HotelManagementSqlConnectionString())
            {
                var p = new DynamicParameters();
                p.Add("@id", id);
                await con.ExecuteScalarAsync(StoredProcedureNames.DeleteEmployee,p,commandType:CommandType.StoredProcedure);
                return true;
            }
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            List<Employee> list;
            using(IDbConnection con = connectionFactory.HotelManagementSqlConnectionString())
            {
                var queryresult = await con.QueryAsync<Employee>(StoredProcedureNames.GetAllEmployees, CommandType.StoredProcedure);
                list = queryresult.ToList();
                return list;
            }
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            Employee emp;
            using(IDbConnection con = connectionFactory.HotelManagementSqlConnectionString())
            {
                var p = new DynamicParameters();
                p.Add("@id", id);
                var result = await con.QueryAsync<Employee>(StoredProcedureNames.GetEmployeeById,p,commandType:CommandType.StoredProcedure);
                emp = result.FirstOrDefault();
                return emp;
            }
        }

        public async Task<bool> UpdateEmployee(Employee empdetail)
        {
            using(IDbConnection con = connectionFactory.HotelManagementSqlConnectionString())
            {
                var p = new DynamicParameters();
                p.Add("@empid", empdetail.empid);
                p.Add("@empname", empdetail.empname);
                p.Add("empsalary",empdetail.empsalary);
                await con.ExecuteReaderAsync(StoredProcedureNames.UpdateEmployee, p,commandType:CommandType.StoredProcedure);
                return true;
            }
        }
    }
}
