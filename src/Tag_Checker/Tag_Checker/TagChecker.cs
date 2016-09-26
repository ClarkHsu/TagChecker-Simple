using System;
using System.Collections.Generic;
using System.Text;
using Tag_Checker.Common;

namespace Tag_Checker
{
    /// <summary>
    /// Tags check class
    /// </summary>
    public class TagsChecker
    {
        //Be used to check valid tag by specific defination
        ITagDefination tagUtility { get; set; }
        /// <summary>
        /// Check the closing condition of a string paragraph
        /// </summary>
        /// <param name="strParagraph">Input paragraph</param>
        /// <returns>a string showing the check result</returns>
        public string Check(string strParagraph)
        {
            if(string.IsNullOrEmpty(strParagraph))
            {
                return "";
            }
            //Expected closing tag stack, FIFO
            List<TagEntity> closingTagStack = new List<TagEntity>();

            //returning result
            string strResult = "Correctly tagged paragraph";
            //Be used to store truncate string
            StringBuilder strTemp = new StringBuilder();
            //Be used to find the position of tag
            char current = ' ';

            for (int i = 0; i < strParagraph.Length; )
            {
                current = strParagraph[i++];

                if (current == '<')
                {
                    //if a '<' exists, then try to truncate a piece of string by searching the '>'
                    while (current != '>' && i < strParagraph.Length)
                    {
                        strTemp.Append(current);
                        current = strParagraph[i++];
                        if (current == '<')
                        {
                            i--;
                            break;
                        }
                    }
                    strTemp.Append(current);

                    string tagContent = strTemp.ToString();
                    strTemp = new StringBuilder();

                    //Check whether the truncated string is a valid tag
                    TagType tempTag = tagUtility.TagCheck(tagContent);

                    //If it is a open tag, then we put the expected corresponding closing tag to first position of tag stack.
                    if (tempTag == TagType.OpenTag)
                    {
                        closingTagStack.Insert(0, new TagEntity(tagContent.Insert(1, "/")));
                    }
                    //If it is a closing tag, we should check the tag stack to ensure it should be here.
                    else if (tempTag == TagType.ClosingTag)
                    {
                        //If the tag stack has elements
                        if (closingTagStack.Count > 0)
                        {
                            //Check the validity of closing tag: if the closing tag is expected here, remove ot form the stack
                            if (closingTagStack[0].TagContent.Equals(tagContent))
                            {
                                closingTagStack.Remove(closingTagStack[0]);
                            }
                            //If another closing tag is expected here, then a wrong nested tag may happen
                            else
                            {
                                strResult = "Expected " + closingTagStack[0].TagContent + " found " + tagContent;
                                return strResult;
                            }
                        }
                        //If the tag stack is empty, then a open tag missing happens
                        else
                        {
                            strResult = "Expected # found " + tagContent;
                            return strResult;
                        }
                    }
                }
                //By the end of paragraph, if the tag stack is still not empty, then a closing tag missing happens
                if ((i >= strParagraph.Length - 1) && closingTagStack.Count > 0)
                {
                    strResult = "Expected " + closingTagStack[0].TagContent + " found #";
                }
            }
            return strResult;
        }
    }
}
