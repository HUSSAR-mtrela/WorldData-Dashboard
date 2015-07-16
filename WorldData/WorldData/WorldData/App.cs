using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldData.Views;
using Xamarin.Forms;

namespace WorldData
{
    public class App : Application
    {
        public App()
        {
            //TODO switch back to HomePage when done with styling IG controls in TestPage
            // The root page of your application
            var navPage = new NavigationPage(new TestPage());
            //var navPage = new NavigationPage(new HomePage());
            navPage.BarTextColor = Theme.PrimaryColor;
            MainPage = navPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
