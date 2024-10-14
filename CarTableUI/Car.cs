using System.Xml.Serialization;

namespace CarTableUI
{
    public class Car
    {
        /// <summary>
        /// Třída, do které deserializujeme.
        /// </summary>
        public Car() { }

        public required string Model { get; set; }
        public required double Price { get; set; }
        public required double VAT { get; set; }

        [XmlElement(ElementName = "SoldDate")]
        public required DateTime SoldDateTime { get; set; }

        public DateOnly SoldDate
        {
            get { return DateOnly.FromDateTime((DateTime)SoldDateTime); }
        }        
    }
}
