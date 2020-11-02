using System;
using System.Collections.Generic;

namespace Grupp_16
{
    class CategoryValidation : Exceptions
    {
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
    }
}
