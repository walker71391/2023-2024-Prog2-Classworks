using DatoriumBank.Data.Entity;
using System.Linq;
using System.Collections.Generic;

namespace DatoriumBank.Data.Managers
{
    public class UserManager : IUserManager
    {
        private BankDbContext _bankDbContext;

        public UserManager(BankDbContext bankDbContext)
        {
            _bankDbContext = bankDbContext;
        }

        public void AddClient(Client client)
        {
            _bankDbContext.Clients.Add(client);
            _bankDbContext.SaveChanges();
        }

        public List<Client> GetClients(string name)
        {
            return _bankDbContext.Clients
                .Where(client => client.Name == name)
                .ToList();
        }

        public void UpdateClient(Client client)
        {
            var existingClient = _bankDbContext.Clients.Find(client.ClientId);

            if (existingClient != null)
            {
                existingClient.Name = client.Name;
                existingClient.Email = client.Email;

                _bankDbContext.SaveChanges();
            }
        }

        public void DeleteClient(int clientId)
        {
            var clientToDelete = _bankDbContext.Clients.Find(clientId);

            if (clientToDelete != null)
            {
                _bankDbContext.Clients.Remove(clientToDelete);
                _bankDbContext.SaveChanges();
            }
        }
    }
}
