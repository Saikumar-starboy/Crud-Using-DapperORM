using Employee_Dapper_Example.Dtos;
using Employee_Dapper_Example.Entities;

namespace Employee_Dapper_Example.Interface
{
    public interface IOrdersRepository
    {
        Task<List<Orders>> GetOrders();
        Task<int> AddOrder(Orders orderDetail);
        Task<bool> UpdateOrder(Orders orderDetail);
        Task<bool> DeleteOrderById(int orderid);
        Task<Orders> GetOrderById(int orderid);
    }
}
