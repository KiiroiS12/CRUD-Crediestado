using Microsoft.AspNetCore.Mvc;
using Models.Contracts;
using Models.Data;
using Models.Dtos;

namespace API.Controllers
{
    [ApiController]
    [Route("/api")]
    public class ClientController : ControllerBase
    {
        private readonly IClient _client;

        public ClientController(IClient client)
        {
            this._client = client;
        }

        [HttpGet("clients")]
        public ActionResult<General> GetClients()
        {
            string service = "GetClients";
            return _client.GetClients(service);
        }

        [HttpGet("clients/{id}")]
        public ActionResult<General> GetClient(int id)
        {
            string service = "GetClient";
            return _client.GetClient(id, service);
        }

        [HttpPost("clients")]
        public ActionResult<General> CreateClient(Client client)
        {
            string service = "CreateClient";
            return _client.CreateClient(client, service);
        }

        [HttpPut("clients/{id}")]
        public ActionResult<General> UpdateClient(int id, Client client)
        {
            string service = "UpdateClient";
            return _client.UpdateClient(id, client, service);
        }

        [HttpDelete("clients/{id}")]
        public ActionResult<General> DeleteClient(int id)
        {
            string service = "DeleteClient";
            return _client.DeleteClient(id, service);
        }
    }
}
