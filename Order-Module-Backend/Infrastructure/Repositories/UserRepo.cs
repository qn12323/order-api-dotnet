using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Sql;

namespace Infrastructure.Repositories
{
    public class UserRepo : GenericRepo<User, int>, IUserRepo
    {
        private readonly AppDbContext _context;
        public UserRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            _context = appDbContext;
        }
    }
}
