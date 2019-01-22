using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Core.Gateways.Repositories;
using Web.Api.Infrastructure.EntityFramework;

namespace Web.Api.Infrastructure
{
    public class ProductOptionRepository : IProductOptionRepository
    {
        private readonly ApplicationDataContext _context;

        public ProductOptionRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public IEnumerable<Core.Gateways.Repositories.ProductOption> Get(Guid productId)
        {
            var productOptions = _context.ProductOptions.Where(p => p.ProductId == productId);

            return AutoMapper.Mapper.Map<IEnumerable<Core.Gateways.Repositories.ProductOption>>(productOptions);
        }

        public async Task<Core.Gateways.Repositories.ProductOption> Get(Guid productId, Guid optionId)
        {
            var productOpton = await _context.ProductOptions.SingleOrDefaultAsync(p => p.ProductId == productId && p.Id == optionId);
            
            return AutoMapper.Mapper.Map<Core.Gateways.Repositories.ProductOption>(productOpton);
        }
    }
}
