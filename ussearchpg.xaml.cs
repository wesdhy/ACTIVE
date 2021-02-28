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
    public partial class ussearchpg : ContentPage
    {
        public IList<seruser> userlist { get; private set; }
        public List<string> tags { get; set; }
        VRChatApi.VRChatApi api;

        public ussearchpg(string date, string date2)
        {

            InitializeComponent();
            api = new VRChatApi.VRChatApi(date, date2);




        }
        public void RefreshData()
        {

            listpro.ItemsSource = null;
            listpro.ItemsSource = userlist;
        }
        async void OnButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(locationid.Text))
            {
                try
                {
                    userlist = new List<seruser>();


                    List<UserBriefResponse> user = await api.UserApi.Userd(search: locationid.Text, n: 50, offset: 0);







                    foreach (var modlists in user)
                    {


                        userlist.Add(new seruser
                        {

                            id = modlists.id,

                            username = modlists.username,

                            displayName = modlists.displayName,

                            currentAvatarThumbnailImageUrl = modlists.currentAvatarThumbnailImageUrl,

                            status = modlists.status,

                            statusDescription = modlists.statusDescription,

                            tags = modlists.tags,


                            location = modlists.location,

                            isFriend = modlists.isFriend,

                        });
                    }


                    BindingContext = this;

                    listpro.ItemsSource = userlist;

                    RefreshData();



                    listpro.EndRefresh();


                }

                catch
                {

                    var answer = DisplayAlert("service error", "Session state error(-5) ", "ok");

                }

            }


        }

        async void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {


            var userlist = e.SelectedItem as seruser;

            //var answer = DisplayAlert("알림", "친구 추가를 하시겠습니까 ?", "ok");
            var response = await DisplayAlert("Question", "send a friend request?", "YES", "NO");

            if (response)
            {
                await api.UserApi.friendRequest(userlist.id);
                await DisplayAlert("200", "Request Completed", "ok");
            }




        }
    }
}