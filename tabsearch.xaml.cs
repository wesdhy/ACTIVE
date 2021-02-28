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
    public partial class tabsearch : TabbedPage
    {
        public tabsearch(string date, string date2, bool nightmodeset)
        {
            InitializeComponent();

            if (nightmodeset == true)

            {
                BarBackgroundColor = Color.Black;
                // search.BackgroundColor = Color.DarkBlue;
            }

            Children.Add(new ussearchpg(date, date2));

            Children.Add(new worsearchpg(date, date2));

            Children.Add(new worFavorite(date, date2));

            Children.Add(new worRecent(date, date2));
        }
    }
}