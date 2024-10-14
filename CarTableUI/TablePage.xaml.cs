using System.Windows;
using System.Windows.Controls;

namespace CarTableUI
{
    /// <summary>
    /// Nejdůležitější stránka s tabulkami.
    /// </summary>
    public partial class TablePage : PolyPage
    {
        public TablePage(List<Car> cars, string fileName)
        {
            InitializeComponent();
            DisplayFileName(fileName);
            DisplayCars(cars);
        }

        private void DisplayCars(List<Car> cars)
        {
            dataTable.ItemsSource = cars;

            DisplayCarGroups(cars);
        }

        private void DisplayCarGroups(List<Car> cars)
        {
            var modelGroups = cars
                .Where(car => car.SoldDate.DayOfWeek == DayOfWeek.Saturday || car.SoldDate.DayOfWeek == DayOfWeek.Sunday)
                .GroupBy(car => car.Model);

            var grouppedCars = new List<ModelStats>();

            foreach (var modelGroup in modelGroups)
            {
                var model = modelGroup.First().Model;                                       // vybere model auta
                var price = modelGroup.Aggregate((double)0, (total, next) => total += next.Price);  // sečte cenu bez DPH
                var priceWithVAT = modelGroup.Aggregate( (double)0, 
                    (total, next) => total += next.Price * (next.VAT / 100 + 1));           // sečte cenu s DPH

                grouppedCars.Add(new ModelStats { Model = model, Price = price, PriceWithVAT = priceWithVAT });
            }

            groupDataTable.ItemsSource = grouppedCars;
        }

        private void DisplayFileName(string fileName)
        {
            header.Text = "Soubor: " + fileName;
        }

        private void LoadFile(object sender, RoutedEventArgs e)
        {
            LoadingAndMore.LoadFile(sender, this, e);
        }

        public override void CreateTable(object sender, List<Car> cars, string fileName)
        {
            dataTable.ItemsSource = cars;
        }

        public override void ErrorPopupControl(string message)
        {
            errorPopupText.Text = "Při načítání souboru se něco nepovedlo. \nChybová zpráva: " + message;
            errorPopup.IsOpen = true;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            errorPopup.IsOpen = false;
        }
    }
}
