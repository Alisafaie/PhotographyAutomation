using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.DateLayer.Repositories;
using PhotographyAutomation.DateLayer.Services;
using System;
using System.Diagnostics;

namespace PhotographyAutomation.DateLayer.Context
{
    public class UnitOfWork : IDisposable
    {
        private readonly PhotographyAutomationDBEntities _db = new PhotographyAutomationDBEntities();


        private IUserRepository _userRepository;

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_db);
                }
                return _userRepository;
            }
        }

        private IBookingRepository _bookingRepository;

        public IBookingRepository BookingRepository
        {
            get
            {
                if (_bookingRepository==null)
                {
                    _bookingRepository=new BookingRepository(_db);
                }

                return _bookingRepository;
            }
        }


        private GenericRepository<TblCustomer> _userGenericRepository;

        public GenericRepository<TblCustomer> UserGenericRepository
        {
            get
            {
                if (_userGenericRepository == null)
                {
                    _userGenericRepository = new GenericRepository<TblCustomer>(_db);
                }
                return _userGenericRepository;
            }
        }


        private GenericRepository<TblBooking> _bookingGenericRepository;

        public GenericRepository<TblBooking> BookingGenericRepository
        {
            get
            {
                if (_bookingGenericRepository == null)
                {
                    _bookingGenericRepository = new GenericRepository<TblBooking>(_db);
                }

                return _bookingGenericRepository;
            }
        }

        private GenericRepository<TblAtelierType> _atelierTypesGenericRepository;

        public GenericRepository<TblAtelierType> AtelierTypesGenericRepository
        {
            get
            {
                if (_atelierTypesGenericRepository == null)
                {
                    _atelierTypesGenericRepository = new GenericRepository<TblAtelierType>(_db);
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
                    _bookingStatusGenericRepository = new GenericRepository<TblBookingStatus>(_db);
                }
                return _bookingStatusGenericRepository;
            }
        }



        private GenericRepository<TblPhotographyType> _photographyTypesGenericRepository;

        public GenericRepository<TblPhotographyType> PhotographyTypesGenericRepository
        {
            get
            {
                if (_photographyTypesGenericRepository == null)
                {
                    _photographyTypesGenericRepository = new GenericRepository<TblPhotographyType>(_db);
                }

                return _photographyTypesGenericRepository;
            }
        }





        public int Save()
        {
            try
            {
                int result = _db.SaveChanges();
                return result;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.InnerException);
                Debug.WriteLine(exception.Source);
                Debug.WriteLine(exception.Data);
                Debug.WriteLine(exception.StackTrace);

                return -1;
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
