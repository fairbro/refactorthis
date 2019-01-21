using System.Threading.Tasks;
using Web.Api.Core.Dto.Requests.Products;
using Web.Api.Core.Dto.Responses.Products;
using Web.Api.Core.Dto.UseCaseRequests;

namespace Web.Api.Core.Interfaces
{
    public interface IProductHandler
    {
        Task<GetProductResponse> Handle(GetProductRequest message);
        Task<GetAllProductsResponse> Handle(GetAllProductsRequest message);
        Task<GetAllProductsByNameResponse> Handle(GetAllProductsByNameRequest message);
        Task<DeleteProductResponse> Handle(DeleteProductRequest message);
        Task<CreateProductResponse> Handle(CreateProductRequest message);
        Task<UpdateProductResponse> Handle(UpdateProductRequest message);
    }
}
