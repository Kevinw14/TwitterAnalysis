using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterAnalysis.TwitterAPI
{
    internal class User
    {
        private string id;
        private string name;
        private string username;
        private bool is_verified;

        public string Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
        }

        public string Username
        {
            get { return username; }
        }

        public bool isVerified
        {
            get { return is_verified; }
        }
        public User(string id, string name, string username, bool is_verified)
        {
            this.id = id;
            this.name = name;
            this.username = username;
            this.is_verified = is_verified;
        }
    }
}
