using Azure;
using Business.Helpers;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Contracts;
using Models.Data;
using Models.Dtos;

namespace Business.Functions
{
    public class ClientFunction : IClient
    {
        private readonly AppDbContext context;
        public ClientFunction(AppDbContext context)
        {
            this.context = context;
        }

        public ActionResult<General> CreateClient(Client client, string service)
        {
            try
            {
                Client? clientDb = context.Clients.Where(x => x.Identification.Equals(client.Identification)).FirstOrDefault();

                if (clientDb != null)
                    return new General
                    {
                        title = service,
                        idError = -1,
                        error = true,
                        message = $"El cliente ya existe."
                    };

                context.Clients.Add(client);
                context.SaveChanges();

                return new General
                {
                    title = service,
                    message = $"Cliente creado con exito."
                };
            }
            catch
            {
                return Error.ResponseCatchError(service);
            }
        }

        public ActionResult<General> DeleteClient(int id, string service)
        {
            try
            {
                Client? client = context.Clients.Where(x => x.Id.Equals(id)).FirstOrDefault();

                if (client == null)
                    return new General
                    {
                        title = service,
                        idError = -1,
                        error = true,
                        message = $"El cliente con id {id} no existe."
                    };

                if (context.Products.Any(p => p.ClientId == id))
                {
                    return new General
                    {
                        title = service,
                        idError = -2,
                        error = true,
                        message = $"El cliente no se puede eliminar debido a que tiene productos asociados."
                    };

                }

                context.Clients.Remove(client);
                context.SaveChanges();

                return new General
                {
                    title = service,
                    message = "Cliente removido con exito."
                };
            }
            catch
            {
                return Error.ResponseCatchError(service);
            }
        }

        public ActionResult<General> GetClient(int id, string service)
        {
            try
            {
                Client? client = context.Clients.Where(x => x.Id.Equals(id)).FirstOrDefault();

                if(client == null)
                    return new General
                    {
                        title = service,
                        idError = -1,
                        error = true,
                        message = $"El cliente con id {id} no existe."
                    };

                return new General
                {
                    title = service,
                    message = "Cliente obtenido con exito.",
                    data = new { client }
                };
            }
            catch
            {
                return Error.ResponseCatchError(service);
            }
        }

        public ActionResult<General> GetClients(string service)
        {
            try
            {
                List<Client> clients = context.Clients.ToList();

                return new General
                {
                    title = service,
                    message = "Clientes obtenidos con exito.",
                    data = new { clients }
                };
            }
            catch
            {
                return Error.ResponseCatchError(service);
            }
        }

        public ActionResult<General> UpdateClient(int id, Client client, string service)
        {
            try
            {
                Client? clientDb = context.Clients.Where(x => x.Id.Equals(id)).FirstOrDefault();

                if (clientDb == null)
                    return new General
                    {
                        title = service,
                        idError = -1,
                        error = true,
                        message = $"El cliente con id {id} no existe."
                    };

                context.Entry(client).State = EntityState.Modified;
                context.SaveChanges();

                return new General
                {
                    title = service,
                    message = "Cliente actualizado con exito."
                };
            }
            catch
            {
                return Error.ResponseCatchError(service);
            }
        }
    }
}
