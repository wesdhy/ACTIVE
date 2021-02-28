using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRChatApi.Classes;
using VRChatApi.Endpoints;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace vrchat_active.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Viewpage : ContentPage
    {
        public Viewpage()
        {
            InitializeComponent();

        }




       
        public int onlineNum { get; set; }

        public string userName { get; set; }




        public List<user> userlist { get; set; }




        public VRChatApi.VRChatApi api;



        public Viewpage(string date, string date2, bool nightmodeset)
        {

            try
            {
               
               


                float progress = 0f;
                bool refreshlimiter = true;
                //  NavigationPage.SetHasNavigationBar(this, false);
                InitializeComponent();

                userlist = new List<user>();

                api = new VRChatApi.VRChatApi(date, date2);

                // usersset();

                userlists(nightmodeset);



                userName = date;





                

                listpro.RefreshCommand = new Command(() => {


                    if(refreshlimiter == false)
                    { 
                    userlist.Clear();
                    userlists(nightmodeset);
                    refreshlimiter = true;

                    progress = 0;
                    }
                    else if (refreshlimiter == true)
                    {
                        var answer = DisplayAlert("Refresh Limiter", " Please try after 120 sec.", "ok");
                    }
                    listpro.EndRefresh();


                });

                

                

            Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                progress += 0.041666f;

                styledProgressBar.ProgressTo(progress, 750, Easing.Linear);


                return true;
            });

    
                

                Device.StartTimer(TimeSpan.FromSeconds(120), () =>
                {

                    refreshlimiter = false;

                    /*
                    userlist.Clear();
                    userlists(nightmodeset);
                    */

                   
                    
                   


                    return true;
                });

            
                



            }

            catch 
            {
               

            }


        }

       





        async public void userlists(bool nightmodeset)
        {
            try
            {
               
                int useNu2 = 0;
               // UserResponse users = await api.UserApi.Login();


                List<UserBriefResponse> friends = await api.FriendsApi.Get(0, 99, false);
         
                List<UserBriefResponse> dump;


                int i = 99;
          
                while (i < 500)
                {


                    if (i == friends.Count)
                    {
                        dump = await api.FriendsApi.Get(i, 99, false);

                        friends.AddRange(dump);

                        i += 99;
                    }
                    else break;
                }

                List<UserBriefResponse> SortedList = friends.OrderBy(x => x.location).ToList();
                SortedList.Reverse();




                string worddump = "";

                foreach (var friend in SortedList)
                {
                    
                    useNu2++;

                    string a = friend.location;

                    string idcut = ":";
                    string instcut = "~";

                    string wordid;
                    string wordinst;

                    int aleg = a.Length;
                    string instcol = "#000000";
                    string TrustLevel;
                    string Trustcol = "Green";

                    string framecolor = "#FFFFFF";
                    if (nightmodeset == true)

                    {
                        framecolor = "#000000";
                    }

                    List<int> grdpoint = new List<int>();
                    grdpoint.Add(1);


                    foreach (var Trustser in friend.tags)
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
                        Trustcol = "#FA5882";

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


                    if ("active" == friend.status)
                    {
                        friend.status = "online";
                        instcol = "#1DDB16";
                    }
                    else if ("ask me" == friend.status)
                    {

                        instcol = "#FF7012";
                    }
                    else if ("busy" == friend.status)
                    {

                        instcol = "#FF0000";
                    }
                    else if ("join me" == friend.status)
                    {

                        instcol = "#2478FF";
                    }


                    if (1 <= a.IndexOf(idcut))
                    {


                        wordid = a.Substring(0, a.IndexOf(idcut));

                        if (1 <= a.IndexOf("hidden"))
                        {
                            wordinst = ("#" + a.Substring(a.IndexOf(idcut) + 1, (a.IndexOf(instcut) - 1) - a.IndexOf(idcut)) + " friends+");
                        }
                        else if (1 <= a.IndexOf("friends"))
                        {
                            wordinst = ("#" + a.Substring(a.IndexOf(idcut) + 1, (a.IndexOf(instcut) - 1) - a.IndexOf(idcut)) + " friends");
                        }


                        else
                        {
                            wordinst = ("#" + a.Substring(a.IndexOf(idcut) + 1, (a.Length - 1) - a.IndexOf(idcut)) + " public");
                        }
                        WorldResponse wodrs = await api.WorldApi.Get(wordid);

                        

                        if(worddump!= friend.location)
                        { 
                        worddump = friend.location;

                            userlist.Add(new user
                            {
                                //world


                                notworld = false,
                                map2 = 0,
                                map = "#C0C0C0",
                                Name = wodrs.name,
                                mapuri = wodrs.assetUrl,
                                Location = wordinst,


                                ImageUrl = wodrs.imageUrl,
                                location = friend.location,
                                statu = wodrs.authorName,
                                

                            });
                        }

                        
                      


                        userlist.Add(new user
                        {
                            notworld = true,
                            map2 = 20,
                            usid = friend.id,

                            map = framecolor,
                            Location = friend.statusDescription,
                            mapinst = friend.status,
                            Locationimg = wodrs.imageUrl,
                            mapuri = wodrs.assetUrl,
                            authorName = wodrs.authorName,
                            Name = friend.displayName,
                            location = friend.location,
                            statu = friend.status,
                            

                            usNa = friend.username,
                            ImageUrl = friend.currentAvatarImageUrl,
                            ustags = friend.tags,
                            Trustcol = Trustcol,
                            instcol = instcol,

                            TrustLevel = TrustLevel,
                            bio = friend.bio,
                            statusDescription = friend.statusDescription,

                        });
                    }
                    else
                    {
                        userlist.Add(new user
                        {

                            notworld = true,
                            map2 = 20,
                            usid = friend.id,
                            Location = friend.location,
                            
                            map = framecolor,
                            Name = friend.displayName,

                            ImageUrl = friend.currentAvatarImageUrl,
                            statu = friend.status,
                            mapinst = friend.status,

                            usNa = friend.username,
                            ustags = friend.tags,

                            Trustcol = Trustcol,
                            instcol = instcol,

                            TrustLevel = TrustLevel,
                            bio = friend.bio,
                            statusDescription = friend.statusDescription
                        });



                    }











                }


               











              
                onlineNum = useNu2;






                listpro.ItemsSource = null;
                BindingContext = this;
                listpro.ItemsSource = userlist;

                listpro.EndRefresh();
            }

            catch
            {

                var answer = DisplayAlert("login error", "Your session has expired. Please re-login", "ok");








            }



        }

        async void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {

            var userlist = e.SelectedItem as user;
            var nextpage = new Frdpage();
            nextpage.BindingContext = userlist;

            await Navigation.PushAsync(nextpage);



            //var FrdPage = new Frdpage(userid);

            //await Navigation.PushAsync(FrdPage);


        }







    

     }
}