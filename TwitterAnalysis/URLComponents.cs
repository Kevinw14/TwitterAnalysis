using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TwitterAnalysis
{
    public class URLComponents
    {
        public string Protocol { get; set; }

        public string BaseURL { get; set; }
        public string Path { get; set; }
        public List<QueryItem> QueryItems { get; set; }
        public string URL
        {
            get
            {
                string url = Protocol + "://" + BaseURL + Path;

                for (int i = 0; i < QueryItems.Count; i++)
                {
                    if (i == 0)
                    {
                        url += "?";
                    }

                    QueryItem item = QueryItems[i];
                    string Param = item.Key + "=" + item.Value;
                    string EncodedParam = HttpUtility.UrlPathEncode(Param);
                    url += EncodedParam;

                    if (i != QueryItems.Count - 1)
                    {
                        url += "&";
                    }
                }
                return url;
            }
        }

        public URLComponents()
        {
            this.Protocol = "";
            this.BaseURL = "";
            this.Path = "";
            this.QueryItems = new List<QueryItem>();
        }

        public URLComponents(string protocol, string baseURL, string path, List<QueryItem> queryItems)
        {
            Protocol = protocol;
            BaseURL = baseURL;
            Path = path;
            QueryItems = queryItems;
        }

        public URLComponents(string protocol, string baseURL, string path)
        {
            this.Protocol = protocol;
            this.BaseURL = baseURL;
            this.Path = path;
            this.QueryItems = new List<QueryItem>();
        }
    }
}
