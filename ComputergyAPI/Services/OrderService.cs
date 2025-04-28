using ComputergyAPI.Contexts;
using ComputergyAPI.DTOs.Order;
using ComputergyAPI.Entites;
using ComputergyAPI.Interfaces;

namespace ComputergyAPI.Services
{
    public class OrderService : IOrder
    {
        private readonly ComputergyDbContext _computergyDbContext;
        public OrderService(ComputergyDbContext computergyDbContext)
        {
            _computergyDbContext = computergyDbContext;
        }
        public async Task<string> CreateUpdateOrder(CreateUpdateOrderInputDTO input)
        {
            
                if (input.OrderID != null) // Update Order
                {
                    var Order = await _computergyDbContext.Orders.FindAsync(input.OrderID.Value);
                    if (Order == null)
                        return "Order not found";

                    Order.CartID = input.CartID;
                    Order.Note = input.Note;

                    _computergyDbContext.Orders.Update(Order);
                    await _computergyDbContext.SaveChangesAsync();
                    return "Order updated successfully";
                }
                else // Create Order
                {
                    var newOrder = new Order
                    {
                        PersonID = input.PersonID,
                        CartID = input.CartID,
                        Note = input.Note,
                        OrderDate = DateTime.UtcNow,
                        OrderStatus = "Pending",
                        TotalPrice = 0,
                    };
                    _computergyDbContext.Orders.Add(newOrder);
                    await _computergyDbContext.SaveChangesAsync();
                    return "Order created successfully";
                }
            
            
        }

        public async Task<string> DeleteOrder(int id)
        {
            var existing = await _computergyDbContext.Orders.FindAsync(id);
            if (existing is null)
                return "Order not found";

            _computergyDbContext.Orders.Remove(existing);
            await _computergyDbContext.SaveChangesAsync();
            return "Order deleted successfully";
        }

        public Task<OrderDTO> GetAllOrder()
        {
            throw new NotImplementedException();
        }

        public Task<OrderDTO?> GetOneOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDTO> SearchOrder(SearchOrderInputDTO input)
        {
            throw new NotImplementedException();
        }
    }
}
