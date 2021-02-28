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
    public partial class myavatar : ContentPage
    {
        public IList<serwor> userlist { get; private set; }
        // Button Text = "search" TextColor="White" Grid.Row="3" Grid.Column="1" BackgroundColor="#489CFF" Clicked="OnButtonClicked" />
        VRChatApi.VRChatApi api;

        public myavatar(string date, string date2)
        {

            userlist = new List<serwor>();
            api = new VRChatApi.VRChatApi(date, date2);
            InitializeComponent();
            OnButtonClicked();


        }

        public void RefreshData()
        {

            listpro.ItemsSource = null;
            listpro.ItemsSource = userlist;
        }


        async void OnButtonClicked()
        {

            // ConfigResponse config = await api.RemoteConfig.Get();
            //UserResponse users = await api.UserApi.Login();


            try
            {
                //List<WorldBriefResponse> scaryWorlds = await api.WorldApi.Search(WorldGroups.Recent,offset:0,count:20);
                List<AvatarResponse> scaryWorlds = await api.AvatarApi.Search(user: UserOptions.Me, releaseStatus: ReleaseStatus.All, offset: 0, n: 80);

                scaryWorlds.Reverse();
                foreach (var avatar in scaryWorlds)
                {
                    userlist.Add(new serwor
                    {


                        id = avatar.id,

                        name = avatar.name,

                        authorName = avatar.authorName,


                        thumbnailImageUrl = avatar.thumbnailImageUrl




                    });
                }

                BindingContext = this;

                listpro.ItemsSource = userlist;

                RefreshData();
                listpro.IsRefreshing = false;

            }
            catch
            { }

        }
    }
}