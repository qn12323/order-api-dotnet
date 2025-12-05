using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Sql;

namespace Infrastructure.Repositories
{
    public class NotificationRepo : GenericRepo<Notification, int>, INotificationRepo
    {
        private readonly AppDbContext _context;
        public NotificationRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            _context = appDbContext;
        }
    }
}
