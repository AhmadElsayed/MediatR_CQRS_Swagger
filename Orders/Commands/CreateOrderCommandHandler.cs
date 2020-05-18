using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR_CQRS_Swagger.Orders.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, string>
    {
        public async Task<string> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            return $"Ordering {request.Amount} items of the product ${request.Name} with ${request.Id} in a total cost of ${request.Price * request.Amount}";
        }
    }
}
