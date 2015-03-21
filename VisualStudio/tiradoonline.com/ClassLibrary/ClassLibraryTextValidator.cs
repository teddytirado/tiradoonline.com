
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Web;
using System.Text;

namespace ClassLibraryNameSpace
{
    public class ClassLibraryTextValidator
    {

        public string FormatPhoneNumber(string strPhoneNumber)
        {
            StringBuilder sb = new StringBuilder();
            char currentLetter;


            for (int x = 0; x < strPhoneNumber.Length; x++)
            {
                currentLetter = Convert.ToChar(strPhoneNumber.Substring(x, 1));
                //REMOVE ALL NON NUMBERS
                if (char.IsDigit(currentLetter))
                    sb.Append(currentLetter);

            }

            if (sb.Length >= 10)
            {
                sb.Insert(0, "(");
                sb.Insert(4, ") ");
                sb.Insert(9, "-");
            }
            if (sb.Length > 14)
            {
                sb.Insert(14, " x");
            }
            return sb.ToString();
        }

        public static bool IsDup(string s)
        {
            if (string.IsNullOrEmpty(s)) return false;

            bool containsDupes = false;
            for (int i = 1; i < s.Length && !containsDupes; ++i)
            {
                containsDupes = s[i] == s[i - 1];
            }

            return containsDupes;
        }
        
        public static bool isDate(string strDate)
        {
            try
            {
                DateTime myDateTimeUS;
                CultureInfo format = new CultureInfo("en-US", true);
                myDateTimeUS = DateTime.Parse(strDate, format);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Function to validate an Email address
        public static bool isEmailAddress(string strEmail)
        {
            return Regex.IsMatch(strEmail, "^[A-Za-z0-9]([A-Za-z0-9_\\-\\.]*)@([A-Za-z0-9_\\-]+\\.)+[A-Za-z0-9_\\-]{1,4}$");
        }

        // Function to Check for Zip Code format
        public static bool isZipCode(string strZipCode)
        {
            return Regex.IsMatch(strZipCode, "^[0-9]{5}(-?[0-9]{4})?$");
        }

        // Function to Check for Numeric value
        public static bool isNumericValue(string strNumeric)
        {
            return Regex.IsMatch(strNumeric, "^([^.][-0-9.]+[^.-])$");
        }

        // Function to Check for Cross-Scripting/SQL Injections in Text
        public static bool isSafeText(string strTextToTest)
        {
            return Regex.IsMatch(strTextToTest, "^[\\w\\s\\,\\.\\#\\-]*$");
        }

        // Function to Check for Cross-Scripting/SQL Injections in Links
        public static bool isSafeLink(string strLinkToTest)
        {
            return Regex.IsMatch(strLinkToTest, "^[\\w\\s\\,\\#]*$");
        }

        // Function to Check for the Maximum string count
        public static bool isMaxCount(string strTextToCount, int intMaxCount)
        {
            return (strTextToCount.Length > intMaxCount) ? true : false;
        }

        // Function to Check for Alpha
        public static bool isAlpha(string strToCheck)
        {
            return Regex.IsMatch(strToCheck, "[^a-zA-Z]");
        }

        // Function to Check for AlphaNumeric
        public static bool isAlphaNumeric(string strToCheck)
        {
            return Regex.IsMatch(strToCheck, "[^a-zA-Z0-9]");
        }

        // Function to Test for Integers both Positive & Negative
        public static bool isInteger(string strNumber)
        {
            Regex objNotIntPattern = new Regex("[^0-9-]");
            Regex objIntPattern = new Regex("^-[0-9]+$|^[0-9]+$");

            return !objNotIntPattern.IsMatch(strNumber) &&
                objIntPattern.IsMatch(strNumber);
        }

        // Function to test whether the string is valid number or not
        public static bool isNumber(string strNumber)
        {
            Regex objNotNumberPattern = new Regex("[^0-9.-]");
            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
            string strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
            string strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
            Regex objNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");

            return !objNotNumberPattern.IsMatch(strNumber) &&
                !objTwoDotPattern.IsMatch(strNumber) &&
                !objTwoMinusPattern.IsMatch(strNumber) &&
                objNumberPattern.IsMatch(strNumber);
        }

        // Function to Test for Positive Number both Integer & Real
        public static bool isPositiveNumber(string strNumber)
        {
            Regex objNotPositivePattern = new Regex("[^0-9.]");
            Regex objPositivePattern = new Regex("^[.][0-9]+$|[0-9]*[.]*[0-9]+$");
            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");

            return !objNotPositivePattern.IsMatch(strNumber) &&
                objPositivePattern.IsMatch(strNumber) &&
                !objTwoDotPattern.IsMatch(strNumber);
        }

        // Function to test for Positive Integers
        public static bool isNaturalNumber(string strNumber)
        {
            Regex objNotNaturalPattern = new Regex("[^0-9]");
            Regex objNaturalPattern = new Regex("0*[1-9][0-9]*");

            return !objNotNaturalPattern.IsMatch(strNumber) &&
                objNaturalPattern.IsMatch(strNumber);
        }

        // Function to test for Positive Integers with zero inclusive
        public static bool isWholeNumber(string strNumber)
        {
            Regex objNotWholePattern = new Regex("[^0-9]");
            return !objNotWholePattern.IsMatch(strNumber);
        }

        // Function to test for Currency
        public static bool isCurrency(string strToCheck)
        {
            return Regex.IsMatch(strToCheck, @"^(-)?\d+(\.\d\d)?$");
        }

        /// <summary>
        /// Function to test to make sure a Password is valid, it must be between the minimum and maximum characters and contain at least one number or special character [@*$#!]
        /// </summary>
        /// <param name="strToCheck"></param>
        /// <returns></returns>
        public static bool isPasswordAcceptable(string strToCheck, int intMinLength, int intMaxLength)
        {
            return Regex.IsMatch(strToCheck, @"^(?=.*[0-9@*$#!]+.*)(?=.*[a-zA-Z]+.*)[0-9a-zA-Z@*$#!]{" + intMinLength.ToString() + "," + intMaxLength.ToString() + "}$");
            //^(?=.*[0-9@*$#!]+.*)(?=.*[a-zA-Z]+.*)[0-9a-zA-Z@*$#!]{4,}$
        }

        public static bool isEntered(string strTextEntered)
        {
            if (strTextEntered == "")
                return false;
            else
                return true;
        }


    }

}