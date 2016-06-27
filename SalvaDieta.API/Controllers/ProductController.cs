using SalvaDieta.Domain.Commands.ProductCommands;
using SalvaDieta.Domain.Services;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SalvaDieta.API.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductApplicationService _service;

        public ProductController(IProductApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        //[Authorize]
        [Route("api/products")]
        public Task<HttpResponseMessage> Get()
        {
            var products = _service.Get();
            return CreateResponse(HttpStatusCode.OK, products);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/product/{id}")]
        public Task<HttpResponseMessage> Get(int id)
        {
            var products = _service.Get(id);
            return CreateResponse(HttpStatusCode.OK, products);
        }

        [HttpGet]
        [Route("api/products/category/{id:int}")]
        public Task<HttpResponseMessage> GetByCategory(int id)
        {
            var result = _service.GetByCategory(id);
            return CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/products/{skip:int:min(0)}/{take:int:min(1)}")]
        public Task<HttpResponseMessage> GetByRange(int skip, int take)
        {
            var products = _service.Get(skip, take);
            return CreateResponse(HttpStatusCode.OK, products);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/products/outofstock")]
        public Task<HttpResponseMessage> GetInStock()
        {
            var products = _service.GetOutOfStock();
            return CreateResponse(HttpStatusCode.OK, products);
        }

        [HttpPost]
        //[Authorize]
        [Route("api/products")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new CreateProductCommand(
                title: (string)body.title,
                category: (int)body.category,
                description: (string)body.description,
                weight: (string)body.weight,
                price: (decimal)body.price,
                image: (string)body.image,
                quantityOnHand: (int)body.quantityOnHand
            );

            var product = _service.Create(command);
            return CreateResponse(HttpStatusCode.Created, product);
        }

        [HttpPut]
        //[Authorize]
        [Route("api/products/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new UpdateProductCommand(
                id: id,
                title: (string)body.title,
                category: (int)body.category,
                description: (string)body.description,
                weight: (string)body.weight,
                price: (decimal)body.price,
                image: (string)body.image,
                quantityOnHand: (int)body.quantityOnHand
            );

            var product = _service.Update(command);
            return CreateResponse(HttpStatusCode.OK, product);
        }

        [HttpDelete]
        //[Authorize]
        [Route("api/products/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            var product = _service.Delete(id);
            return CreateResponse(HttpStatusCode.OK, product);
        }
    }
}