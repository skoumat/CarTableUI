using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsToXml
{
    public class Car
    {
        public Car() { }
        public string Model { get; set; }
        public DateTime SoldDate { get; set; }
        public double Price { get; set; }
        public double VAT { get; set; }
    }
}
