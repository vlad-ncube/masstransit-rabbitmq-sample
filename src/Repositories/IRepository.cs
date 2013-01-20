using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.DomainObjects;

namespace Repositories
{
    public interface IRepository
    {
        void AddUser(User user);

        User GetUserByName(string firstName);

        void DeleteUsers();
    }
}