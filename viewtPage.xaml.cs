using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vrchat_active.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace vrchat_active.tab
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class viewtPage : TabbedPage
    {
        public viewtPage(string date, string date2 ,bool nightmodeset)
        {
            InitializeComponent();

            if (nightmodeset == true)

            {
                BarBackgroundColor = Color.Black;
                // friends.BackgroundColor = Color.DarkBlue;
            }


            Children.Add(new Viewpage(date, date2, nightmodeset));

            Children.Add(new viewoffpage(date, date2 ));
        }
    }
}