using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryUserDal : IUserDal
    {
        List<User> _users;

        public InMemoryUserDal()
        {
            _users = new List<User>() {
                new User() { Id = 1, FirstName="Alper", LastName = "Dogan"},
                new User() { Id = 2, FirstName="Ahmet", LastName = "Yılmaz"},
                new User() { Id = 3, FirstName="Mehmet", LastName = "Celik"},
            };
        }

        public void Add(User user)
        {
            _users.Add(user);
        }

        public void Delete(User user)
        {
            User deletedUser = _users.SingleOrDefault(u => u.Id == user.Id);
            _users.Remove(deletedUser);
        }

        public User Get(Expression<Func<User, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            return _users;
        }

        public List<User> GetAll(Expression<Func<User, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<OperationClaim> GetClaims(User user)
        {
            throw new NotImplementedException();
        }

        public UserDetailDto GetUserDetailsByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            User updatedUser = _users.SingleOrDefault(u => u.Id == user.Id);
            updatedUser.FirstName = user.FirstName;
            updatedUser.LastName = user.LastName;
        }
    }
}
