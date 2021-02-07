using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
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
            return _carDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _carDal.Get(c => c.Id == id);
        }

        public List<Car> GetByColorId(int colorId)
        {           
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public List<Car> GetByBrandId(int brandId)
        {          
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine("Car Updated Succesfully!");
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {           
            return _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);
        }

        public List<CarDetailDto> GetCarDetails()
        {           
            return _carDal.GetCarDetails();
        }
    }
}