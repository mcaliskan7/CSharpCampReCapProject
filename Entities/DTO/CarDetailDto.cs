using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class CarDetailDto : IDto
    {
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }
}