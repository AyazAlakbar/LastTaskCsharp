using Business.Interfaces;
using DataAccess.Repositories;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Helper;

namespace Business.Services
{
    public class StatusService : IStatus
    {

        private readonly StatusRepository statusRepository;
        private readonly UserService userService;
        private readonly UserRepository userRepository;

        public static int Id { get; set; } = 1;
        public StatusService()
        {
            statusRepository = new StatusRepository();
            userService = new UserService();
            userRepository = new UserRepository();
        }


        public Status Create(Status status,int Id)
        {
            User existUser = userRepository.Get(u=>u.Id==Id);
            if (existUser != null)
            {
                status.Id = Id;
                status.User = existUser;
                if (statusRepository.Create(status)!=null)
                {
                    Id++;
                    existUser.Statuses.Add(status);
                    return status;
                }

            }
            return null;
        }

        public Status GetStatusInfo(int id)
        {
            Status existStatus=statusRepository.Get(st=>st.Id==id);
            if (existStatus!=null)
            {
                return existStatus;
            }
            return null;
        }

        public Status GetStatusById(int id)
        {

            Status existStatus = statusRepository.Get(st => st.Id == id);
            if (existStatus != null)
            {
                return existStatus;
            }
            return null;
        }

        public List<Status> FilterStatusByDate(int id, DateTime date)
        {
            User existUser=userRepository.Get(u=>u.Id==id);
            List<Status> statusList=new List<Status>();
            if (existUser!=null)
            {
                foreach (var item in existUser.Statuses)
                {
                    if (date<item.SharedDate)
                    {
                        statusList.Add(item);
                    }

                }
                return statusList;

            }
            else
            {
                throw new NotFoundException("Not Found");
            }
        }

        public List<Status> GetAll()
        {
            return statusRepository.GetAll();
        }


        public List<Status> GetAllStatusesByUsername(string userName)
        {
            List<Status> statuses = statusRepository.GetAll(u => u.User.Username.ToLower() == userName.ToLower());
            return statuses;
        }

        public Status Update(int userId, int statusId)
        {
            throw new NotImplementedException();
        }

        public Status Delete(int id)
        {
            Status existStatus = statusRepository.Get(st => st.Id == id);
            if (existStatus != null)
            {
                statusRepository.Delete(existStatus);
                return existStatus;
            }
            return null;
        }
    }
}