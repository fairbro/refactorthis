using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Api.Core.Gateways.Repositories
{
    public interface IProductRepository
    {
        Task<Product> Get(Guid id);
        Task<IEnumerable<Product>> GetAll();
    }
}
