﻿using System.Collections.Generic;
using Web.Api.Core.Gateways.Repositories;

namespace Web.Api.Core.Dto.Responses.ProductOptions
{
    public class GetProductOptionsResponse
    {
        public IEnumerable<ProductOption> ProductOptions { get; set; }
    }
}
