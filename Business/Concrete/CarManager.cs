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
            if (car.Description.Length < 2 || car.DailyPrice <= 0)
            {
                Console.WriteLine("Description must contain at least 2 characters!\n" +
                                  "Daily price should be positive.");
            }
            else
            {
                _carDal.Add(car);
            }

        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetByID(int ID)
        {
            return _carDal.GetAll(c => c.ID == ID);
        }

        public List<Car> GetByColorID(int colorID)
        {
            return _carDal.GetAll(c => c.ColorID == colorID);
        }

        public List<Car> GetByBrandID(int brandID)
        {
            return _carDal.GetAll(c => c.BrandID == brandID);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);
        }
    }
}