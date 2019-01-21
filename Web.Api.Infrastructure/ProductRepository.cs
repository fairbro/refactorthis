using System;
using System.Collections.Generic;
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
            var entity = await _context.Products.SingleOrDefaultAsync(p => p.Id == id);

            return AutoMapper.Mapper.Map<Core.Gateways.Repositories.Product>(entity);
        }

        public async Task<IEnumerable<Core.Gateways.Repositories.Product>> GetAll()
        {
            var entities = await _context.Products.ToListAsync();

            return AutoMapper.Mapper.Map<IEnumerable<Core.Gateways.Repositories.Product>>(entities);
        }

        public async Task<IEnumerable<Core.Gateways.Repositories.Product>> GetAllByName(string name)
        {
            var allEntities = await _context.Products.ToListAsync();

            var filteredEntities = allEntities.Where(e => e.Name.ToLower().Contains(name.ToLower()));

            return AutoMapper.Mapper.Map<IEnumerable<Core.Gateways.Repositories.Product>>(filteredEntities);
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.Products.SingleOrDefaultAsync(p => p.Id == id);

            if (entity == null)
                return false;

            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Core.Gateways.Repositories.Product> Create(Core.Gateways.Repositories.Product product)
        {
            var entity = AutoMapper.Mapper.Map<EntityFramework.Product>(product);
            entity.Id = Guid.NewGuid();
            //TODO: some validation logic.
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();

            var createdEntity = AutoMapper.Mapper.Map<Core.Gateways.Repositories.Product>(entity);

            return createdEntity;
        }
    }
}
