﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterAnalysis.TwitterAPI
{
    internal class TweetSearchResponse
    {
        public List<Tweet>? Data { get; set; }
        public MetaData? Meta { get; set; }
    }
}