using System;
using System.Threading.Tasks;
using System.Web.Http;
using Web.Api.Core.Dto.Requests.Products;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Gateways.Repositories;
using Web.Api.Core.Interfaces;

namespace refactor_this.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : ApiController
    {
        private readonly IProductHandler _productHandler;

        public ProductsController(IProductHandler productHandler)
        {
            _productHandler = productHandler;
        }

        [Route]
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var request = new GetAllProductsRequest();

            var response = await _productHandler.Handle(request);

            return Ok(response.Products);
        }

        [Route]
        [HttpGet]
        public async Task<IHttpActionResult> SearchByName(string name)
        {
            var request = new GetAllProductsByNameRequest { Name = name };

            var response = await _productHandler.Handle(request);

            return Ok(response.Products);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetProduct(Guid id)
        {
            var request = new GetProductRequest { Id = id };

            var response = await _productHandler.Handle(request);

            if (response.Product == null)
            {
                return NotFound();
            }

            return Ok(response.Product);
        }

        [Route]
        [HttpPost]
        public async Task<IHttpActionResult> Create(Product product)
        {
            //TODO: some validation logic.
            var request = new CreateProductRequest { Product = product };

            var response = await _productHandler.Handle(request);

            if (response.Product.Id == null)
                return BadRequest();

            return Created(Request.RequestUri.AbsoluteUri + response.Product.Id, response.Product);
        }

        [Route]
        [HttpPut]
        public async Task<IHttpActionResult> Update(Product product)
        {
            //TODO: some validation logic.
            var request = new UpdateProductRequest { Product = product };

            var response = await _productHandler.Handle(request);

            if (!response.Success)
                return BadRequest();

            return Ok();
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            var request = new DeleteProductRequest { Id = id };

            var response = await _productHandler.Handle(request);

            if (!response.Success)
                return NotFound();

            return Ok(true);
        }
    }
}
