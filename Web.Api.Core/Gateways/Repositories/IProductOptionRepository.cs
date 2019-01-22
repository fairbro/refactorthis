using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Api.Core.Gateways.Repositories
{
    public interface IProductOptionRepository
    {
        Task<IEnumerable<ProductOption>> Get(Guid productId);
        //Task<IEnumerable<Product>> GetAll();
        //Task<IEnumerable<Product>> GetAllByName(string name);
        //Task<bool> Delete(Guid id);
        //Task<Product> Create(Product product);
        //Task<bool> Update(Product product);
    }
}
