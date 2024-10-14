using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace CarTableUI
{
    /// <summary>
    /// Společná logika.
    /// </summary>
    public static class LoadingAndMore
    {
        // TODO: možnost přidat seznam dříve navstivenych tabulek a moznost se vracet
        public static void LoadFile(object sender, PolyPage senderPage, RoutedEventArgs e)
        {
            OpenFileDialog dialogWindow = new OpenFileDialog();
            dialogWindow.Filter = "xml files (*.xml)|*.xml";    // filtrujeme pouze XML dokumenty

            if (dialogWindow.ShowDialog() == true)              // pokud byl vybrán soubor
            {
                DeserializeCarsFromXml(sender, senderPage, dialogWindow.FileName, dialogWindow.SafeFileName);
            }
        }

        /// <summary>
        /// Deserializuje soubor, ověří správnost a buď přepošle požadavek na vytvoření tabulky, nebo předá chybovou zprávu.
        /// </summary>
        private static void DeserializeCarsFromXml(object sender, PolyPage senderPage, string filePath, string fileName)
        {
            List<Car>? cars = null;

            XmlSerializer serializer = new XmlSerializer(typeof(List<Car>));
            using (TextReader reader = new StreamReader(filePath))
            {
                try
                {
                    cars = serializer.Deserialize(reader) as List<Car>;
                }
                catch (Exception ex)    // pokud se vyskytne chyba
                {
                    string msg = ex.Message;        // zpracujeme zprávu
                    if (ex.InnerException != null)  // i zprávu vnitřní výjimky
                        msg = "\n\t" + msg + "\n\t" + ex.InnerException.Message;

                    senderPage.ErrorPopupControl(msg);  // a pošleme ji příslušné stránce
                    return;
                }

                if (cars == null)       // pokud se něco nepovede při deserializaci 
                {
                    senderPage.ErrorPopupControl("Deserializer returned null. Try repeating the action.");  // pošleme chybu příslušné stránce
                    return;
                }
                
                foreach (Car car in cars)   // zkotrolujeme všechna auta
                {
                    if (car.Model == null)  // jestli náhodou není nekompletní seznam a pokud ano
                    {
                        senderPage.ErrorPopupControl("Incomplete data");  // pošleme chybu příslušné stránce
                        return;
                    }
                }
                
                senderPage.CreateTable(sender, cars, fileName);
            }
        }
    }
}
