using System;
using System.Collections.Generic;
using System.Text;

namespace vrchat_active
{
    public class serwor
    {
        public string id { get; set; }
        public string name { get; set; }
        public string authorName { get; set; }
        public string thumbnailImageUrl { get; set; }
        public string description { get; set; }

        public DateTime created_at { get; set; }
        public DateTime updated_at{ get; set; }

        public int capacity { get; set; }
        public int favorites { get; set; }
        public int visits { get; set; }
        public int popularity { get; set; }
        public int heat { get; set; }
        public int occupants { get; set; }

        


    }
}
