using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Grupp_16
{
    class CategoryValidation : Exceptions
    {
        // Kontrollerar att kategorin inte redan existerar
        public override bool CheckIfItemInListAlreadyExists(List<string> klist, string name)
        {
            if (klist.Contains(name) == true)
            {
                throw (new Exception("The category already exists!"));
            }
            else
            {
                return false;
            }
        }

        // Kontrollerar att man fyllt i namn på podcast
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

        // Kontrollerar att man valt värde i listbox
        public override bool CheckIfSelected(ListBox listbox)
        {
            if (listbox.SelectedIndex == -1)
            {
                throw (new Exception("Make sure you have selected a item in the category listbox!"));
            }
            else
            {
                return false;
            }
        }
    }
}
