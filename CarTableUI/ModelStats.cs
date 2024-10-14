using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTableUI
{
    /// <summary>
    /// Třída pro tabulky zgroupovaných a agregovaných aut, aby se daly hodnoty vlastností nabindovat na DataGrid.
    /// </summary>
    public class ModelStats
    {
        public required string Model { get; set; }
        public required double Price { get; set; }
        public required double PriceWithVAT { get; set; }
    }
}
