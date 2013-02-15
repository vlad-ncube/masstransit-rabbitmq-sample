using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.DomainObjects;
using MasstransitSpike.Core.Repositories;

namespace Repositories.MySqlFake
{
    public class UserRepository : IUserRepository
    {
        private static IList<User> users;

        static UserRepository()
        {
            users = new List<User>();
        }

        public void Add(User entity)
        {
            users.Add(entity);
        }

        public void DeleteAll()
        {
            users.Clear();
        }

        public User GetByName(string firstName)
        {
            return users.First(u => u.FirstName == firstName);
        }
    }
}