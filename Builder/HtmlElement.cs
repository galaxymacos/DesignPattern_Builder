using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    public class HtmlElement
    {
        public string name, text;
        public List<HtmlElement> Elements = new List<HtmlElement>();
        private const int indentSize = 2;

        public HtmlElement()
        {
            
        }

        public HtmlElement(string name, string text)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.text = text ?? throw new ArgumentNullException(nameof(text));
        }

        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ',indentSize * indent);
            sb.AppendLine($"{i}<{name}>");
            if (!string.IsNullOrWhiteSpace(text))
            {
                sb.Append(new string(' ', indentSize * (indent + 1)));
                sb.AppendLine(text);
                foreach (var element in Elements)
                {
                    sb.Append(element.ToStringImpl(indent + 1));
                }
            }
            
            sb.AppendLine($"{i}</{name}>");
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }
}