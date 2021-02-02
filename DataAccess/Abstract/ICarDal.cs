﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        void Add(Car car);
        void Update(Car car);
        void Delete(int carID);
        void GetByID(int carID);
        void GetAll();
    }
}