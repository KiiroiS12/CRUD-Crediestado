using Microsoft.AspNetCore.Mvc;
using Models.Data;
using Models.Dtos;

namespace Models.Contracts
{
    public interface IClient
    {
        public ActionResult<General> GetClients(string service);
        public ActionResult<General> GetClient(int id, string service);
        public ActionResult<General> CreateClient(Client client, string service);
        public ActionResult<General> UpdateClient(int id, Client client, string service);
        public ActionResult<General> DeleteClient(int id, string service);
    }
}
