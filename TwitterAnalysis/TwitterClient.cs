using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;

namespace TwitterAnalysis
{
    internal class TwitterClient
    {

        private string base_url;
        public TwitterClient()
        {
            this.base_url = "https://api.twitter.com/2/";
        }

        public enum Timeline
        {
            ALL,
            RECENT
        }
        public async Task<TweetSearchResponse?> searchTweetsURL(Timeline timeline, string query)
        {
            string url = base_url;
            url += "tweets/search/";
            switch (timeline)
            {
                case Timeline.ALL:
                    url += "all";
                    break;
                case Timeline.RECENT:
                    url += "recent";
                    break;
            }

            string encoded = Uri.EscapeDataString(query);
            url += "?query=" + encoded;
            url += "&max_results=100";
            HttpClient WebClient = new HttpClient();
            WebClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Environment.GetEnvironmentVariable("BEARER_TOKEN"));
            HttpResponseMessage Response = await WebClient.GetAsync(url);
            string Content = await Response.Content.ReadAsStringAsync();
            TweetSearchResponse? TweetResponse = JsonConvert.DeserializeObject<TweetSearchResponse>(Content);
            return TweetResponse;
        }
    }
}
