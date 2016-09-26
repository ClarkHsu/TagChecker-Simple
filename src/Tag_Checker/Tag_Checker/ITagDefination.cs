using System;
using System.Collections.Generic;
using System.Text;
using Tag_Checker.Common;

namespace Tag_Checker
{
    /// <summary>
    /// Define a method to check whether input string is a valid tag.
    /// </summary>
    public interface ITagDefination
    {
        TagType TagCheck(string strTag);
    }
}
