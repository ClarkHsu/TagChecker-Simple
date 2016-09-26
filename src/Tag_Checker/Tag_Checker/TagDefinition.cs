using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Tag_Checker.Common;

namespace Tag_Checker
{
    /// <summary>
    /// Implement the interface of ITagDefination
    /// </summary>
    public class TagDefinition : ITagDefination
    {
        /// <summary>
        /// Provides specific defination of a tag:  An  opening  tag  is  enclosed  by  angle  brackets,  and contains exactly one upper case letter, for example <T>, <X>, <S>. The corresponding closing tag will be the same letter preceded by the symbol /; for the examples above these would be </T>, </X>, </S>
        /// </summary>
        /// <param name="strTag">Input string</param>
        /// <returns>Tag type</returns>
        public TagType TagCheck(string strTag)
        {
            if (StringUtility.IsContainUpper(strTag))
            {
                if (StringUtility.IsHasLengthOf(strTag, 3) && !strTag.Substring(1, 1).Equals("/") && strTag.Substring(strTag.Length - 1, 1).Equals(">"))
                {
                    return TagType.OpenTag;
                }
                else if (StringUtility.IsHasLengthOf(strTag, 4) && strTag.Substring(1, 1).Equals("/"))
                {
                    return TagType.ClosingTag;
                }
            }
            return TagType.None;
        }
    }
}
