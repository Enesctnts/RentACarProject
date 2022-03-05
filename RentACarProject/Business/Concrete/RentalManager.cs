using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId);
            if (result.Count > 0)
            {
                foreach (var car in result)
                {
                    if (car.ReturnDate == null || car.ReturnDate > DateTime.Now.Date)
                    {
                        return new ErrorResult(Messages.RentalNotAdded);
                    }
                }
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);


        }
        public IResult Update(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId);
            if (result.Count > 0)
            {
                foreach (var car in result)
                {
                    if (car.ReturnDate == null)
                    {
                        _rentalDal.Update(rental);

                    }
                }
            }
            return new SuccessResult(Messages.RentalUpdated);
        }
    

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<Rental> Get(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == id), Messages.RentalList);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IDataResult<List<RentalDetailDto>> GetCarRentalDetails()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetCarRentalDetails(), Messages.CarListed);

        }
        public IDataResult<List<Rental>> GetRentalsByCustomerId(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(p => p.CustomerId == id), Messages.UserList);
        }

        public IDataResult<List<Rental>> GetRentalsByCarId(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(P => P.CarId == id), Messages.UserList);
        }

        public IDataResult<Rental> GetRentalById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id== id), Messages.UserList);
        }

    }   
}
