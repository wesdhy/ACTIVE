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
    public partial class moderatedpg2 : ContentPage
    {
       
        public bool set { get; set; }
        public IList<moderate> Moderlist { get; set; }



        VRChatApi.VRChatApi api;

        public moderatedpg2(string date, string date2)
        {

            InitializeComponent();
            Moderlist = new List<moderate>();
            api = new VRChatApi.VRChatApi(date, date2);
            set = true;
            usersset();








        }

        async public void usersset()
        {
            ConfigResponse config = await api.RemoteConfig.Get();

        }


        async void OnButtonClicked(object sender, EventArgs e)
        {

            try
            {
                UserResponse users = await api.UserApi.Login();

                List<PlayerModeratedResponse> modlist = await api.ModerationsApi.GetPlayerModerated();

                List<PlayerModeratedResponse> SortedList = modlist.OrderBy(x => x.created).ToList();
                SortedList.Reverse();
                foreach (var modlists in SortedList)
                {

                    if ((modlists.type != "unmute") && (modlists.type != "showAvatar"))
                    {
                        Moderlist.Add(new moderate
                        {


                            type = modlists.type,

                            sourceDisplayName = modlists.sourceDisplayName,

                            targetDisplayName = modlists.targetDisplayName,


                            created = modlists.created
                        });
                    }

                }
                set = false;


                BindingContext = this;

            }

            catch
            {

                var answer = DisplayAlert("service error", "Session state error(-5) ", "ok");

            }
        }
    }
}