using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ContentTypeDescricaoAttribute : Attribute
    {
        public string content { get; set; }
        public ContentTypeDescricaoAttribute(string content)
        {
            this.content = content;
        }
    }
}
