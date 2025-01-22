using Dapper;
using Employee_Dapper_Example.Entities;
using Employee_Dapper_Example.Interface;
using Employee_Dapper_Example.utils;
using System.Data;

namespace Employee_Dapper_Example.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        IEmpConnectionFactory _connectionFactory;
        public OrdersRepository(IEmpConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<int> AddOrder(Orders orderDetail)
        {
            using(IDbConnection con = _connectionFactory.MidLandSqlConnectionString())
            {
                var p = new DynamicParameters();
                p.Add("@ordername", orderDetail.ordername);
                p.Add("orderlocation", orderDetail.orderlocation);
                p.Add("insertedvalue",DbType.Int32,direction:ParameterDirection.InputOutput);
                await con.ExecuteScalarAsync<int>(StoredProcedureNames.AddOrder, p,commandType: CommandType.StoredProcedure);
                int inserterdid = p.Get<int>("@insertedvalue");
                return inserterdid;
            }
        }

        public async Task<bool> DeleteOrderById(int orderid)
        {
            using(IDbConnection con = _connectionFactory.MidLandSqlConnectionString())
            {
                var p = new DynamicParameters();
                p.Add("@orderid", orderid);
                await con.ExecuteScalarAsync(StoredProcedureNames.DeleteOrder,p,commandType: CommandType.StoredProcedure);
                return true;
            }
        }

        public async Task<Orders> GetOrderById(int orderid)
        {
            Orders order;
            using(IDbConnection con = _connectionFactory.MidLandSqlConnectionString())
            {
                var p = new DynamicParameters();
                p.Add("@orderid", orderid);
                var res = await con.QueryAsync<Orders>(StoredProcedureNames.GetOrderById,p,commandType:CommandType.StoredProcedure);
                order = res.FirstOrDefault();
                return order;
            }
        }

        public async Task<List<Orders>> GetOrders()
        {
            List<Orders> res;
            using(IDbConnection con = _connectionFactory.MidLandSqlConnectionString())
            {
                var queryresult = await con.QueryAsync<Orders>(StoredProcedureNames.GetOrder,commandType:CommandType.StoredProcedure);
                res = queryresult.ToList();
                return res;
            }
        }

        public async Task<bool> UpdateOrder(Orders orderDetail)
        {
            using (IDbConnection con = _connectionFactory.MidLandSqlConnectionString()) {
                var p = new DynamicParameters();
                p.Add("@orderid", orderDetail.orderid);
                p.Add("@ordername", orderDetail.ordername);
                p.Add("orderlocation", orderDetail.orderlocation);
                await con.ExecuteReaderAsync(StoredProcedureNames.UpdateOrder,p,commandType:CommandType.StoredProcedure);
                return true;
            }
        }
    }
}
