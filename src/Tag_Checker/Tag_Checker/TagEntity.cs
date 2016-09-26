using System;
using System.Collections.Generic;
using System.Text;

namespace Tag_Checker
{
    /// <summary>
    /// Entity of tags
    /// </summary>
    public class TagEntity
    {
        public TagEntity(string strTagContent)
        {
            TagContent = strTagContent;
        }
        public string TagContent
        {
            get;
            set;
        }
    }
}
