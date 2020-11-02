using Grupp_16;
using System;
//using System.Windows.Controls;
using System.Windows.Forms;

namespace Grupp16
{
    public class PodcastValidation : Exceptions
    {
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

        //public static bool CheckTextField(params TextBox[] textBoxes)
        //{
        //    bool isValid = true;
        //    foreach (var textbox in textBoxes)
        //    {
        //        if (textbox.Text == "")
        //        {
        //            isValid = false;
        //        }
        //    }

        //    if (!isValid)
        //    {
        //        MessageBox.Show("You must enter a URL and a name for the podcast.");
        //    }
        //    return isValid;
        //}


    }
}