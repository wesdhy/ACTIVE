using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace vrchat_active.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class worinfo : ContentPage
    {
        public worinfo()
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
            }

        }
    }
}