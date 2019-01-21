using System.Threading.Tasks;
using Web.Api.Core.Dto.ProductResponses;
using Web.Api.Core.Dto.UseCaseRequests;

namespace Web.Api.Core.Interfaces
{
    public interface IProductUseCases
    {
        Task<GetProductResponse> Handle(GetProductRequest message);
        Task<GetAllProductsResponse> Handle(GetAllProductsRequest message);
        Task<GetAllProductsByNameResponse> Handle(GetAllProductsByNameRequest message);
        Task<DeleteProductResponse> Handle(DeleteProductRequest message);
    }
}
