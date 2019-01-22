using System.Threading.Tasks;
using Web.Api.Core.Dto.Requests.ProductOptions;
using Web.Api.Core.Dto.Responses.ProductOptions;

namespace Web.Api.Core.Interfaces
{
    public interface IProductOptionHandler
    {
        Task<GetProductOptionsResponse> Handle(GetProductOptionsRequest message);
        //Task<GetAllProductOptionsResponse> Handle(GetAllProductOptionsRequest message);
        //Task<GetAllProductOptionsByNameResponse> Handle(GetAllProductOptionsByNameRequest message);
        //Task<DeleteProductOptionResponse> Handle(DeleteProductOptionRequest message);
        //Task<CreateProductOptionResponse> Handle(CreateProductOptionRequest message);
        //Task<UpdateProductOptionResponse> Handle(UpdateProductOptionRequest message);
    }
}
