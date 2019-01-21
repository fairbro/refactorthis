using System.Threading.Tasks;
using Web.Api.Core.Dto.ProductResponses;
using Web.Api.Core.Dto.UseCaseRequests;

namespace Web.Api.Core.Interfaces
{
    public interface IGetProductUseCase
    {
        Task<GetProductResponse> Handle(GetProductRequest message);
        Task<GetAllProductsResponse> Handle(GetAllProductsRequest message);
    }
}
