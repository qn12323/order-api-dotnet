using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Sql;

namespace Infrastructure.Repositories
{
    public class OrderRepo : GenericRepo<Order, string>, IOrderRepo
    {
        private readonly AppDbContext _context;
        public OrderRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            _context = appDbContext;
        }
    }
}
