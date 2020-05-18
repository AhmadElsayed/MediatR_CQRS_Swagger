using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatR_CQRS_Swagger.Queries
{
    public class OrderDto
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int Amount { set; get; }
        public double Price { set; get; }
    }
}
