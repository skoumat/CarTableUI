using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using CarsToXml;
using System.Runtime.ConstrainedExecution;

var table = """
    Název modelu (string) Datum prodeje (datetime) Cena (double) DPH (double)
    Škoda Oktávia 2.12.2010 500.000,- 20
    Škoda Felicia 3.12.2000 210.000,- 20
    Škoda Fabia 4.12.2010 350.000,- 20
    Škoda Oktávia 4.12.2010 500.000,- 20
    Škoda Oktávia 5.12.2010 500.000,- 20
    Škoda Fabia 5.12.2010 350.000,- 20
    Škoda Fabia 6.12.2010 350.000,- 20
    Škoda Forman 4.12.2000 100.000,- 19
    Škoda Favorit 5.12.2000 80.000,- 19
    Škoda Forman 6.12.2000 100.000,- 19
    Škoda Felicia 3.12.2000 210.000,- 19
    Škoda Felicia 2.12.2000 210.000,- 19
    Škoda Oktávia 7.12.2010 500.000,- 20
    """;

List<Car> cars = new List<Car> {
    new Car{Model = "Škoda Okávia", SoldDate = DateTime.Parse("2.12.2010"), Price = 500000, VAT = 20 },
    new Car{Model = "Škoda Felicia", SoldDate = DateTime.Parse("3.12.2000"), Price = 210000, VAT = 20 },
    new Car{Model = "Škoda Fabia", SoldDate = DateTime.Parse("4.12.2010"), Price = 350000, VAT = 20 },
    new Car{Model = "Škoda Oktávia", SoldDate = DateTime.Parse("4.12.2010"), Price = 500000, VAT = 20 },
    new Car{Model = "Škoda Oktávia", SoldDate = DateTime.Parse("5.12.2010"), Price = 500000, VAT = 20},
    new Car{Model = "Škoda Fabia", SoldDate = DateTime.Parse("5.12.2010"), Price = 350000, VAT = 20},
    new Car{Model = "Škoda Fabia", SoldDate = DateTime.Parse("6.12.2010"), Price = 350000, VAT = 20},
    new Car{Model = "Škoda Forman", SoldDate = DateTime.Parse("4.12.2000"), Price = 100000, VAT = 19},
    new Car{Model = "Škoda Favorit", SoldDate = DateTime.Parse("5.12.2000"), Price = 80000, VAT = 19},
    new Car{Model = "Škoda Forman", SoldDate = DateTime.Parse("6.12.2000"), Price = 100000, VAT = 19},
    new Car{Model = "Škoda Felicia", SoldDate = DateTime.Parse("3.12.2000"), Price = 210000, VAT = 19},
    new Car{Model = "Škoda Felicia", SoldDate = DateTime.Parse("2.12.2000"), Price = 210000, VAT = 19},
    new Car{Model = "Škoda Oktávia", SoldDate = DateTime.Parse("7.12.2010"), Price = 500000, VAT = 20},
};

string path = @"..\..\..\car_table.xml";

XmlSerializer serializer = new XmlSerializer(typeof(List<Car>));

using (TextWriter writer = new StreamWriter(path))
{
    serializer.Serialize(writer, cars);
}
