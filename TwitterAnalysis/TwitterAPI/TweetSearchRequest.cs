using System.Collections.Generic;
using System.Security.Policy;

public enum Expansion
{
    ATTACHMENTS_MEDIA_KEYS,
    ATTACHMENTS_POLL_IDS,
    AUTHOR_ID,
    ENTITIES_MENTIONS_USERNAME,
    GEO_PLACE_ID,
    IN_REPLY_TO_USER_ID,
    REFERENCED_TWEETS_ID,
    REFERENCED_TWEETS_ID_AUTHOR_ID
}

public enum PlaceFields
{
    CONTAINED_WITHIN,
    COUNTRY,
    COUNTRY_CODE,
    FULL_NAME,
    GEO,
    ID,
    NAME,
    PLACE_TYPE
}

public enum UserFields
{
    CREATED_AT,
    DESCRIPTION,
    ENTITIES,
    ID,
    LOCATION,
    NAME,
    PINNED_TWEET_ID,
    PROFILE_IMAGE_URL,
    PROTECTED,
    PUBLIC_METRICS,
    URL,
    USERNAME,
    VERIFIED,
    WITHHELD
}

public enum PollFields
{
    DURATION_MINUTES,
    END_DATETIME,
    ID,
    OPTIONS,
    VOTING_STATUS
}

public enum MediaFields
{
    ALT_TEXT,
    DURATION_MS,
    HEIGHT,
    MEDIA_KEY,
    NON_PUBLIC_METRICS,
    ORGANIC_METRICS,
    PREVIEW_IMAGE_URL,
    PROMOTED_METRICS,
    PUBLIC_METRICS,
    TYPE,
    URL,
    VARIANTS,
    WIDTH
}

public enum TweetFields
{
    ATTACHMENTS,
    AUTHOR_ID,
    CONTEXT_ANNOTATIONS,
    CONVERSATION_ID,
    CREATED_AT,
    ENTITIES,
    GEO,
    ID,
    IN_REPLY_TO_USER_ID,
    LANG,
    NON_PUBLIC_METRICS,
    POSSIBLY_SENSITIVE,
    PROMOTED_METRICS,
    PUBLIC_METRICS,
    REFERENCED_TWEETS,
    REPLY_SETTINGS,
    SOURCE,
    TEXT,
    WITHHELD
}

public enum Timeline
{
    ALL,
    RECENT
}

namespace TwitterAnalysis.TwitterAPI
{
    internal class TweetSearchRequest
    {
        private Timeline timeline;
        private List<Expansion>? expansions;
        private List<PlaceFields>? place_fields;
        private List<UserFields>? user_fields;
        private List<PollFields>? poll_fields;
        private List<MediaFields>? media_fields;
        private List<TweetFields>? tweet_fields;
        private List<TweetSearchQuery> queries;
        private int max_results;

        public Timeline Timeline
        {
            get { return timeline; }
        }

        public List<Expansion>? Expansions
        {
            get { return expansions; }
        }

        public List<PlaceFields>? PlaceFields
        {
            get { return place_fields; }
        }

        public List<UserFields>? UserFields
        {
            get { return user_fields; }
        }

        public List<PollFields>? PollFields
        {
            get { return poll_fields; }
        }

        public List<MediaFields>? MediaFields
        {
            get { return media_fields; }
        }

        public List<TweetFields>? TweetFields
        {
            get { return tweet_fields; }
        }

        public List<TweetSearchQuery> Queries
        {
            get { return queries;  }
        }

        public int MaxResults
        {
            get { return max_results; }
        }
        public TweetSearchRequest(Timeline timeline, List<Expansion>? expansions, 
            List<PlaceFields>? place_fields, List<UserFields>? user_fields,
            List<PollFields>? poll_fields, List<MediaFields>? media_fields,
            List<TweetFields>? tweet_fields, List<TweetSearchQuery> queries,
            int max_results = 10)
        {
            this.timeline = timeline;
            this.expansions = expansions;
            this.place_fields = place_fields;
            this.user_fields = user_fields;
            this.poll_fields = poll_fields;
            this.media_fields = media_fields;
            this.tweet_fields = tweet_fields;
            this.queries = queries;
            this.max_results = max_results;
        }

        public string QueryString
        {
            get
            {
                string queryString = "";
                for (int i = 0; i < queries.Count; i++)
                {
                    TweetSearchQuery query = queries[i];
                    if (i == queries.Count - 1)
                    {
                        queryString += query.ToString();
                    } else
                    {
                        queryString += query.ToString() + " ";
                    }
                }
                return queryString;
            }
        }
    }
}
