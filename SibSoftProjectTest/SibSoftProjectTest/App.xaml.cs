using FreshMvvm;
using SibSoftProjectTest.Abstractions.Services;
using SibSoftProjectTest.Mappes;
using SibSoftProjectTest.Resources;
using SibSoftProjectTest.Services.Rest;
using SibSoftProjectTest.Services.Storages;
using SibSoftProjectTest.ViewModel;
using SibSoftProjectTest.Views.Pages;
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
            tabbedPage.AddTab<ImagesViewModel>(Strings.All, "");
            tabbedPage.AddTab<FavoritesViewModel>(Strings.Favorites, "");

            MainPage = tabbedPage;
        }

        private void RegisterServices()
        {
            Container.Register<ICatsStorage, CatsLocalStorage>().AsSingleton();
            Container.Register<ICatsData, CatsStubRestService>().AsSingleton();
        }

        private void RegisterPages()
        {
            var mapper = _mapper;

            mapper.Register<ImagesViewModel, ImagesPage>();
            mapper.Register<FavoritesViewModel, FavoritesPage>();
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
