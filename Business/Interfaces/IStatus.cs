using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IStatus
    {
        public Status Create(Status status, int id);
        public Status Update(int userId, int statusId);
        public Status Delete(int id);
        public List<Status> GetAll();
        public Status GetStatusById(int id);
        Status GetStatusInfo(int id);
        List<Status> FilterStatusByDate(int id, DateTime date);
        List<Status> GetAllStatusesByUsername(string userName);
    }
}
