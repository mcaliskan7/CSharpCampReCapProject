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
            Console.WriteLine("\n\t\t\t\t\t\t\t Welcome to the Car Rental System!\n\n");

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            CarManager carManager = new CarManager(new EfCarDal());

            //Functions to show cars
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


            //Functions to show brands
            void ShowBrand(Brand brand)
            {
                string str = new string('_', 50);
                Console.WriteLine(str + "\n\n\tID\t\tName\t");

                Console.WriteLine("\t{0}\t\t{1}\t", brand.ID, brand.Name);

                Console.WriteLine(str + "\n");
            }

            void ShowAllBrands(List<Brand> brands)
            {
                string str = new string('_', 50);
                Console.WriteLine(str + "\n\n\tID\t\tName\t");

                foreach (var brand in brands)
                {
                    Console.WriteLine("\t{0}\t\t{1}\t", brand.ID, brand.Name);
                }               

                Console.WriteLine(str + "\n");
            }


            //Functions to show colors
            void ShowColor(Color color)
            {
                string str = new string('_', 50);
                Console.WriteLine(str + "\n\n\tID\t\tName\t");

                Console.WriteLine("\t{0}\t\t{1}\t", color.ID, color.Name);

                Console.WriteLine(str + "\n");
            }

            void ShowAllColors(List<Color> colors)
            {
                string str = new string('_', 50);
                Console.WriteLine(str + "\n\n\tID\t\tName\t");

                foreach (var color in colors)
                {
                    Console.WriteLine("\t{0}\t\t{1}\t", color.ID, color.Name);
                }

                Console.WriteLine(str + "\n");
            }

            //Listing all cars registered in the system
            ShowAll(carManager.GetAll());

            //Registering a new car to the system
            Car car1 = new Car
            {
                BrandID = 2,
                ColorID = 3,
                ModelYear = 2014,
                DailyPrice = 170,
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
                DailyPrice = 145,
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
            ShowAll(carManager.GetByColorID(4));

            //Displaying cars by DailyPrice in the system
            ShowAll(carManager.GetByDailyPrice(170, 210));

            //Adding a new brand to the system
            Brand brand1 = new Brand
            {
                Name = "Dacia"
            };

            brandManager.Add(brand1);
            ShowAllBrands(brandManager.GetAll());

            //Displaying a brand by ID in the system
            ShowBrand(brandManager.GetByID(2));

            //Adding a new color to the system
            Color color1 = new Color
            {
                Name = "Green"
            };

            colorManager.Add(color1);
            ShowAllColors(colorManager.GetAll());

            //Displaying a color by ID in the system
            ShowColor(colorManager.GetByID(4));

            //Trying to add a brand whose name has less than 2 characters
            Brand brand2 = new Brand
            {
                Name = "A"
            };

            brandManager.Add(brand2);
            ShowAllBrands(brandManager.GetAll());

            //Trying to add a car whose daily price is not greater than zero
            Car car2 = new Car
            {
                BrandID = 2,
                ColorID = 1,
                ModelYear = 2011,
                DailyPrice = 0,
                Description = "Sunroof, Navigation System"
            };

            carManager.Add(car2);
            ShowAll(carManager.GetAll());
        }
    }
}