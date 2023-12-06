using Business.Helpers;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Contracts;
using Models.Data;
using Models.Dtos;
using System.Net;

namespace Business.Functions
{
    public class ProductFunction : IProduct
    {
        private readonly AppDbContext context;

        public ProductFunction(AppDbContext context)
        {
            this.context = context;
        }

        public ActionResult<General> AssociateProductToClient(Product product, string service)
        {
            try
            {
                var existingType = context.ProductTypes.Any(pt => pt.Id.Equals(product.ProductTypeId));
                Client? client = context.Clients.Where(x => x.Id.Equals(product.ClientId)).FirstOrDefault();

                if (!existingType)
                    return new General
                    {
                        title = service,
                        idError = -1,
                        error = true,
                        message = $"Tipo de producto invalido."
                    };               

                if (client == null)
                    return new General
                    {
                        title = service,
                        idError = -2,
                        error = true,
                        message = $"El cliente con id {product.Id} no existe."
                    };

                context.Products.Add(product);
                context.SaveChanges();

                return new General
                {
                    title = service,
                    message = "Producto asociado con exito.",
                };
            }
            catch
            {
                return Error.ResponseCatchError(service);
            }
        }

        public ActionResult<General> GetProductsByClient(string identification, string service)
        {
            try
            {
                var products = context.Products.
                    Join(context.Clients, p => p.ClientId, c => c.Id,
                    (p, c) => new { client = c, product = p}).
                    Join(context.ProductTypes, res => res.product.ProductTypeId, pt => pt.Id,
                    (res, pt) => new { res, productType = pt })
                .Where(p => p.res.client.Identification.Equals(identification))
                .Select(x => new
                {
                    identification = x.res.client.IdentificationType,
                    name = $"{x.res.client.Name} {x.res.client.LastName}",
                    product = x.res.product.Name,
                    productType = x.productType.TypeName
                })
                .ToList();

                return new General
                {
                    title = service,
                    message = "Información obtenida con exito.",
                    data = new { products }
                };
            }
            catch
            {
                return Error.ResponseCatchError(service);
            }
        }

        public ActionResult<General> GetProductTypes(string service)
        {
            try {
                List<ProductType> productTypes = context.ProductTypes.ToList();

                return new General
                {
                    title = service,
                    message = "Tipos de producto obtenidos con exito.",
                    data = new { productTypes }
                };
            }
            catch
            {
                return Error.ResponseCatchError(service);
            }
        }
    }
}
