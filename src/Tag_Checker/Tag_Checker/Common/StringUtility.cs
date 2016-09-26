using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Tag_Checker.Common
{
    /// <summary>
    /// Tools to handle strings
    /// </summary>
    public sealed class StringUtility
    {
        public static bool IsContainUpper(string strInput)
        {
            return Regex.IsMatch(strInput, "[A-Z]");
        }

        public static bool IsHasLengthOf(string strInput,int iLengthExpected)
        {
            return strInput.Length == iLengthExpected;
        }
    }
}
