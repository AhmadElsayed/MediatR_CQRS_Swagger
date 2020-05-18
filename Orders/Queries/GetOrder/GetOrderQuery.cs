using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatR_CQRS_Swagger.Queries.GetOrder
{
    public class GetOrderQuery : IRequest<OrderDto>
    {
        public int Id { set; get; }

        public GetOrderQuery(int id)
        {
            Id = id;
        }
    }
}
