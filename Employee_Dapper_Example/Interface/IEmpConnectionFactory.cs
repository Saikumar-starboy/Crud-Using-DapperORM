using System.Data;

namespace Employee_Dapper_Example.Interface
{
    public interface IEmpConnectionFactory
    {
        IDbConnection MidLandSqlConnectionString();
        IDbConnection HotelManagementSqlConnectionString();
        IDbConnection NorthwindSqlConnectionString();

    }
}
