using DatoriumBank.Data.Entity;
using System.Collections.Generic;

namespace DatoriumBank.Data.Managers.Interface
{
    public interface IUserManager
    {
        void AddClient(Client client);
        List<Client> GetClients(string name);
        void UpdateClient(Client client);
        void DeleteClient(int clientId);
    }
}
