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
    public partial class TabbedPagemoder : TabbedPage
    {
        public TabbedPagemoder(string date, string date2, bool nightmodeset)
        {
            InitializeComponent();

            if (nightmodeset == true)

            {
                BarBackgroundColor = Color.Black;
                // moderated.BackgroundColor = Color.DarkBlue;
            }

            Children.Add(new moderatedpg(date, date2));

            Children.Add(new moderatedpg2(date, date2));

        }
    }
}