using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace denolk.GitNotifierLibrary.Model
{
    public class GitPayload
    {
        public Repository repository { get; set; }
        public List<Commit> commits { get; set; }


        public class Repository
        {
            public string url { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public Owner owner { get; set; }

            public class Owner
            {
                public string email { get; set; }
                public string name { get; set; }
            }
        }



        public class Commit
        {
            public string id { get; set; }
            public string url { get; set; }
            public Author author { get; set; }
            public string message { get; set; }
            public string timestamp { get; set; }
            public List<string> added { get; set; }

            public class Author
            {
                public string email { get; set; }
                public string name { get; set; }
            }
        }




    }
}
