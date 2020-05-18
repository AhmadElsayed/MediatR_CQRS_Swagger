using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR_CQRS_Swagger.Queries.GetOrder
{
    public class GetOrderHandler : IRequestHandler<GetOrderQuery, OrderDto>
    {
        OrderDto _order;

        public GetOrderHandler() {
            FillData();
        }

        private void FillData()
        {
            _order = new OrderDto(){ Id = 1, Name = "PC", Amount = 1, Price = 120.3 };
        }

        public async Task<OrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            _order.Id = request.Id;
            return _order;
        }
    }
}
