using Grupp_16;
using System;
//using System.Windows.Controls;
using System.Windows.Forms;

namespace Grupp16
{
    public class PodcastValidation : Exceptions
    {
        //Kontrollerar om inmatad URL är giltig
        public override bool CheckIfValidURL(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw (new Exception("Please check if the url is written the right way!"));
            }
            else
            {
                return false;
            }
        }

        //Kontrollerar att inmatat värde ej är tomt
        public override bool CheckIfTheInputIsEmpty(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw (new Exception("Please fill in the podcast name!"));
            }
            else
            {
                return false;
            }
        }

        // Kontrollerar att det finns ett värde i comboboxen
        public override bool CheckIfTheInputIsEmptyComboBox(ComboBox cb)
        {
            if (cb.SelectedItem == null)
            {
                throw (new Exception("Make sure the comboboxes is not empty!"));
            }
            else
            {
                return false;
            }
        }

        //Kontrollerar att man valt värde i listbox
        public override bool CheckIfSelected(ListBox listbox)
        {
            if (listbox.SelectedIndex == -1)
            {
                throw (new Exception("Make sure you have selected a item in the podcast listbox!"));
            }
            else
            {
                return false;
            }
        }
    }
}