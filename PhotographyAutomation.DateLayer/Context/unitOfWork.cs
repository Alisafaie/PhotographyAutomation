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

        private GenericRepository<TblAtelierType> _atelierTypesGenericRepository;

        public GenericRepository<TblAtelierType> AtelierTypesGenericRepository
        {
            get
            {
                if (_atelierTypesGenericRepository == null)
                {
                    _atelierTypesGenericRepository=new GenericRepository<TblAtelierType>(_db);
                }

                return _atelierTypesGenericRepository;
            }
        }



        private GenericRepository<TblBookingStatus> _bookingStatusGenericRepository;

        public GenericRepository<TblBookingStatus> BookingStatusGenericRepository
        {
            get
            {
                if (_bookingStatusGenericRepository == null)
                {
                    _bookingStatusGenericRepository=new GenericRepository<TblBookingStatus>(_db);
                }
                return _bookingStatusGenericRepository;
            }
        }



        private GenericRepository<TblPhotographyType> _photographyTypesGenericRepository;

        public GenericRepository<TblPhotographyType> PhotographyTypesGenericRepository
        {
            get
            {
                if (_photographyTypesGenericRepository==null)
                {
                    _photographyTypesGenericRepository=new GenericRepository<TblPhotographyType>(_db);
                }

                return _photographyTypesGenericRepository;
            }
        }





        public int Save()
        {
            try
            {
                int result=_db.SaveChanges();
                return result;
            }
            catch(Exception exception)
            {
                return -1;
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
