using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Gateways.Repositories;
using Web.Api.Core.Interfaces;

namespace Web.Api.Core.UseCases
{
    public class ProductUseCase : IProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public ProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(GetProductRequest message)
        {
            var response = await _productRepository.Get(message.Id);

            return false;
        }
    }
}
