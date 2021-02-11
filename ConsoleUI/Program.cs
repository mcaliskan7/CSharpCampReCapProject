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

            //Test Functions for Car Operations
            //GetCarDetailsTest();
            //GetCarByIdTest(id);
            //GetCarsByBrandIdTest(brandId);
            //GetCarsByColorIdTest(colorId);
            //GetCarsByDailyPriceTest(min, max);
            //GetAllCarsTest();
            //AddCarTest();
            //DeleteCarTest();
            //UpdateCarTest();

            //Test Functions for Brand Operations
            //GetBrandByIdTest(id);
            //GetAllBrandsTest();
            //AddBrandTest();
            //DeleteBrandTest();
            //UpdateBrandTest();

            //Test Functions fot Color Operations
            //GetColorByIdTest(id);
            //GetAllColorsTest();
            //AddColorTest();
            //DeleteColorTest();
            //UpdateColorTest();

            //Displaying all cars' details
            GetCarDetailsTest();

            //Registering a new car to the system
            Car car1 = new Car
            {
                BrandId = 4,
                ColorId = 1,
                ModelYear = 2021,
                DailyPrice = 300,
                Description = "Rentable"
            };

            AddCarTest(car1);
            GetAllCarsTest();

            //Updating a car in the system
            Car carToUpdate = new Car
            {
                Id = 4,
                BrandId = 3,
                ColorId = 1,
                ModelYear = 2017,
                DailyPrice = 145,
                Description = "Rentable"
            };

            UpdateCarTest(carToUpdate);
            GetAllCarsTest();

            //Removing a car from the system
            DeleteCarTest(6);
            GetAllCarsTest();

            //Displaying a car by its ID in the system
            GetCarByIdTest(7);

            //Displaying cars by BrandID in the system
            GetCarsByBrandIdTest(2);

            //Displaying cars by ColorID in the system            
            GetCarsByColorIdTest(3);

            //Displaying cars by DailyPrice in the system
            GetCarsByDailyPriceTest(170, 210);

            //Adding a new brand to the system
            Brand brand1 = new Brand
            {
                Name = "Dacia"
            };

            AddBrandTest(brand1);
            GetAllBrandsTest();

            //Updating a brand in the system
            Brand brandToUpdate = new Brand
            {
                Id = 1,
                Name = "BMW"
            };

            UpdateBrandTest(brandToUpdate);
            GetAllBrandsTest();

            //Removing a brand from the system
            DeleteBrandTest(3005);
            GetAllBrandsTest();

            //Displaying a brand by ID in the system
            GetBrandByIdTest(2);

            //Adding a new color to the system
            Color color1 = new Color
            {
                Name = "Green"
            };

            AddColorTest(color1);
            GetAllColorsTest();

            //Updating a color in the system
            Color colorToUpdate = new Color
            {
                Id = 4,
                Name = "Blue"
            };

            UpdateColorTest(colorToUpdate);
            GetAllColorsTest();

            //Removing a color from the system
            DeleteColorTest(3005);
            GetAllColorsTest();

            //Displaying a color by ID in the system
            GetColorByIdTest(1);

            //Trying to add a brand whose name has less than 2 characters
            Brand brand2 = new Brand
            {
                Name = "A"
            };

            AddBrandTest(brand2);
            GetAllBrandsTest();

            //Trying to add a car whose daily price is not greater than zero
            Car car2 = new Car
            {
                BrandId = 2,
                ColorId = 1,
                ModelYear = 2011,
                DailyPrice = 0,
                Description = "Rentable"
            };

            AddCarTest(car2);
            GetAllCarsTest();
        }

        private static void GetAllColorsTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            var result = colorManager.GetAll();

            if (result.Success == true)
            {
                Console.WriteLine("\tAll Colors in the System");
                string str = new string('_', 50);
                Console.WriteLine(str + "\n\n\tID\t\tName\t");

                foreach (var color in result.Data)
                {
                    Console.WriteLine("\t{0}\t\t{1}\t", color.Id, color.Name);
                }

                Console.WriteLine(str + "\n");
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetColorByIdTest(int id)
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            var result = colorManager.GetById(id);
            Color colorbyId = result.Data;

            if (result.Success == true)
            {
                string str = new string('_', 50);
                Console.WriteLine(str + "\n\n\tID\t\tName\t");

                Console.WriteLine("\t{0}\t\t{1}\t", colorbyId.Id, colorbyId.Name);

                Console.WriteLine(str + "\n");
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetAllBrandsTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var result = brandManager.GetAll();

            if (result.Success == true)
            {
                Console.WriteLine("\tAll Brands in the System");
                string str = new string('_', 50);
                Console.WriteLine(str + "\n\n\tID\t\tName\t");

                foreach (var brand in result.Data)
                {
                    Console.WriteLine("\t{0}\t\t{1}\t", brand.Id, brand.Name);
                }

                Console.WriteLine(str + "\n");
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetBrandByIdTest(int id)
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var result = brandManager.GetById(id);
            Brand brandById = result.Data;

            if (result.Success == true)
            {
                string str = new string('_', 50);
                Console.WriteLine(str + "\n\n\tID\t\tName\t");

                Console.WriteLine("\t{0}\t\t{1}\t", brandById.Id, brandById.Name);

                Console.WriteLine(str + "\n");
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetAllCarsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetAll();

            if (result.Success == true)
            {
                Console.WriteLine("\t\t\t\t\t\t\t\tAll Cars in the System");
                string str = new string('_', 180);
                Console.WriteLine(str + "\n\n" +
                                  "\tId\t\tBrandId\t\tColorId\t\tModelYear\tDailyPrice\tDescription\t");

                foreach (var car in result.Data)
                {
                    Console.WriteLine("\t{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}\t",
                         car.Id, car.BrandId, car.ColorId,
                         car.ModelYear, car.DailyPrice, car.Description);
                }

                Console.WriteLine(str + "\n");
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetCarByIdTest(int id)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetById(id);
            Car carById = result.Data;

            if (result.Success == true)
            {
                Console.WriteLine("Car whose Id is {0}", id);
                string str = new string('_', 180);
                Console.WriteLine(str + "\n\n" + "\tId\t\tBrandId\t\tColorId\t\tModelYear\tDailyPrice\tDescription\t");

                Console.WriteLine("\t{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}\t",
                      carById.Id, carById.BrandId, carById.ColorId,
                      carById.ModelYear, carById.DailyPrice, carById.Description);

                Console.WriteLine(str + "\n");
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetCarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            
            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {
                Console.WriteLine("\t\t\t\t\t\t\t\tCar Details");
                string str = new string('_', 180);

                Console.WriteLine(str + "\n\n" +
                                      "\tId\t\tBrand\t\tColor\t\tPrice\t\tStatus\t");

                foreach (var detail in result.Data)
                {
                    Console.WriteLine("\t{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t",
                        detail.CarId, detail.BrandName, detail.ColorName,
                        detail.DailyPrice, detail.Description);
                }

                Console.WriteLine(str + "\n");
            }
            else
            {
                Console.WriteLine(result.Message);
            }          
        }

        private static void GetCarsByBrandIdTest(int brandId)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetByBrandId(brandId);
            List<Car> carsByBrandId = result.Data;

            if (result.Success == true)
            {
                Console.WriteLine("Car whose BrandId is {0}", brandId);
                string str = new string('_', 180);
                Console.WriteLine(str + "\n\n" + "\tId\t\tBrandId\t\tColorId\t\tModelYear\tDailyPrice\tDescription\t");

                foreach (var car in carsByBrandId)
                {
                    Console.WriteLine("\t{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}\t",
                      car.Id, car.BrandId, car.ColorId,
                      car.ModelYear, car.DailyPrice, car.Description);
                }

                Console.WriteLine(str + "\n");
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetCarsByColorIdTest(int colorId)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetByColorId(colorId);
            List<Car> carsByColorId = result.Data;

            if (result.Success == true)
            {
                Console.WriteLine("Car whose ColorId is {0}", colorId);
                string str = new string('_', 180);
                Console.WriteLine(str + "\n\n" + "\tId\t\tBrandId\t\tColorId\t\tModelYear\tDailyPrice\tDescription\t");

                foreach (var car in carsByColorId)
                {
                    Console.WriteLine("\t{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}\t",
                      car.Id, car.BrandId, car.ColorId,
                      car.ModelYear, car.DailyPrice, car.Description);
                }

                Console.WriteLine(str + "\n");
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetCarsByDailyPriceTest(int min, int max)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetByDailyPrice(min, max);
            List<Car> carsByDailyPrice = result.Data;

            if (result.Success == true)
            {
                Console.WriteLine("Car whose DailyPrice is greater than {0} and less than {1}", min, max);
                string str = new string('_', 180);
                Console.WriteLine(str + "\n\n" + "\tId\t\tBrandId\t\tColorId\t\tModelYear\tDailyPrice\tDescription\t");

                foreach (var car in carsByDailyPrice)
                {
                    Console.WriteLine("\t{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}\t",
                      car.Id, car.BrandId, car.ColorId,
                      car.ModelYear, car.DailyPrice, car.Description);
                }

                Console.WriteLine(str + "\n");
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void AddCarTest(Car car)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.Add(car);

            Console.WriteLine(result.Message);
        }

        private static void DeleteCarTest(int id)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.Delete(carManager.GetById(id).Data);

            Console.WriteLine(result.Message);
        }

        private static void UpdateCarTest(Car car)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.Update(car);

            Console.WriteLine(result.Message);
        }

        private static void AddBrandTest(Brand brand)
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var result = brandManager.Add(brand);

            Console.WriteLine(result.Message);
        }

        private static void DeleteBrandTest(int id)
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var result = brandManager.Delete(brandManager.GetById(id).Data);

            Console.WriteLine(result.Message);
        }

        private static void UpdateBrandTest(Brand brand)
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var result = brandManager.Update(brand);

            Console.WriteLine(result.Message);
        }

        private static void AddColorTest(Color color)
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            var result = colorManager.Add(color);

            Console.WriteLine(result.Message);
        }

        private static void DeleteColorTest(int id)
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            var result = colorManager.Delete(colorManager.GetById(id).Data);

            Console.WriteLine(result.Message);
        }

        private static void UpdateColorTest(Color color)
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            var result = colorManager.Update(color);

            Console.WriteLine(result.Message);
        }
    }
}