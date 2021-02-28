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
    public partial class worRecent : ContentPage
    {
        public IList<serwor> userlist { get; private set; }

        VRChatApi.VRChatApi api;

        public worRecent(string date, string date2)
        {
            userlist = new List<serwor>();

            api = new VRChatApi.VRChatApi(date, date2);
            InitializeComponent();


            OnButtonClicked();





            BindingContext = this;

            listpro.ItemsSource = userlist;

            RefreshData();
            listpro.IsRefreshing = false;



        }

        public void RefreshData()
        {

            listpro.ItemsSource = null;
            listpro.ItemsSource = userlist;
        }

        async void OnButtonClicked()
        {



            try
            {



                List<WorldBriefResponse> scaryWorlds = await api.WorldApi.Search(WorldGroups.Recent, offset: 0, count: 20);


                foreach (var Worlds in scaryWorlds)
                {
                    userlist.Add(new serwor
                    {



                        id = Worlds.id,

                        name = Worlds.name,

                        authorName = Worlds.authorName,


                        thumbnailImageUrl = Worlds.thumbnailImageUrl,


                        //    created_at = Worlds.created_at,
                        //     updated_at = Worlds.updated_at,


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
                listpro.IsRefreshing = false;

            }
            catch
            {




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