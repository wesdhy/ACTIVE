using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace vrchat_active
{
    public partial class App : Application
    {
        // 상수 선언
        private const string TitleKey = "Name";
        private const string PassKey = "pass";

        private const string NotificationsEnabledKey = "NotificationsEnabled";
        private const string nitmods = "nitmod";

        // 속성 선언
        public string Title
        {
            get
            {
                if (Properties.ContainsKey(TitleKey))
                    return Properties[TitleKey].ToString();
                return "";
            }
            set
            {
                Properties[TitleKey] = value;
            }
        }

        public string pass
        {
            get
            {
                if (Properties.ContainsKey(PassKey))
                    return Properties[PassKey].ToString();
                return "";
            }
            set
            {
                Properties[PassKey] = value;
            }
        }
        public bool NotificationsEnabled
        {
            get
            {
                if (Properties.ContainsKey(NotificationsEnabledKey))
                    return (bool)Properties[NotificationsEnabledKey];
                return false;
            }
            set
            {
                Properties[NotificationsEnabledKey] = value;
            }
        }

        public bool nitmod
        {
            get
            {
                if (Properties.ContainsKey(nitmods))
                    return (bool)Properties[nitmods];
                return false;
            }
            set
            {
                Properties[nitmods] = value;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
