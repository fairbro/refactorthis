using System;

namespace Web.Api.Core.Dto.Requests.ProductOptions
{
    public class GetProductOptionRequest
    {
        public Guid ProductId { get; set; }
        public Guid OptionId { get; set; }
    }
}
