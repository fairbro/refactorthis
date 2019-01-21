using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Web.Api.Core.Gateways.Repositories;
using Web.Api.Infrastructure.EntityFramework;

namespace Web.Api.Infrastructure
{
    public class Repository : IProductRepository
    {
        private readonly ApplicationDataContext _context;

        public Repository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<Web.Api.Core.Gateways.Repositories.Product> Get(Guid id)
        {
            var entity = await _context.Products.SingleOrDefaultAsync(p => p.Id == id);

            return new Web.Api.Core.Gateways.Repositories.Product
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                DeliveryPrice = entity.DeliveryPrice,
                Price = entity.Price
            };
        }
    }
}
