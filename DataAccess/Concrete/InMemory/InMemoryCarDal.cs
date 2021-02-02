using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    ID = 1,
                    BrandID = 1, 
                    ColorID = 2, 
                    ModelYear = 2013, 
                    DailyPrice = 640, 
                    Description = "Sunroof, Navigation System, Bluetooth"
                },
                new Car
                {
                    ID = 2,
                    BrandID = 3,
                    ColorID = 1,
                    ModelYear = 2015,
                    DailyPrice = 740,
                    Description = "Sunroof, Navigation System, Bluetooth, Remote Start"
                },
                new Car
                {
                    ID = 3,
                    BrandID = 2,
                    ColorID = 3,
                    ModelYear = 2007,
                    DailyPrice = 350,
                    Description = "Sunroof"
                },
                new Car
                {
                    ID = 4,
                    BrandID = 2,
                    ColorID = 1,
                    ModelYear = 2009,
                    DailyPrice = 460,
                    Description = "Sunroof, Navigation System",
                },
                new Car
                {
                    ID = 5,
                    BrandID = 1,
                    ColorID = 3,
                    ModelYear = 2017,
                    DailyPrice = 830,
                    Description = "Sunroof, Navigation System, Bluetooth, Remote Start, Android Auto"
                },
                new Car
                {
                    ID = 6,
                    BrandID = 3,
                    ColorID = 2,
                    ModelYear = 2011,
                    DailyPrice = 570,
                    Description = "Sunroof, Navigation System, Bluetooth"
                },
                new Car
                {
                    ID = 7,
                    BrandID = 2,
                    ColorID = 1,
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

        public void Delete(int carID)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.ID == carID);
            _cars.Remove(carToDelete);
        }

        public void GetAll()
        {
            foreach (var car in _cars)
            {
                Console.WriteLine("       " + car.ID);
                Console.WriteLine("Brand ID: " + car.BrandID);
                Console.WriteLine("Color ID: " + car.ColorID);
                Console.WriteLine("Model Year: " + car.ModelYear);
                Console.WriteLine("Daily Price: " + car.DailyPrice);
                Console.WriteLine("Description: " + car.Description);
                Console.WriteLine("\n");
            }
        }

        public void GetByID(int carID)
        {
            Car carByID = _cars.SingleOrDefault(c => c.ID == carID);

            Console.WriteLine("       " + carByID.ID);
            Console.WriteLine("Brand ID: " + carByID.BrandID);
            Console.WriteLine("Color ID: " + carByID.ColorID);
            Console.WriteLine("Model Year: " + carByID.ModelYear);
            Console.WriteLine("Daily Price: " + carByID.DailyPrice);
            Console.WriteLine("Description: " + carByID.Description);
            Console.WriteLine("\n");
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.ID == car.ID);
            carToUpdate.ID = car.ID;
            carToUpdate.BrandID = car.BrandID;
            carToUpdate.ColorID = car.ColorID;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}