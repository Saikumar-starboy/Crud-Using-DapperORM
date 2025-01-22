using Employee_Dapper_Example.Dtos;
using Employee_Dapper_Example.Entities;
using Employee_Dapper_Example.Interface;

namespace Employee_Dapper_Example.Services
{
    public class OrdersServices : IOrdersServices
    {
        private readonly IOrdersRepository _orderepository;
        public OrdersServices(IOrdersRepository orderepository)
        {
            _orderepository = orderepository;
        }
        public async Task<int> AddOrder(OrdersDto orderDetail)
        {
            Orders order = new Orders();
            order.orderid = orderDetail.orderid;
            if (orderDetail?.Flag == "Hyderabad")
            {
                order.ordername = orderDetail.ordername + '-' + orderDetail.orderlocation;
            } 
            else
            {
                order.ordername = orderDetail.ordername;
            }

            order.orderlocation = orderDetail.orderlocation;
            var res = await _orderepository.AddOrder(order);
            return res;
        }

        public async Task<bool> DeleteOrderById(int orderid)
        {
            await _orderepository.DeleteOrderById(orderid);
            return true;
        }

        public async Task<OrdersDto> GetOrderById(int orderid)
        {
            var res = await _orderepository.GetOrderById(orderid);
            OrdersDto dto = new OrdersDto();
            dto.orderid = res.orderid;
            dto.ordername = res.ordername ;
            dto.orderlocation = res.orderlocation;
            return dto;
        }

        public async Task<List<OrdersDto>> GetOrders()
        {
            List<OrdersDto> ordersList = new List<OrdersDto>();
            var res = await _orderepository.GetOrders();
            foreach(Orders order in res)
            {
                OrdersDto ordersDto = new OrdersDto();
                ordersDto.orderid = order.orderid;
                ordersDto.ordername = order.ordername;
                ordersDto.orderlocation = order.orderlocation;
                ordersList.Add(ordersDto);
            }
            return ordersList;
        }

        public async Task<bool> UpdateOrder(OrdersDto orderDetail)
        {
            Orders order = new Orders();
            order.orderid = orderDetail.orderid;
            order.ordername = orderDetail.ordername;
            order.orderlocation = orderDetail.orderlocation;
            await _orderepository.UpdateOrder(order);
                return true;
        }
    }
}
