using System.Threading.Tasks;
using Web.Api.Core.Dto.UseCaseRequests;

namespace Web.Api.Core.Interfaces
{
    public interface IProductUseCase
    {
        Task<bool> Handle(GetProductRequest message);
    }
}
