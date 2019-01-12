﻿using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.DateLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

    }
}