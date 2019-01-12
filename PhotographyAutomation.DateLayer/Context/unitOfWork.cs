using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.DateLayer.Services;
using System;
using PhotographyAutomation.DateLayer.Repositories;

namespace PhotographyAutomation.DateLayer.Context
{
    public class UnitOfWork:IDisposable
    {
        PhotographyAutomationDBEntities _db = new PhotographyAutomationDBEntities();


        private IUserRepository _userRepository;

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository=new UserRepository(_db);
                }

                return _userRepository;
            }
        }


        private GenericRepository<TblUser> _userGenericRepository;

        public GenericRepository<TblUser> UserGenericRepository
        {
            get
            {
                if (_userGenericRepository == null)
                {
                    _userGenericRepository = new GenericRepository<TblUser>(_db);
                }

                return _userGenericRepository;
            }
        }

        private GenericRepository<TblBooking> _bookingRepository;

        public GenericRepository<TblBooking> BookingRepository
        {
            get
            {
                if (_bookingRepository == null)
                {
                    _bookingRepository = new GenericRepository<TblBooking>(_db);
                }

                return _bookingRepository;
            }
        }

        public bool Save()
        {
            try
            {
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public void Dispose()
        {
            _db.Dispose();
        }

    }
}
