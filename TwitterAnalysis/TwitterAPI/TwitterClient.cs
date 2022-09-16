using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Collections.Specialized;
using System.Windows;
using System.Collections.Generic;

namespace TwitterAnalysis.TwitterAPI
{
    internal class TwitterClient
    {
        private string? bearer_token;
        public TwitterClient(string? bearer_token)
        {
            this.bearer_token = bearer_token;
        }
        public async Task<TweetSearchResponse?> searchTweetsURL(TweetSearchRequest search_request)
        {
            URLComponents Components = new URLComponents();
            Components.Protocol = "https";
            Components.BaseURL = "api.twitter.com";

            switch (search_request.Timeline)
            {
                case Timeline.ALL:
                    Components.Path = "/2/tweets/search/all";
                    break;
                case Timeline.RECENT:
                    Components.Path = "/2/tweets/search/recent";
                    break;
            }

            MessageBox.Show(HttpUtility.UrlPathEncode("query=Radford University"));
            List<QueryItem> QueryItems = new List<QueryItem>();
            QueryItems.Add(new QueryItem("query", search_request.QueryString));
            Components.QueryItems = QueryItems;
            string url = Components.URL;
            MessageBox.Show(url);
            HttpClient WebClient = new HttpClient();
            WebClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer_token);
            HttpResponseMessage Response = await WebClient.GetAsync(url);
            string Content = await Response.Content.ReadAsStringAsync();
            TweetSearchResponse? TweetResponse = JsonConvert.DeserializeObject<TweetSearchResponse>(Content);
            return TweetResponse;
        }
    }
}
