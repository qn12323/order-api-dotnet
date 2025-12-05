using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Sql;

namespace Infrastructure.Repositories
{
    public class OrderCancelRepo : GenericRepo<OrderCancellation, int>, IOrderCancelRepo
    {
        private readonly AppDbContext _context;
        public OrderCancelRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            _context = appDbContext;
        }
    }
}
