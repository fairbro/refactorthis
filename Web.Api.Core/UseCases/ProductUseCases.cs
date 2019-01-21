﻿using System.Threading.Tasks;
using Web.Api.Core.Dto.ProductResponses;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Gateways.Repositories;
using Web.Api.Core.Interfaces;

namespace Web.Api.Core.UseCases
{
    public class ProductUseCases : IProductUseCases
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
    }
}
