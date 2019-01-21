using System.Threading.Tasks;
using Web.Api.Core.Dto.ProductResponses;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Gateways.Repositories;
using Web.Api.Core.Interfaces;

namespace Web.Api.Core.UseCases
{
    public class GetProductUseCase : IGetProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public GetProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<GetProductResponse> Handle(GetProductRequest message)
        {
            var product = await _productRepository.Get(message.Id);

            return new GetProductResponse { Product = product };
        }

        public async Task<GetAllProductsResponse> Handle(GetAllProductsRequest message)
        {
            var products = await _productRepository.GetAll();

            return new GetAllProductsResponse { Products = products };
        }
    }
}
