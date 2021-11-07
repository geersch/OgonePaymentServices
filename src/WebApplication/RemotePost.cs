using System.Collections.Generic;
using System.Web;

namespace WebApplication
{
    public class RemotePost
    {
        private readonly Dictionary<string, string> values;

        public string Url { get; set; }
        public string Method { get; set; }
        public string FormName { get; set; }

        public RemotePost()
        {
            Method = "POST";
            FormName = "form1";
            values = new Dictionary<string, string>();
        }

        public void Add(string key, string value)
        {
            values.Add(key, value);
        }

        public void Post()
        {
            HttpContext context = HttpContext.Current;
            context.Response.Clear();
            context.Response.Write("<html><head>");
            context.Response.Write(string.Format("</head><body onload=\"document.{0}.submit()\">", FormName));
            context.Response.Write(string.Format("<form name=\"{0}\" method=\"{1}\" action=\"{2}\" >", FormName, Method, Url));
            foreach (KeyValuePair<string, string> element in values)
            {
                context.Response.Write(string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">", element.Key, element.Value));
            }
            context.Response.Write("</form>");
            context.Response.Write("</body></html>");
            context.Response.End();
        }
    }
}
