using System;
using System.Collections.Generic;
using System.Text;
using VRChatApi.Classes;

namespace vrchat_active
{
    public class seruser
    {
        public string id { get; set; }
        public string username { get; set; }
        public string displayName { get; set; }
        public string currentAvatarThumbnailImageUrl { get; set; }
        public string status { get; set; }
        public List<string> tags { get; set; }
      
        public string statusDescription { get; set; }
        public string location { get; set; }

        public bool isFriend { get; set; }
      
        public DeveloperType developerType { get; set; }
        
    }
}
