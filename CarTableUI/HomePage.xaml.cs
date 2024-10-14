using System.Windows;

namespace CarTableUI
{
    /// <summary>
    /// Úvodní stránka, aby to vypadalo pekně.
    /// </summary>
    public partial class HomePage : PolyPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void LoadFileHome(object sender, RoutedEventArgs e)
        {
            LoadingAndMore.LoadFile(sender, this, e);
        }

        /// <summary>
        /// Otevře novou stránku, která má zobrazit tabulku.
        /// </summary>
        /// <param name="sender">Pro případnou expanzi.</param>
        /// <param name="cars">Nenulový seznam aut</param>
        public override void CreateTable(object sender, List<Car> cars, string fileName)
        {
            NavigationService.Navigate(new TablePage(cars, fileName));
        }

        public override void ErrorPopupControl(string message)
        {
            errorPopupText.Text = "Při načítání souboru se něco nepovedlo. \nChybová zpráva: " + message;
            errorPopup.IsOpen = true;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            errorPopup.IsOpen = false;
        }
    }
}
