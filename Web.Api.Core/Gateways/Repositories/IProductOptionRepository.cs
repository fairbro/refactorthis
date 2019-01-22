using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Api.Core.Gateways.Repositories
{
    public interface IProductOptionRepository
    {
        IEnumerable<ProductOption> Get(Guid productId);
        Task<ProductOption> Get(Guid productId, Guid optionId);
    }
}
