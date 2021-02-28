using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace vrchat_active
{
	public class user
	{
        public bool notworld { get; set; }
        public string map { get; set; }
        public int map2 { get; set; }
       
        public string usid { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string ImageUrl { get; set; }
        public string Locationimg { get; set; }
        public string location { get; set; }
        public string usNa { get; set; }
        public string mapuri { get; set; }
        public string mapinst { get; set; }
        public string statu { get; set; }
        public string TrustLevel { get; set; }
        public List<string> ustags { get; set; }//

        public string Trustcol { get; set; }
        public string instcol { get; set; }


        public string statusDescription { get; set; }

        public string date_joined { get; set; }
        
        public string bio { get; set; }
        public string authorName { get; set; }



    }
}
