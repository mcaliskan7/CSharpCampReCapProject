using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Color color)
        {
            _colorDal.Add(color);
            Console.WriteLine("Color Added Succesfully!\n");
        }

        public void Delete(Color color)
        {
            _colorDal.Delete(color);
            Console.WriteLine("Color Deleted Succesfully!\n");
        }

        public List<Color> GetAll()
        {
            Console.WriteLine("\tAll Colors in the System");
            return _colorDal.GetAll();
        }

        public Color GetByID(int ID)
        {
            return _colorDal.Get(c => c.ID == ID);
        }

        public void Update(Color color)
        {
            _colorDal.Update(color);
            Console.WriteLine("Color Updated Succesfully!\n");
        }
    }
}