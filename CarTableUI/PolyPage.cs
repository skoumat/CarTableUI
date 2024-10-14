using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CarTableUI
{
    /// <summary>
    /// Třída, zajišťující potřebný polymorfismus.
    /// </summary>
    public abstract class PolyPage : Page
    {
        public PolyPage() { }

        public abstract void CreateTable(object sender, List<Car> cars, string fileName);

        public abstract void ErrorPopupControl(string message);
    }
}
