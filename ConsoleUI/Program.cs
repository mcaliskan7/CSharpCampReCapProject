using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Car Rental System!\n");

            CarManager carManager = new CarManager(new EfCarDal());

            //Listing all cars registered in the system
            carManager.GetAll();

            //Registering a new car in the system
            List<Car> cars;
            cars = new List<Car>
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

            foreach (var car in cars)
            {
                carManager.Add(car);
            }
           
            carManager.GetAll();

            //Updating a car in the system
            Car carToUpdate = new Car
            {
                ID = 4,
                BrandID = 3,
                ColorID = 1,
                ModelYear = 2017,
                DailyPrice = 635,
                Description = "Sunroof, Navigation System, Bluetooth"
            };

            carManager.Update(carToUpdate);
            carManager.GetAll();

            //Removing a car from the system
            carManager.Delete(cars[0]);
            carManager.GetAll();

            //Displaying a car by its ID in the system
            carManager.GetByID(4);

            ////Displaying cars by BrandID in the system
            carManager.GetByBrandID(2);

            //Displaying cars by ColorID in the system
            carManager.GetByColorID(1);
        }
    }
}