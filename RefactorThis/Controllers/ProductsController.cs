using System;
using System.Threading.Tasks;
using System.Web.Http;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Gateways.Repositories;
using Web.Api.Core.Interfaces;

namespace refactor_this.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : ApiController
    {
        private readonly IProductUseCases _productUseCase;

        public ProductsController(IProductUseCases productUseCase)
        {
            _productUseCase = productUseCase;
        }

        [Route]
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var request = new GetAllProductsRequest();

            var response = await _productUseCase.Handle(request);

            return Ok(response.Products);
        }

        [Route]
        [HttpGet]
        public async Task<IHttpActionResult> SearchByName(string name)
        {
            var request = new GetAllProductsByNameRequest { Name = name };

            var response = await _productUseCase.Handle(request);

            return Ok(response.Products);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetProduct(Guid id)
        {
            var request = new GetProductRequest { Id = id };

            var response = await _productUseCase.Handle(request);

            if (response.Product == null)
                return NotFound();

            return Ok(response.Product);
        }

        [Route]
        [HttpPost]
        public async Task<IHttpActionResult> Create(Product product)
        {
            //TODO: some validation logic.
            var request = new CreateProductRequest { Product = product };

            var response = await _productUseCase.Handle(request);

            if (response.Product.Id == null)
                return BadRequest();

            return Created(Request.RequestUri.AbsoluteUri + response.Product.Id, response.Product);
        }

        //[Route("{id}")]
        //[HttpPut]
        //public void Update(Guid id, Models.Product product)
        //{
        //    var orig = new Models.Product(id)
        //    {
        //        Name = product.Name,
        //        Description = product.Description,
        //        Price = product.Price,
        //        DeliveryPrice = product.DeliveryPrice
        //    };

        //    if (!orig.IsNew)
        //        orig.Save();
        //}

        [Route("{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            var request = new DeleteProductRequest { Id = id };

            var response = await _productUseCase.Handle(request);

            if (!response.Success)
                return NotFound();

            return Ok(true);
        }

        //[Route("{productId}/options")]
        //[HttpGet]
        //public ProductOptions GetOptions(Guid productId)
        //{
        //    return new ProductOptions(productId);
        //}

        //[Route("{productId}/options/{id}")]
        //[HttpGet]
        //public ProductOption GetOption(Guid productId, Guid id)
        //{
        //    var option = new ProductOption(id);
        //    if (option.IsNew)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);

        //    return option;
        //}

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
