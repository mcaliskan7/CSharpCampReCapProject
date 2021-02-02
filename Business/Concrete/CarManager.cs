using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            _carDal.Add(car);
        }

        public void Delete(int carID)
        {
            _carDal.Delete(carID);
        }

        public void GetAll()
        {
            _carDal.GetAll();
        }

        public void GetByID(int carID)
        {
            _carDal.GetByID(carID);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}