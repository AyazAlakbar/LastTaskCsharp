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
        User Create(User user);
        User Update(int id, User user);
        User Delete(int id);

        User Get(int id);
        User Get(string name);
        List<User> GetAll();
    }
}
