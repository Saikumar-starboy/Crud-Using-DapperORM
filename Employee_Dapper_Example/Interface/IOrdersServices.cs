using Employee_Dapper_Example.Dtos;

namespace Employee_Dapper_Example.Interface
{
    public interface IOrdersServices
    {
        Task<List<OrdersDto>> GetOrders();
        Task<int> AddOrder(OrdersDto orderDetail);
        Task<bool> UpdateOrder(OrdersDto orderDetail);
        Task<bool> DeleteOrderById(int orderid);
        Task<OrdersDto> GetOrderById(int orderid);

    }
}
