using System.Threading.Tasks;
using Web.Api.Core.Dto.ProductResponses;
using Web.Api.Core.Dto.UseCaseRequests;

namespace Web.Api.Core.Interfaces
{
    public interface IProductUseCase
    {
        Task<GetProductResponse> Handle(GetProductRequest message);
    }
}
