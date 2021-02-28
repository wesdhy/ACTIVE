using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.Win32;
using VRChatApi.Classes;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.Net;
using Newtonsoft.Json;
using VRChatApi.Endpoints;

namespace vrchat_active.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Frdpage : ContentPage
    {
        public IList<user> usertag { get; private set; }

        public bool set { get; set; }


        public Frdpage()
        {
            InitializeComponent();
            var app = Application.Current as App;
            bool nightmodeset = app.nitmod;

            


            if (nightmodeset == true)

            {
                BackgroundColor = Color.Black;
                Framelog.BackgroundColor = Color.Black;
                Framelog2.BackgroundColor = Color.Black;
                Framelog3.BackgroundColor = Color.Black;
                Framelog4.BackgroundColor = Color.Black;
                Framelog5.BackgroundColor = Color.Black;
            }


           


           

            usertag = new List<user>();
        }



        async void OnButtonClicked(object sender, EventArgs e)
        {
            

            try
            { 



            errcode ercode = await UserApi.inviteme(locationid.Text);


            var answer = DisplayAlert(ercode.success.status_code, ercode.success.message + ". invite success", "ok");
            }
            catch
            {
               
                

                var answer = DisplayAlert("Private&offline", "can't invite you here.", "ok");


            }


        }


        async void OnButtonClicked2(object sender, EventArgs e)
        {


            try
            {

                

                var response = await DisplayAlert("Question", "delete friend ?", "YES", "NO");

                if (response)
                {
                    errcode ercode = await FriendsApi.DeleteFriend(usid.Text);
                    await DisplayAlert(ercode.success.status_code , ercode.success.message, "ok");
                }


            }
            catch
            {


                await DisplayAlert("errer"," now, not your friend.", "ok");



            }


        }






    }
}