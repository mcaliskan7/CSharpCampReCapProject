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
            if (car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("Car Added Succesfully!");
            }
            else
            {
                Console.WriteLine("Invalid Daily Price, Registration Failed!");
            }

        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Car Deleted Succesfully!");
        }

        public List<Car> GetAll()
        {
            Console.WriteLine("\t\t\t\t\t\t\t\tAll Cars in the System");
            return _carDal.GetAll();
        }

        public Car GetByID(int ID)
        {
            return _carDal.Get(c => c.ID == ID);
        }

        public List<Car> GetByColorID(int colorID)
        {
            Console.WriteLine("Car whose ColorID is {0}", colorID);
            return _carDal.GetAll(c => c.ColorID == colorID);
        }

        public List<Car> GetByBrandID(int brandID)
        {
            Console.WriteLine("Car whose BrandID is {0}", brandID);
            return _carDal.GetAll(c => c.BrandID == brandID);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine("Car Updated Succesfully!");
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            Console.WriteLine("Car whose DailyPrice is greater than {0} and less than {1}", min, max);
            return _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);
        }
    }
}