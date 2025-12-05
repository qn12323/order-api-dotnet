using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Sql;

namespace Infrastructure.Repositories
{
    public class OrderReturnRepo : GenericRepo<OrderReturn, int>, IOrderReturnRepo
    {
        private readonly AppDbContext _context;
        public OrderReturnRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            _context = appDbContext;
        }
    }
}
