using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Sql;

namespace Infrastructure.Repositories
{
    public class PaymentRepo : GenericRepo<Payment, int>, IPaymentRepo
    {
        private readonly AppDbContext _context;
        public PaymentRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            _context = appDbContext;
        }
    }
}
