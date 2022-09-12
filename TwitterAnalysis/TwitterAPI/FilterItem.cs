using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Filter
{
    RETWEET,
    MENTION,
    HASHTAGS
}
namespace TwitterAnalysis.TwitterAPI
{
    internal class FilterItem
    {
        private bool is_included;
        private Filter filter;

        public bool isIncluded
        {
            get { return is_included; }
        }

        public Filter Filter
        {
            get { return filter; }
        }
        public FilterItem(bool is_included, Filter filter)
        {
            this.is_included = is_included;
            this.filter = filter;
        }

        public override string ToString()
        {
            switch (filter)
            {
                case Filter.RETWEET:
                    if (is_included)
                    {
                        return "is:retweet";
                    }
                    else
                    {
                        return "-is:retweet";
                    }
                case Filter.MENTION:
                    if (is_included)
                    {
                        return "is:mention";
                    }
                    else
                    {
                        return "-is:mention";
                    }
                case Filter.HASHTAGS:
                    if (is_included)
                    {
                        return "has:hashtags";
                    } else
                    {
                        return "-has:hastags";
                    }
            }
            return "";
        }
    }
}
