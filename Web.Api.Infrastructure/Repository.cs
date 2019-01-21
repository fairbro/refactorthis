using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

            return AutoMapper.Mapper.Map<Web.Api.Core.Gateways.Repositories.Product>(entity);
        }

        public async Task<IEnumerable<Web.Api.Core.Gateways.Repositories.Product>> GetAll()
        {
            var entities = await _context.Products.ToListAsync();

            return AutoMapper.Mapper.Map<IEnumerable<Web.Api.Core.Gateways.Repositories.Product>>(entities);
        }

        public async Task<IEnumerable<Web.Api.Core.Gateways.Repositories.Product>> GetAllByName(string name)
        {
            var allEntities = await _context.Products.ToListAsync();

            var filteredEntities = allEntities.Where(e => e.Name.ToLower().Contains(name.ToLower()));

            return AutoMapper.Mapper.Map<IEnumerable<Web.Api.Core.Gateways.Repositories.Product>>(filteredEntities);
        }
    }
}
