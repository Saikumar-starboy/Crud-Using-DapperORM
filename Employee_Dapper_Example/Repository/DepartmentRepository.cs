using Dapper;
using Employee_Dapper_Example.Dtos;
using Employee_Dapper_Example.Entities;
using Employee_Dapper_Example.Interface;
using Employee_Dapper_Example.utils;
using System.Data;

namespace Employee_Dapper_Example.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        IEmpConnectionFactory _connectionFactory;
        public DepartmentRepository(IEmpConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<int> AddDepartment(Department deptdetail)
        {
            using (IDbConnection con = _connectionFactory.NorthwindSqlConnectionString())
            {
                var p = new DynamicParameters();
                p.Add("@deptname",deptdetail.deptname);
                p.Add("@deptlocation", deptdetail.deptlocation);
                p.Add("@insertedvalue", DbType.Int32, direction: ParameterDirection.Output);
                await con.ExecuteScalarAsync<int>(StoredProcedureNames.AddDepartment, p, commandType: CommandType.StoredProcedure);
                int insertedid = p.Get<int>("@insertedvalue");
                return insertedid;
            }
        }

        public async Task<bool> DeleteDepartmentById(int deptid)
        {
            using(IDbConnection con = _connectionFactory.NorthwindSqlConnectionString())
            {
                var p = new DynamicParameters();
                p.Add("@deptid", deptid);
                await con.ExecuteScalarAsync(StoredProcedureNames.DeleteDepartment,p, commandType: CommandType.StoredProcedure);
                return true;
            }
        }

        public async Task<Department> GetDepartmentById(int deptid)
        {
            Department dept;
            using(IDbConnection con = _connectionFactory.NorthwindSqlConnectionString())
            {
                var p = new DynamicParameters();
                p.Add("@deptid", deptid);
                var res = await con.QueryAsync<Department>(StoredProcedureNames.GetDepartmentByDeptId, p, commandType: CommandType.StoredProcedure);
                dept = res.FirstOrDefault();
                return dept;
            }
        }

        public async Task<List<Department>> GetDepartmentDetails()
        {
            List<Department> depts;
            using(IDbConnection con = _connectionFactory.NorthwindSqlConnectionString())
            {
                var res = await con.QueryAsync<Department>(StoredProcedureNames.GetDepartment, commandType: CommandType.StoredProcedure);
                depts = res.ToList();
                return depts;
            }
        }

        public async Task<bool> UpdateDepartment(Department deptdetail)
        {
            using(IDbConnection con = _connectionFactory.NorthwindSqlConnectionString())
            {
                var p = new DynamicParameters();
                p.Add("@deptid",deptdetail.deptid);
                p.Add("@deptname",deptdetail.deptname);
                p.Add("@deptlocation",deptdetail.deptlocation);
                await con.ExecuteReaderAsync(StoredProcedureNames.UpdateDepartment, p, commandType: CommandType.StoredProcedure);
                return true;
            }
        }
    }
}
