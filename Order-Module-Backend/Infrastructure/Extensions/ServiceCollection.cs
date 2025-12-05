using Domain.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.Sql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("OrderSystemDB");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            services.RegisterServices();
            return services;
        }

        private static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepo<,>), typeof(GenericRepo<,>));
            services.AddScoped<INotificationRepo, NotificationRepo>();
            services.AddScoped<IOrderCancelRepo, OrderCancelRepo>();
            services.AddScoped<IOrderItemRepo, OrderItemRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<IOrderReturnRepo, OrderReturnRepo>();
            services.AddScoped<IPaymentRepo, PaymentRepo>();
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<IUserRepo, UserRepo>();

            return services;
        }
    }
}
