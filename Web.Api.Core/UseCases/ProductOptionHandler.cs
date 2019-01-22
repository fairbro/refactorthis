using System.Threading.Tasks;
using Web.Api.Core.Dto.Requests.ProductOptions;
using Web.Api.Core.Dto.Responses.ProductOptions;
using Web.Api.Core.Gateways.Repositories;
using Web.Api.Core.Interfaces;

namespace Web.Api.Core.UseCases
{
    public class ProductOptionHandler : IProductOptionHandler
    {
        private readonly IProductOptionRepository _productOptionRepository;

        public ProductOptionHandler(IProductOptionRepository productOptionRepository)
        {
            _productOptionRepository = productOptionRepository;
        }

        public GetProductOptionsResponse Handle(GetProductOptionsRequest request)
        {
            var productOptions = _productOptionRepository.Get(request.ProductId);

            return new GetProductOptionsResponse { ProductOptions = productOptions };
        }

        public async Task<GetProductOptionResponse> Handle(GetProductOptionRequest request)
        {
            var productOption = await _productOptionRepository.Get(request.ProductId, request.OptionId);

            return new GetProductOptionResponse { ProductOption = productOption };
        }


    }
}
