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
            Console.WriteLine("\t\t\t\t\t\t\t\tWelcome to the Car Rental System!\n");

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            CarManager carManager = new CarManager(new EfCarDal());

            void Show(Car car)
            {
                string str = new string('_', 180);
                Console.WriteLine(str + "\n\n" +
                                  "\tID\t\tBrandID\t\tColorID\t\tModelYear\tDailyPrice\tDescription\t");

                Console.WriteLine("\t{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}\t",
                        car.ID, brandManager.GetByID(car.BrandID).Name, colorManager.GetByID(car.ColorID).Name,
                        car.ModelYear, car.DailyPrice, car.Description);

                Console.WriteLine(str + "\n");
            }
            
            void ShowAll(List<Car> cars)
            {
                string str = new string('_', 180);
                Console.WriteLine(str + "\n\n" +
                                  "\tID\t\tBrandID\t\tColorID\t\tModelYear\tDailyPrice\tDescription\t");
                foreach (var car in cars)
                {
                    Console.WriteLine("\t{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}\t",
                        car.ID, brandManager.GetByID(car.BrandID).Name, colorManager.GetByID(car.ColorID).Name,
                        car.ModelYear, car.DailyPrice, car.Description);
                }

                Console.WriteLine(str + "\n");
            }

            //Listing all cars registered in the system
            ShowAll(carManager.GetAll());

            //Registering a new car in the system
            Car car1 = new Car
            {
                ID = carManager.GetAll().Count + 1,
                BrandID = 2,
                ColorID = 3,
                ModelYear = 2014,
                DailyPrice = 165,
                Description = "Sunroof, Navigation System, Bluetooth"
            };

            carManager.Add(car1);
            ShowAll(carManager.GetAll());

            //Updating a car in the system
            Car carToUpdate = new Car
            {
                ID = 4,
                BrandID = 3,
                ColorID = 1,
                ModelYear = 2017,
                DailyPrice = 140,
                Description = "Sunroof, Navigation System, Bluetooth"
            };

            carManager.Update(carToUpdate);
            ShowAll(carManager.GetAll());

            //Removing a car from the system
            carManager.Delete(carManager.GetByID(3));
            ShowAll(carManager.GetAll());

            //Displaying a car by its ID in the system
            Show(carManager.GetByID(7));

            ////Displaying cars by BrandID in the system
            ShowAll(carManager.GetByBrandID(3));

            //Displaying cars by ColorID in the system
            ShowAll(carManager.GetByColorID(3));

            //Displaying cars by DailyPrice
            ShowAll(carManager.GetByDailyPrice(160, 210));

            //Adding deleted data again (ID = 3)
            Car car2 = new Car
            {
                ID = 3,
                BrandID = 2,
                ColorID = 4,
                ModelYear = 2007,
                DailyPrice = 75,
                Description = "Sunroof"
            };

            carManager.Add(car2);
            ShowAll(carManager.GetAll());
        }
    }
}