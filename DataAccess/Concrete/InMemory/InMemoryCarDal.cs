using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car 
                {
                    Id = 1,
                    BrandId = 1, 
                    ColorId = 2, 
                    ModelYear = 2013, 
                    DailyPrice = 640, 
                    Description = "Sunroof, Navigation System, Bluetooth"
                },
                new Car
                {
                    Id = 2,
                    BrandId = 3,
                    ColorId = 1,
                    ModelYear = 2015,
                    DailyPrice = 740,
                    Description = "Sunroof, Navigation System, Bluetooth, Remote Start"
                },
                new Car
                {
                    Id = 3,
                    BrandId = 2,
                    ColorId = 3,
                    ModelYear = 2007,
                    DailyPrice = 350,
                    Description = "Sunroof"
                },
                new Car
                {
                    Id = 4,
                    BrandId = 2,
                    ColorId = 1,
                    ModelYear = 2009,
                    DailyPrice = 460,
                    Description = "Sunroof, Navigation System",
                },
                new Car
                {
                    Id = 5,
                    BrandId = 1,
                    ColorId = 3,
                    ModelYear = 2017,
                    DailyPrice = 830,
                    Description = "Sunroof, Navigation System, Bluetooth, Remote Start, Android Auto"
                },
                new Car
                {
                    Id = 6,
                    BrandId = 3,
                    ColorId = 2,
                    ModelYear = 2011,
                    DailyPrice = 570,
                    Description = "Sunroof, Navigation System, Bluetooth"
                },
                new Car
                {
                    Id = 7,
                    BrandId = 2,
                    ColorId = 1,
                    ModelYear = 2020,
                    DailyPrice = 1250,
                    Description = "Sunroof, Navigation System, Bluetooth, Remote Start, Android Auto, Third-Row Seating"
                },
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void GetAll()
        {
            foreach (var car in _cars)
            {
                Console.WriteLine("       " + car.Id);
                Console.WriteLine("Brand ID: " + car.BrandId);
                Console.WriteLine("Color ID: " + car.ColorId);
                Console.WriteLine("Model Year: " + car.ModelYear);
                Console.WriteLine("Daily Price: " + car.DailyPrice);
                Console.WriteLine("Description: " + car.Description);
                Console.WriteLine("\n");
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void GetById(int carId)
        {
            Car carById = _cars.SingleOrDefault(c => c.Id == carId);

            Console.WriteLine("       " + carById.Id);
            Console.WriteLine("Brand ID: " + carById.BrandId);
            Console.WriteLine("Color ID: " + carById.ColorId);
            Console.WriteLine("Model Year: " + carById.ModelYear);
            Console.WriteLine("Daily Price: " + carById.DailyPrice);
            Console.WriteLine("Description: " + carById.Description);
            Console.WriteLine("\n");
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}