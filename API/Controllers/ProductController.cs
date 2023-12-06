using Microsoft.AspNetCore.Mvc;
using Models.Contracts;
using Models.Data;
using Models.Dtos;

namespace API.Controllers
{
    [ApiController]
    [Route("/api")]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _product;

        public ProductController(IProduct product)
        {
            _product = product;
        }

        [HttpGet("products/{identification}")]
        public ActionResult<General> GetProductsByClient(string identification)
        {
            string service = "GetProductsByClient";
            return _product.GetProductsByClient(identification, service);
        }

        [HttpPost("products")]
        public ActionResult<General> AssociateProductToClient(Product product)
        {
            string service = "AssociateProductToClient";
            return _product.AssociateProductToClient(product, service);
        }

        [HttpGet("productTypes")]
        public ActionResult<General> GetProductTypes()
        {
            string service = "GetProductTypes";
            return _product.GetProductTypes(service);
        }
    }
}
