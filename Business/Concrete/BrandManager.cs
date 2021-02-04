using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            if (brand.Name.Length >= 2)
            {
                _brandDal.Add(brand);
            }
            else
            {
                Console.WriteLine("Invalid Brand Name!");
            }
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetByID(int ID)
        {
            return _brandDal.Get(b => b.ID == ID);
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }
    }
}
