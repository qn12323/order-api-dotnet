using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Sql;

namespace Infrastructure.Repositories
{
    public class ProductRepo : GenericRepo<Product, int>, IProductRepo
    {
        private readonly AppDbContext _context;
        public ProductRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            _context = appDbContext;
        }
    }
}
