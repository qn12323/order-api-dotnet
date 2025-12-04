using Application.Requests.Orders;
using Domain.Constants.Status;
using Domain.Definitions.Messages;
using Domain.Definitions.Methods;
using Domain.Definitions.Results;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.Orders
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderRequest, Response<string>>
    {
        private readonly IOrderRepo _orderRepo;
        private readonly IUserRepo _userRepo;
        private readonly IProductRepo _productRepo;
        public CreateOrderHandler(IOrderRepo orderRepo, IUserRepo userRepo, IProductRepo productRepo)
        {
            _orderRepo = orderRepo; 
            _userRepo = userRepo;
            _productRepo = productRepo;
        }

        public async Task<Response<string>> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepo.GetByIdAsync(request.UserId);
            if (user == null)
                return Response<string>.Create(StatusCode.NotFound, string.Format(CommonMessage.NotFound, ""));

            var orderCode = GenerateOrderCode.GenerateCode();

            #region Check Quantity
            if (request.OrderItems == null || !request.OrderItems.Any())
                return Response<string>.Create(StatusCode.BadRequest, string.Format(CommonMessage.InvalidData, ""));

            foreach (var item in request.OrderItems)
            {
                var product = await _productRepo.GetByIdAsync(item.ProductId);

                if (product == null)
                    return Response<string>.Create(StatusCode.NotFound, string.Format(CommonMessage.NotFound, ""));

                if (item.Quantity <= 0 || item.Quantity > product?.QuantityStock)
                    return Response<string>.Create(StatusCode.BadRequest, string.Format(CommonMessage.InvalidData, ""));
            }
            #endregion

            var items = request.OrderItems.Select(i => new OrderItem
            {
                OrderId = orderCode,
                ProductId = i.ProductId,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice,
                TotalPrice = i.Quantity * i.UnitPrice,
            }).ToList();

            var totalAmount = items.Sum(i => i.TotalPrice);

            var order = new Order
            {
                Id = orderCode,
                UserId = request.UserId,
                OrderStatus = OrderStatus.Pending.ToString(),
                TotalAmount = totalAmount,
                PaymentStatus = PaymentStatus.Unpaid.ToString(),
                ShippingAddress = request.ShippingAddress,
                CreatedAt = DateTime.UtcNow,
                Items = items
            };

            await _orderRepo.Add(order);

            return Response<string>.Create(StatusCode.Created, string.Format(CommonMessage.AddSuccess, ""), orderCode);
        }
    }
}
