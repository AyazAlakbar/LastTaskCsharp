using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUser
    {
        public User Create(User user);
        public User Update(int id, User user);
        public User Delete(int id);

        public void ShareStatus(Status status, int statusId, int userId);


        public User GetUserById(int id);
        public List<Status> GetAllStatusesById(int id);

        public User GetUserByUserName(string userName);

        public List<User> GetAll();
    }
}
