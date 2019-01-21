using System.Collections.Generic;
using Web.Api.Core.Gateways.Repositories;

namespace Web.Api.Core.Dto.ProductResponses
{
    public class GetAllProductsResponse
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
