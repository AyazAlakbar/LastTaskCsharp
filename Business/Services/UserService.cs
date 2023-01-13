using Business.Interfaces;
using DataAccess.Repositories;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class UserService : IUser
    {


        private readonly UserRepository userRepository;
        private readonly StatusRepository statusRepository;

        public static int Id { get; set; } = 1;

        public UserService()
        {
            userRepository = new();
            statusRepository = new();
        }


        public User Create(User user)
        {
            try
            {
                User existUser = userRepository.Get(u => u.Username.ToLower() == user.Username.ToLower());
                if (existUser == null)
                {
                    user.Id = Id;
                    if (userRepository.Create(user))
                    {
                        Id++;
                        return user;
                    }
                }
                return null;
            }


            catch (Exception)
            {

                return null;
            }
        }



        public void ShareStatus(Status status, int statusId, int userId)
        {
            User exisUser = userRepository.Get(u => u.Id == userId);
            if (exisUser != null)
            {
                Status existStatus = statusRepository.Get(s => s.Id == statusId);
                if (existStatus != null)
                {
                    statusRepository.Create(existStatus);
                }
            }
            

        }



        public User Delete(int id)
        {
            User existUser = userRepository.Get(u => u.Id == id);
            if (existUser != null)
            {
                userRepository.Delete(existUser);
                return existUser;
            }
            return null;
        }



        public List<Status> GetAllStatusesById(int id)
        {
            List<Status> statuses = statusRepository.GetAll(s => s.Id == id);
            return statuses;
        }



        public List<User> GetAll()
        {
            List<User> users = userRepository.GetAll();
            return users;
        }



        public User GetUserById(int id)
        {
            User existUser = userRepository.Get(u => u.Id == id);
            return existUser == null ? null : existUser;
        }



        public User GetUserByUserName(string userName)
        {
            User existUser = userRepository.Get(u => u.Username.ToLower() == userName.ToLower());
            return existUser == null ? null : existUser;
        }



        public User Update(int id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
