using System.Collections.Generic;
using Web.Api.Core.Gateways.Repositories;

namespace Web.Api.Core.Dto.Responses.Products
{
    public class GetAllProductsByNameResponse
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
