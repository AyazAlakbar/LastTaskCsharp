using DataAccess.Interface;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class StatusRepository : IRepository<Status>
    {
        public bool Create(Status entity)
        {
            try
            {
                AppDbContext.Statuses.Add(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Status entity)
        {
            try
            {
                AppDbContext.Statuses.Remove(entity);
                return true ;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Status Get(Predicate<Status> filter = null)
        {
            try
            {
                return filter == null ? AppDbContext.Statuses[0] : AppDbContext.Statuses.Find(filter);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Status> GetAll(Predicate<Status> filter = null)
        {
            return filter==null?AppDbContext.Statuses:AppDbContext.Statuses.FindAll(filter);
        }

        public bool Update(Status entity)
        {
            try
            {
                Status existStatus=Get(st=>st.Id==entity.Id);
                if (existStatus != null)
                {
                    existStatus=entity;
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
