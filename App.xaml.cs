using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProjectMVVM_Floweronline.View;
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ProjectMVVM_Floweronline
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new PageInsertLoaihoa();
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
