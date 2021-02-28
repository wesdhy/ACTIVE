using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vrchat_active.tab;
using vrchat_active.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace vrchat_active
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTabbed : TabbedPage
    {
        VRChatApi.VRChatApi api = new VRChatApi.VRChatApi("null", "null");



        protected override bool OnBackButtonPressed()
        {

           
                Device.BeginInvokeOnMainThread(new Action(async () =>
                {
                    if (await DisplayAlert("logout", "Would you like to logout?", "YES", "NO"))
                    {
                        await api.UserApi.Logout();
                        await Navigation.PopAsync();
                    }
                }));
            

      
            return true;

        }

        public MainTabbed(string data1, string data2 , bool nightmodeset)
        {
            InitializeComponent();
            if (nightmodeset == true)

            {
                BackgroundColor = Color.Black;
                BarBackgroundColor = Color.Black;
            }
           
            Children.Add(new viewtPage(data1, data2 , nightmodeset));
            Children.Add(new TabbedPagemoder(data1, data2, nightmodeset));
            Children.Add(new tabsearch(data1, data2, nightmodeset));
            Children.Add(new tabavatar(data1, data2, nightmodeset));
            Children.Add(new stPage(data1, data2, nightmodeset));




        }
    }
}