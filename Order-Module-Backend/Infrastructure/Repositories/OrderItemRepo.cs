using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Sql;

namespace Infrastructure.Repositories
{
    public class OrderItemRepo : GenericRepo<OrderItem, int>, IOrderItemRepo
    {
        private readonly AppDbContext _context;
        public OrderItemRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            _context = appDbContext;
        }
    }
}
