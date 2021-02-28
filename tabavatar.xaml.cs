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
    public partial class tabavatar : TabbedPage
    {
        public tabavatar(string data1, string data2, bool nightmodeset)
        {
            InitializeComponent();

            if (nightmodeset == true)

            {
                BarBackgroundColor = Color.Black;
                // Avatar.BackgroundColor = Color.DarkBlue;
            }

            Children.Add(new myavatar(data1, data2));
            Children.Add(new Favoriteavatar(data1, data2));
        }
    }
}