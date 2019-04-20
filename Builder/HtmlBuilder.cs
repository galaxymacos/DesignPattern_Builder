namespace Builder
{
    public class HtmlBuilder
    {
        private readonly string rootName;
        HtmlElement root = new HtmlElement();

        public HtmlBuilder(string rootName)
        {
            this.rootName = rootName;
            root.name = rootName;
        }

        /// <summary>
        /// Attach a child html tag to the current tag
        /// </summary>
        /// <param name="childName">The</param>
        /// <param name="childText"></param>
        /// <returns>For fluent builder</returns>
        public HtmlBuilder AddChild(string childName, string childText)
        {
            var e = new HtmlElement(childName,childText);
            root.Elements.Add(e);
            return this;
        }

        public override string ToString()
        {
            return root.ToString();
        }

        public void Clear()
        {
            root = new HtmlElement {name = rootName};
        }
    }
}