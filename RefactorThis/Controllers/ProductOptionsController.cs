using System;
using System.Threading.Tasks;
using System.Web.Http;
using Web.Api.Core.Dto.Requests.ProductOptions;
using Web.Api.Core.Interfaces;

namespace refactor_this.Controllers
{
    [RoutePrefix("productOptions")]
    public class ProductOptionsController : ApiController
    {
        private readonly IProductOptionHandler _productOptionsHandler;

        public ProductOptionsController(IProductOptionHandler productOptionsHandler)
        {
            _productOptionsHandler = productOptionsHandler;
        }

        [Route("{productId}/options")]
        [HttpGet]
        public IHttpActionResult GetProductOptions(Guid productId)
        {
            var request = new GetProductOptionsRequest { ProductId = productId };

            var response = _productOptionsHandler.Handle(request);

            return Ok(response.ProductOptions);
        }

        [Route("{productId}/options/{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetProductOption(Guid productId, Guid optionId)
        {
            var request = new GetProductOptionRequest { ProductId = productId, OptionId = optionId };

            var response = await _productOptionsHandler.Handle(request);

            if (response.ProductOption == null)
            {
                return NotFound();
            }

            return Ok(response.ProductOption);
        }

        //[Route("{productId}/options")]
        //[HttpPost]
        //public void CreateOption(Guid productId, ProductOption option)
        //{
        //    option.ProductId = productId;
        //    option.Save();
        //}

        //[Route("{productId}/options/{id}")]
        //[HttpPut]
        //public void UpdateOption(Guid id, ProductOption option)
        //{
        //    var orig = new ProductOption(id)
        //    {
        //        Name = option.Name,
        //        Description = option.Description
        //    };

        //    if (!orig.IsNew)
        //        orig.Save();
        //}

        //[Route("{productId}/options/{id}")]
        //[HttpDelete]
        //public void DeleteOption(Guid id)
        //{
        //    var opt = new ProductOption(id);
        //    opt.Delete();
        //}
    }
}
