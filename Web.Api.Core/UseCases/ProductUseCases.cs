using System.Threading.Tasks;
using Web.Api.Core.Dto.Requests.Products;
using Web.Api.Core.Dto.Responses.Products;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Gateways.Repositories;
using Web.Api.Core.Interfaces;

namespace Web.Api.Core.UseCases
{
    public class ProductUseCases : IProductHandler
    {
        private readonly IProductRepository _productRepository;

        public ProductUseCases(IProductRepository productRepository)
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

        public async Task<GetAllProductsByNameResponse> Handle(GetAllProductsByNameRequest message)
        {
            var products = await _productRepository.GetAllByName(message.Name);

            return new GetAllProductsByNameResponse { Products = products };
        }

        public async Task<DeleteProductResponse> Handle(DeleteProductRequest message)
        {
            var result = await _productRepository.Delete(message.Id);

            return new DeleteProductResponse { Success = result ? true : false };
        }

        public async Task<CreateProductResponse> Handle(CreateProductRequest message)
        {
            var product = await _productRepository.Create(message.Product);

            return new CreateProductResponse
            {
                Product = product
            };
        }

        public async Task<UpdateProductResponse> Handle(UpdateProductRequest message)
        {
            var result = await _productRepository.Update(message.Product);

            return new UpdateProductResponse
            {
                Success = result
            };
        }
    }
}
