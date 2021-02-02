using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Car Rental System!\n");

            CarManager carManager = new CarManager(new InMemoryCarDal());

            //Listing all cars registered in the system
            carManager.GetAll();

            //Registering a new car in the system
            Car newCar = new Car
            {
                ID = 8,
                BrandID = 3,
                ColorID = 2,
                ModelYear = 2019,
                DailyPrice = 899,
                Description  = "Sunroof, Navigation System, Bluetooth, Remote Start, Apple Auto"
            };

            carManager.Add(newCar);
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

            //Removing a car by its ID from the system
            carManager.Delete(8);
            carManager.GetAll();

            //Displaying a car by its ID in the system
            carManager.GetByID(4);
        }
    }
}