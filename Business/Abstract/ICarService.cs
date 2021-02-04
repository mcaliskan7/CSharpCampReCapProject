using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        Car GetByID(int ID);
        List<Car> GetAll();
        List<Car> GetByBrandID(int brandID);
        List<Car> GetByColorID(int colorID);
        List<Car> GetByDailyPrice(decimal min, decimal max);
    }
}