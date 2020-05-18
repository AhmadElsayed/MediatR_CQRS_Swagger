using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatR_CQRS_Swagger.Queries
{
    public class GetOrdersListQuery : IRequest<List<OrderDto>>
    {
    }
}
