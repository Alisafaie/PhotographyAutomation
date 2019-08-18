﻿using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.DateLayer.Repositories;
using PhotographyAutomation.DateLayer.Services;
using System;
using System.Diagnostics;

namespace PhotographyAutomation.DateLayer.Context
{
    public class UnitOfWork : IDisposable
    {
        private readonly PhotographyAutomationDBEntities _db = new PhotographyAutomationDBEntities();


        private IPrintSizePriceServiceRepository _printSizePriceRepository;
        public IPrintSizePriceServiceRepository PrintSizePriceServiceRepository
        {
            get
            {
                if (_printSizePriceRepository == null)
                {
                    _printSizePriceRepository = new PrintSizePriceServiceRepository(_db);
                }
                return _printSizePriceRepository;
            }
        }



        private ICustomerRepository _customerRepository;
        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (_customerRepository == null)
                {
                    _customerRepository = new CustomerRepository(_db);
                }
                return _customerRepository;
            }
        }



        private IBookingRepository _bookingRepository;
        public IBookingRepository BookingRepository
        {
            get
            {
                if (_bookingRepository == null)
                {
                    _bookingRepository = new BookingRepository(_db);
                }

                return _bookingRepository;
            }
        }



        private IPhotoRepository _photoRepository;
        public IPhotoRepository PhotoRepository
        {
            get
            {
                if (_photoRepository == null)
                {
                    _photoRepository = new PhotoRepository(_db);
                }

                return _photoRepository;
            }
        }




        private IOrderRepository _orderRepository;
        public IOrderRepository OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new OrderRepository(_db);
                }

                return _orderRepository;
            }
        }



        private GenericRepository<TblOrderFiles> _orderFilesGenericRepository;
        public GenericRepository<TblOrderFiles> OrderFilesGenericRepository
        {
            get
            {
                if (_orderFilesGenericRepository == null)
                {
                    _orderFilesGenericRepository = new GenericRepository<TblOrderFiles>(_db);
                }
                return _orderFilesGenericRepository;
            }
        }



        private GenericRepository<TblOrderPrint> _orderPrintGenericRepository;
        public GenericRepository<TblOrderPrint> OrderPrintGenericRepository
        {
            get
            {
                if (_orderPrintGenericRepository == null)
                {
                    _orderPrintGenericRepository = new GenericRepository<TblOrderPrint>(_db);
                }

                return _orderPrintGenericRepository;
            }
        }



        private GenericRepository<TblCustomer> _customerGenericRepository;
        public GenericRepository<TblCustomer> CustomerGenericRepository
        {
            get
            {
                if (_customerGenericRepository == null)
                {
                    _customerGenericRepository = new GenericRepository<TblCustomer>(_db);
                }
                return _customerGenericRepository;
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



        private GenericRepository<TblOrder> _orderGenericRepository;
        public GenericRepository<TblOrder> OrderGenericRepository
        {
            get
            {
                if (_orderGenericRepository == null)
                {
                    _orderGenericRepository = new GenericRepository<TblOrder>(_db);
                }

                return _orderGenericRepository;
            }
        }



        private GenericRepository<TblOrderPrintDetails> _orderPrintDetailsGenericRepository;
        public GenericRepository<TblOrderPrintDetails> OrderPrintDetailsGenericRepository
        {
            get
            {
                if (_orderPrintDetailsGenericRepository == null)
                {
                    _orderPrintDetailsGenericRepository = new GenericRepository<TblOrderPrintDetails>(_db);
                }

                return _orderPrintDetailsGenericRepository;
            }
        }



        private GenericRepository<TblOrderStatus> _orderStatusGenericRepository;
        public GenericRepository<TblOrderStatus> OrderStatusGenericRepository
        {
            get
            {
                if (_orderStatusGenericRepository == null)
                {
                    _orderStatusGenericRepository = new GenericRepository<TblOrderStatus>(_db);
                }

                return _orderStatusGenericRepository;
            }
        }



        private GenericRepository<TblOrderPrintStatus> _orderPrintStatusGenericRepository;
        public GenericRepository<TblOrderPrintStatus> OrderPrintStatusGenericRepository
        {
            get
            {
                if (_orderPrintStatusGenericRepository == null)
                {
                    _orderPrintStatusGenericRepository = new GenericRepository<TblOrderPrintStatus>(_db);
                }

                return _orderPrintStatusGenericRepository;
            }
        }



        private GenericRepository<TblFilesError> _filesErrorGenericRepository;
        public GenericRepository<TblFilesError> FilesErrorGenericRepository
        {
            get
            {
                if (_filesErrorGenericRepository == null)
                {
                    _filesErrorGenericRepository = new GenericRepository<TblFilesError>(_db);
                }

                return _filesErrorGenericRepository;
            }
        }











        private GenericRepository<TblPrintCustomerFiles> _printCustomerFilesGenericRepository;
        public GenericRepository<TblPrintCustomerFiles> PrintCustomerFilesGenericRepository =>
            _printCustomerFilesGenericRepository ?? (_printCustomerFilesGenericRepository =
                new GenericRepository<TblPrintCustomerFiles>(_db));




        private GenericRepository<TblAlbums> _albumGenericRepository;
        public GenericRepository<TblAlbums> AlbumGenericRepository =>
            _albumGenericRepository ?? (_albumGenericRepository = new GenericRepository<TblAlbums>(_db));



        private GenericRepository<TblPrintItalianAlbums> _printItalianAlbumsGenericRepository;
        public GenericRepository<TblPrintItalianAlbums> PrintItalianAlbumsGenericRepository =>
            _printItalianAlbumsGenericRepository ?? (_printItalianAlbumsGenericRepository =
                new GenericRepository<TblPrintItalianAlbums>(_db));




        private GenericRepository<TblPrintSizes> _printSizesGenericRepository;
        public GenericRepository<TblPrintSizes> PrintSizesGenericRepository =>
            _printSizesGenericRepository ??
            (_printSizesGenericRepository =
                new GenericRepository<TblPrintSizes>(_db));




        private GenericRepository<TblPrintServicePrices> _printServicePricesGenericRepository;
        public GenericRepository<TblPrintServicePrices> PrintServicePricesGenericRepository =>
            _printServicePricesGenericRepository ?? (_printServicePricesGenericRepository =
                new GenericRepository<TblPrintServicePrices>(_db));






        private GenericRepository<TblPrintServices> _printServicesGenericRepository;
        public GenericRepository<TblPrintServices> PrintServicesGenericRepository =>
            _printServicesGenericRepository ?? (_printServicesGenericRepository =
                new GenericRepository<TblPrintServices>(_db));


        private GenericRepository<TblPrintSpecialServices> _printSpecialServicesGenericRepository;
        public GenericRepository<TblPrintSpecialServices> PrintSpecialServicesGenericRepository =>
            _printSpecialServicesGenericRepository ?? (_printSpecialServicesGenericRepository =
                new GenericRepository<TblPrintSpecialServices>(_db));






        public int Save()
        {
            try
            {
                int result = _db.SaveChanges();
                return result;
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Message");
                Debug.WriteLine(exception.Message);

                Debug.WriteLine("Inner Exception");
                Debug.WriteLine(exception.InnerException);

                Debug.WriteLine("Inner Exception Message:");
                Debug.WriteLine(exception.InnerException?.Message);

                Debug.WriteLine("Source");
                Debug.WriteLine(exception.Source);

                Debug.WriteLine("Data");
                Debug.WriteLine(exception.Data);

                Debug.WriteLine("Stack Trace");
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
