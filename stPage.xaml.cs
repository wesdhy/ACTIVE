using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRChatApi.Classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace vrchat_active.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class stPage : ContentPage
    {
        VRChatApi.VRChatApi api;
        public string id { get; set; }
        public string displayName { get; set; }
        public string username { get; set; }
        public DateTime last_login { get; set; }

        public string ImageUrl { get; set; }

        public bool allowAvatarCopying { get; set; }
        public string status { get; set; }
        public string location { get; set; }
        public string homeLocation { get; set; }
        public bool hasBirthday { get; set; }
        public string StatusDescription { get; set; }


        public string TrustLevels { get; set; }
        public string Trustcolor { get; set; }
        public string instcolor { get; set; }
        public string Bio { get; set; }
        public string obfuscatedEmail { get; set; }
        public List<string> tags { get; set; }

        public DateTime Date_joined { get; set; }
        
        public List<PastDisplayName> pastDisplayNames { get; set; }




        public stPage(string date, string date2, bool nightmodeset)
        {
            InitializeComponent();

            if (nightmodeset == true)

            {

        

                Framelog.BackgroundColor = Color.Black;
                Framelog2.BackgroundColor = Color.Black;
                Framelog3.BackgroundColor = Color.Black;
                Framelog4.BackgroundColor = Color.Black;
            }


            api = new VRChatApi.VRChatApi(date, date2);

            usersset();




            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {


                usersset();


                return false;
            });




        }

        async public void usersset()
        {


            try
            {

                ConfigResponse config = await api.RemoteConfig.Get();
                UserResponse users2 = await api.UserApi.Login();


                id = users2.id;

                displayName = users2.displayName;
                username = users2.username;

                last_login = users2.last_login;
                ImageUrl = users2.currentAvatarThumbnailImageUrl;
                allowAvatarCopying = users2.allowAvatarCopying;
                status = users2.status;
                Bio = users2.bio;
                tags = users2.tags;

                Date_joined = users2.date_joined;
               


                string instcol = "#000000";
                string TrustLevel = "none";
                string Trustcol = "Green";


                List<int> grdpoint = new List<int>();


                foreach (var Trustser in tags)
                {
                    if (Trustser == "admin_moderator")
                    {
                        grdpoint.Add(8); //영자

                    }
                    else if (Trustser == "system_legend")
                    {
                        grdpoint.Add(7); //검딱 

                    }
                    else if (Trustser == "system_trust_legend")
                    {
                        grdpoint.Add(6); //노딱 

                    }
                    else if (Trustser == "system_trust_veteran")
                    {
                        grdpoint.Add(5); //보딱 

                    }
                    else if (Trustser == "system_trust_trusted")
                    {
                        grdpoint.Add(4); //주딱 

                    }
                    else if (Trustser == "system_trust_known")
                    {
                        grdpoint.Add(3); //초딱 

                    }
                    else if (Trustser == "system_trust_basic")
                    {
                        grdpoint.Add(2); //파딱 

                    }
                    else
                    {
                        grdpoint.Add(1); //흰딱 

                    }

                }


                int point = grdpoint.Max();


                if (point == 8)
                {
                    TrustLevel = "moderator"; //영자
                    Trustcol = "#FF0000";

                }
                else if (point == 7)
                {
                    TrustLevel = "legend"; //검딱 
                    Trustcol = "#FF0000";

                }
                else if (point == 6)
                {
                    TrustLevel = "veteran"; //노딱 
                    Trustcol = "#FFE400";
                }
                else if (point == 5)
                {
                    TrustLevel = "trusted";//보딱 
                    Trustcol = "#7112FF";
                }
                else if (point == 4)
                {
                    TrustLevel = "known"; //주딱 
                    Trustcol = "#FF5E00";
                }
                else if (point == 3)
                {
                    TrustLevel = "user"; //초딱 
                    Trustcol = "#7DFE74";
                }
                else if (point == 2)
                {
                    TrustLevel = "basic"; //파딱 
                    Trustcol = "#489CFF";
                }
                else
                {
                    TrustLevel = "Visitor";//흰딱 
                    Trustcol = "#E1E1E1";
                }


                Trustcolor = Trustcol;
                TrustLevels = TrustLevel;



                if ("active" == status)
                {
                    status = "online";
                    instcol = "#1DDB16";
                }
                else if ("ask me" == status)
                {

                    instcol = "#FF7012";
                }
                else if ("busy" == status)
                {

                    instcol = "#FF0000";
                }
                else if ("join me" == status)
                {

                    instcol = "#2478FF";
                }

                instcolor = instcol;


                obfuscatedEmail = users2.steamId;
             
                

               

                StatusDescription = users2.statusDescription;
                
                pastDisplayNames = users2.pastDisplayNames;

                homeLocation = users2.homeLocation;



                BindingContext = this;

            }

            catch
            {



              

            }
        }





        async void logoutButtonClicked(object sender, EventArgs e)
        {

            try
            {

                //예외 처리 안함
                await api.UserApi.Logout();
            }

            catch
            {





            }
            await Navigation.PopAsync();

             

        }
    }
}