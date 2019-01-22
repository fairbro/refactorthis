using System.Threading.Tasks;
using Web.Api.Core.Dto.Requests.ProductOptions;
using Web.Api.Core.Dto.Responses.ProductOptions;

namespace Web.Api.Core.Interfaces
{
    public interface IProductOptionHandler
    {
        GetProductOptionsResponse Handle(GetProductOptionsRequest request);
        Task<GetProductOptionResponse> Handle(GetProductOptionRequest request);
    }
}
