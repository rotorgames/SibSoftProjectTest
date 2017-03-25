using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FreshMvvm;
using SibSoftProjectTest.Resources;
using SibSoftProjectTest.ViewModel;
using SibSoftProjectTest.Views.Pages;
using SibSoftProjectTest.Wrappes;
using Xamarin.Forms;

namespace SibSoftProjectTest
{
    public partial class App : Application
    {
        private readonly MainViewModelMapper _mapper;

        private IFreshIOC Container => FreshIOC.Container;

        public App()
        {
            InitializeComponent();

            _mapper = new MainViewModelMapper();

            FreshPageModelResolver.PageModelMapper = _mapper;

            RegisterServices();
            RegisterPages();

            var tabbedPage = new FreshTabbedNavigationContainer();
            tabbedPage.AddTab<ImagesViewModel>(Strings.Images, "");

            MainPage = tabbedPage;
        }

        private void RegisterServices()
        {
            
        }

        private void RegisterPages()
        {
            var wrapper = _mapper;

            wrapper.Register<ImagesViewModel, ImagesPage>();
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
