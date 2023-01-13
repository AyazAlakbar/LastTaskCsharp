using DataAccess.Interface;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : IRepository<User>
    {
        public bool Create(User entity)
        {
            AppDbContext.Users.Add(entity);
            return true;
        }

        public bool Delete(User entity)
        {
            AppDbContext.Users.Remove(entity);
            return true;
        }

        public User Get(Predicate<User> filter = null)
        {
            
            return filter == null ? AppDbContext.Users[0] : AppDbContext.Users.Find(filter);
        }

        public List<User> GetAll(Predicate<User> filter = null)
        {
            return filter==null?AppDbContext.Users:AppDbContext.Users.FindAll(filter);
        }

        public bool Update(User entity)
        {
            try
            {
                User existUser = Get(u => u.Id == entity.Id);
                if (existUser!=null)
                {
                    existUser = entity;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
