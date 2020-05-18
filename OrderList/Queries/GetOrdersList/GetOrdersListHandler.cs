using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR_CQRS_Swagger.Queries.GetAllOrders
{
    public class GetOrdersListHandler : IRequestHandler<GetOrdersListQuery, List<OrderDto>>
    {
        List<OrderDto> _data;

        public GetOrdersListHandler() {
            FillData();
        }

        private void FillData()
        {
            _data = new List<OrderDto>();
            _data.AddRange(
                new OrderDto[] { 
                    new OrderDto(){ Id = 1, Name = "PC", Amount = 1, Price = 120.3 },
                    new OrderDto(){ Id = 2, Name = "GIGABYTE RTX", Amount = 1, Price = 910 },
                    new OrderDto(){ Id = 3, Name = "Motherboard", Amount = 1, Price = 19.2 },
                    new OrderDto(){ Id = 4, Name = "Mouse", Amount = 3, Price = 6.4 },
                    new OrderDto(){ Id = 5, Name = "Keyboard", Amount = 2, Price = 14.3 },
                }
                );
        }

        public async Task<List<OrderDto>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            return _data;
        }
    }
}
