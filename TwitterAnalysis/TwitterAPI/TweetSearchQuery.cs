using System.Collections.Generic;

namespace TwitterAnalysis.TwitterAPI
{
    internal class TweetSearchQuery
    {

        private string query;
        private List<FilterItem> filters;

        public string Query
        {
            get { return query; }
        }

        public List<FilterItem> Filters
        {
            get { return filters; }
        }

        private string filter_string
        {
            get
            {
                string filter_string = "";

                for (int i = 0; i < filters.Count; i++)
                {
                    FilterItem filter_item = filters[i];
                    filter_string += " " + filter_item.ToString();
                }

                return filter_string;
            }
        }

        public override string ToString()
        {
            return query + filter_string;
        }
        public TweetSearchQuery(string query, List<FilterItem> filters)
        {
            this.query = query;
            this.filters = filters;
        }
    }
}
