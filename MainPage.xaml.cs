using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VRChatApi;
using VRChatApi.Classes;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace vrchat_active
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        
        public string buttcolor { get; set; }// expiration



        public bool set = false;
        public bool nightmodeset = false;

        public MainPage()
        {

            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            var app = Application.Current as App;
            userid.Text = app.Title;
            passid.Text = app.pass;

            nightmode.IsToggled = app.nitmod;
            // notificationsEnabled.On = app.NotificationsEnabled;

            autologin();


        }

        void OnChange(object sender, System.EventArgs e)
        {

            set = true;



        }

        void OnChangenightmode(object sender, System.EventArgs e)
        {
            if (nightmodeset == false)
            {


                Gridlog.BackgroundColor = Color.Black;
                Framelog.BackgroundColor = Color.Black;
                BackgroundColor = Color.Black;
                infoFramelog.BackgroundColor = Color.Black;
                infoGridlog.BackgroundColor = Color.Black;

                nightmodeset = true;

            }
            else if (nightmodeset == true)
            {

                Gridlog.BackgroundColor = Color.White;
                Framelog.BackgroundColor = Color.White;
                BackgroundColor = Color.White;

                infoFramelog.BackgroundColor = Color.White;
                infoGridlog.BackgroundColor = Color.White;
                nightmodeset = false;



            }



            //app.NotificationsEnabled = notificationsEnabled.On;
        }


        async void OnButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(userid.Text) && !string.IsNullOrWhiteSpace(passid.Text))
            {
                try
                {

                    ActivityIndicator2.IsRunning = true;
                    Device.StartTimer(TimeSpan.FromSeconds(5), () =>
                    {

                        ActivityIndicator2.IsRunning = false;

                        return false;
                    });


                    VRChatApi.VRChatApi api = new VRChatApi.VRChatApi(userid.Text, passid.Text);




                    ConfigResponse config = await api.RemoteConfig.Get();





                    UserResponse users = await api.UserApi.Login();





                    var app = Application.Current as App;
                    if (set == true)
                    {

                        app.Title = userid.Text;
                        app.pass = passid.Text;

                    }
                    app.nitmod = nightmode.IsToggled;




                    try
                    {
                        if (users.state != null)
                    {
                        var TabbedPage6 = new MainTabbed(userid.Text, passid.Text, nightmodeset);

                        await Navigation.PushAsync(TabbedPage6);


                    }
                    
                    else if (users.error.status_code != null)
                        {
                            var answer = DisplayAlert(users.error.status_code + "ERRER", users.error.message, "ok");
                        }
                        //string.IsNullOrEmpty(users.requiresTwoFactorAuth[0])
                    } catch { }

                    try
                    {

                        if (users.requiresTwoFactorAuth[0] != null)
                        {
                            UserResponse otpset = await api.UserApi.TOTPLogin(motp.Text);

                            if (otpset.verified == false)

                            {
                                var answer = DisplayAlert("2FA", " wrong otp number", "ok");
                                await api.UserApi.Logout();
                            }
                            else
                            {
                                var TabbedPage6 = new MainTabbed(userid.Text, passid.Text, nightmodeset);

                                await Navigation.PushAsync(TabbedPage6);
                            }
                        }
                    }
                    catch { }
                   



                }
                
                catch
                {
                    var answer = DisplayAlert("NETWORK ERRER", "Please check the device connection status", "ok");

                }

            }
        }







        async void OnButtonClicked2(object sender, EventArgs e)
        {


            await Browser.OpenAsync("https://vrchat.com/home/login", BrowserLaunchMode.SystemPreferred);





        }





        async void autologin()
        {

            if (!string.IsNullOrWhiteSpace(userid.Text) && !string.IsNullOrWhiteSpace(passid.Text))
            {
                try
                {

                    ActivityIndicator2.IsRunning = true;
                    Device.StartTimer(TimeSpan.FromSeconds(5), () =>
                    {

                        ActivityIndicator2.IsRunning = false;

                        return false;
                    });


                    VRChatApi.VRChatApi api = new VRChatApi.VRChatApi(userid.Text, passid.Text);




                    ConfigResponse config = await api.RemoteConfig.Get();


                    UserResponse users = await api.UserApi.Login();





                    var app = Application.Current as App;
                    if (set == true)
                    {

                        app.Title = userid.Text;
                        app.pass = passid.Text;

                    }
                    app.nitmod = nightmode.IsToggled;





                    if (users.state != null)
                    {
                        var TabbedPage6 = new MainTabbed(userid.Text, passid.Text, nightmodeset);

                        await Navigation.PushAsync(TabbedPage6);


                    }
                    else if (users.requiresTwoFactorAuth[0] != null)
                    {
                        UserResponse otpset = await api.UserApi.TOTPLogin(motp.Text);

                        if (otpset.verified == false)

                        {
                            var answer = DisplayAlert("2FA", " Please put in the new otp number.", "ok");
                            await api.UserApi.Logout();
                        }
                    }

                    else
                    {
                        var answer = DisplayAlert(users.error.status_code + "ERRER", users.error.message, "ok");
                    }
                }
                catch
                {
                    var answer = DisplayAlert("NETWORK ERRER", "Please check the device connection status", "ok");

                }

            }

        }


    }
}