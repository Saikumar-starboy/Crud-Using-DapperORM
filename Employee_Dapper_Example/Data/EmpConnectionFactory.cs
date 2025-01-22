using Employee_Dapper_Example.Interface;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Employee_Dapper_Example.Data
{
    public class EmpConnectionFactory : IEmpConnectionFactory
    {
        private readonly IConfiguration configuration;
        public EmpConnectionFactory(IConfiguration _configuration) 
        {
        configuration = _configuration;
        }
        public IDbConnection MidLandSqlConnectionString()
        {
            var conStr = Convert.ToString(configuration.GetSection("ConnectionStrings:MidLandSqlConnectionString").Value);
            IDbConnection con = new SqlConnection(conStr);
            return con;
        }
        
        public IDbConnection HotelManagementSqlConnectionString()
        {
            var conStr = Convert.ToString(configuration.GetSection("ConnectionStrings:HotelManagementSqlConnectionString").Value);
            IDbConnection con = new SqlConnection(conStr);
            return con;
        }
        public IDbConnection NorthwindSqlConnectionString()
        {
            var conStr = Convert.ToString(configuration.GetSection("ConnectionStrings:NorthwindSqlConnectionString").Value);
            IDbConnection con = new SqlConnection(conStr);
            return con;
        }
    }
}
