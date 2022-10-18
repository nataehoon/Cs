namespace FirstBlazorWeb.Models
{
    public class Pageitem
    {
        public string Text { get; set; }
        public int PageIndex { get; set; }
        public bool Enabled { get; set; }
        public bool Active { get; set; }

        public Pageitem(int pageIndex, bool enabled, string text)
        {
            Text = text;
            PageIndex = pageIndex;
            Enabled = enabled;
        }
    }
}
