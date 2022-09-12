using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Collections.Specialized;
using System.Windows;

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
            UriBuilder uri_builder = new UriBuilder();
            uri_builder.Scheme = "http";
            uri_builder.Host = "api.twitter.com";

            switch (search_request.Timeline)
            {
                case Timeline.ALL:
                    uri_builder.Path = "/2/tweets/search/all";
                    break;
                case Timeline.RECENT:
                    uri_builder.Path = "/2/tweets/search/recent";
                    break;
            }
            string url = uri_builder.ToString() + search_request.QueryString;
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
