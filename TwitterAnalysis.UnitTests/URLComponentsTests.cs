using System;

namespace TwitterAnalysis.UnitTests
{
    [TestClass]
    public class URLComponentsTests
    {
        [TestMethod]
        public void URLComponents_BuildRadfordUniversityTwitterURL()
        {
            URLComponents Component = new URLComponents();
            Component.Protocol = "https";
            Component.BaseURL = "api.twitter.com";
            Component.Path = "/2/tweets/search/recent";
            List<QueryItem> QueryItems = new List<QueryItem>();
            QueryItems.Add(new QueryItem("query", "Radford University"));
            string URL = Component.URL;
            Assert.AreEqual(URL, "https://api.twitter.com/2/tweets/search/recent?query=Radford%20University");
        }
    }
}