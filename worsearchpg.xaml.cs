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
    public partial class worsearchpg : ContentPage
    {
        public IList<serwor> userlist { get; private set; }

        VRChatApi.VRChatApi api;
        public worsearchpg(string date, string date2)
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


                    userlist = new List<serwor>();
                    List<WorldBriefResponse> scaryWorlds = await api.WorldApi.Search(keyword: locationid.Text, offset: 0, count: 50);



                    foreach (var Worlds in scaryWorlds)
                    {
                        userlist.Add(new serwor
                        {


                            id = Worlds.id,

                            name = Worlds.name,

                            authorName = Worlds.authorName,


                            thumbnailImageUrl = Worlds.thumbnailImageUrl,


                            //  created_at = Worlds.created_at,
                            //  updated_at = Worlds.updated_at,


                            capacity = Worlds.capacity,
                            favorites = Worlds.favorites,
                            visits = Worlds.visits,
                            popularity = Worlds.popularity,
                            heat = Worlds.heat,
                            occupants = Worlds.occupants,


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

            var userlist = e.SelectedItem as serwor;
            var nextpage = new worinfo();
            nextpage.BindingContext = userlist;

            await Navigation.PushAsync(nextpage);



            //var FrdPage = new Frdpage(userid);

            //await Navigation.PushAsync(FrdPage);




        }
    }
}