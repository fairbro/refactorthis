using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Core.Gateways.Repositories;
using Web.Api.Infrastructure.EntityFramework;

namespace Web.Api.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDataContext _context;

        public ProductRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<Core.Gateways.Repositories.Product> Get(Guid id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(p => p.Id == id);

            return new Web.Api.Core.Gateways.Repositories.Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                DeliveryPrice = product.DeliveryPrice,
                Price = product.Price
            };
        }
    }
}
