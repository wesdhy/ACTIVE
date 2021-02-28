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
    public partial class Favoriteavatar : ContentPage
    {
        public IList<serwor> userlist { get; private set; }

        VRChatApi.VRChatApi api;

        public Favoriteavatar(string date, string date2)
        {


            api = new VRChatApi.VRChatApi(date, date2);

            userlist = new List<serwor>();
            InitializeComponent();

            OnButtonClicked();



        }


        async void OnButtonClicked()
        {

            try
            {


                List<FavouriteResponse> scaryWorlds = await api.FavouriteApi.GetFavourites("avatar", 100);
               


                foreach (var Worlds in scaryWorlds)
                {


                    AvatarResponse Avataron = await api.AvatarApi.GetById(Worlds.favoriteId);

                    userlist.Add(new serwor
                    {
                        id = Avataron.id,

                        name = Avataron.name,

                        authorName = Avataron.authorName,

                        thumbnailImageUrl = Avataron.thumbnailImageUrl,

                        description = Avataron.description
                    });

                }





                BindingContext = this;

                listpro.ItemsSource = userlist;

                RefreshData();
                listpro.IsRefreshing = false;


            }
            catch { }
        }

        public void RefreshData()
        {

            listpro.ItemsSource = null;
            listpro.ItemsSource = userlist;
        }
    }
}