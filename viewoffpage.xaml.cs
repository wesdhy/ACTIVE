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
    public partial class viewoffpage : ContentPage
    {
        public viewoffpage()
        {
            InitializeComponent();
        }

        public int userNum { get; set; }
        public int onlineNum { get; set; }

        public string userName { get; set; }




        public List<user> userlist { get; set; }




        VRChatApi.VRChatApi api;

        public viewoffpage(string date, string date2)
        {

            try
            {

                //  float progress = 0f;
                //  NavigationPage.SetHasNavigationBar(this, false);
                InitializeComponent();

                userlist = new List<user>();

                api = new VRChatApi.VRChatApi(date, date2);

                // usersset();

                userlists();



                userName = date;







                listpro.RefreshCommand = new Command(() => {



                    userlist.Clear();
                    userlists();

                    // progress = 0;
                    //  listpro.EndRefresh();



                });

                /*

                

            Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                progress += 0.041666f;

                styledProgressBar.ProgressTo(progress, 750, Easing.Linear);


                return true;
            });

    */


                Device.StartTimer(TimeSpan.FromSeconds(120), () =>
                {


                    userlist.Clear();
                    userlists();

                    //progress = 0;
                    //  listpro.EndRefresh();



                    return true;
                });



            }

            catch
            {


                var answer = DisplayAlert("login error", "Your session has expired. Please re-login", "ok");




            }


        }
        async public void userlists()
        {
            try
            {
               // int useNu = 0;
               int useNu2 = 0;



                UserResponse users = await api.UserApi.Login();
                List<string> usLISTact = users.activeFriends;



              
                List<UserBriefResponse> friendss = await api.FriendsApi.Get(0, 99, true);
                List<UserBriefResponse> dump;


              
                int j = 99;
             
               

                while (j < 2000)
                {


                    if (j == friendss.Count)
                    {
                        dump = await api.FriendsApi.Get(j, 99, true);

                        friendss.AddRange(dump);

                        j += 99;
                    }
                    else break;
                }

                List<UserBriefResponse> SortedList2 = friendss.OrderBy(x => x.displayName).ToList();











              


                foreach (var friend in usLISTact)
                {
                  //  useNu++;
                    UserBriefResponse frien1 = await api.UserApi.GetById(friend);

                    useNu2++;
                    string TrustLevel;
                    string Trustcol = "#000000";
                    List<int> grdpoint = new List<int>();
                    grdpoint.Add(1);


                    foreach (var Trustser in frien1.tags)
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


                    userlist.Add(new user
                    {
                        notworld = true,
                        usid = frien1.id,
                        Location = frien1.location,
                        Name = frien1.displayName,
                        ImageUrl = frien1.currentAvatarImageUrl,
                        mapinst = "active",
                        usNa = frien1.username,
                        ustags = frien1.tags,
                        Trustcol = Trustcol,
                        instcol = "#368AFF",
                        TrustLevel = TrustLevel,
                        bio = frien1.bio,
                        statusDescription = frien1.statusDescription,
                    });
                }



                foreach (var friend in SortedList2)
                {
                    useNu2++;
                    // useNu++;

                    string a = friend.location;


                    int aleg = a.Length;








                    string TrustLevel;
                    string Trustcol = "#000000";
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



                    userlist.Add(new user
                    {
                        notworld = true,
                        usid = friend.id,
                        Location = friend.location,


                        Name = friend.displayName,

                        ImageUrl = friend.currentAvatarImageUrl,


                        usNa = friend.username,
                        ustags = friend.tags,

                        Trustcol = Trustcol,
                        instcol = "#000000",

                        TrustLevel = TrustLevel,
                        bio = friend.bio,
                        statusDescription = friend.statusDescription,
                    });









                }

                











             //   userNum = useNu;
                onlineNum = useNu2;






                listpro.ItemsSource = null;
                BindingContext = this;
                listpro.ItemsSource = userlist;

                listpro.EndRefresh();
            }

            catch 
            {


               



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