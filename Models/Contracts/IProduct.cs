using Microsoft.AspNetCore.Mvc;
using Models.Data;
using Models.Dtos;

namespace Models.Contracts
{
    public interface IProduct
    {
        public ActionResult<General> GetProductTypes(string service);
        public ActionResult<General> GetProductsByClient(string identification, string service);
        public ActionResult<General> AssociateProductToClient(Product product, string service);
    }
}
