using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.DateLayer.Repositories;

namespace PhotographyAutomation.DateLayer.Services
{
    public class UserRepository : IUserRepository
    {
        private PhotographyAutomationDBEntities db;

        public UserRepository(PhotographyAutomationDBEntities context)
        {
            db = context;
        }
        public TblUser FindUserByMobile(string mobileNumber)
        {
            try
            {
                return db.TblUser.Where(x => x.Mobile.Contains(mobileNumber)).SingleOrDefault();
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }
    }
}
