using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using SibSoftProjectTest.Abstractions.Services;
using SibSoftProjectTest.Enums.Condition;
using SibSoftProjectTest.Models;
using SibSoftProjectTest.ViewModel.Base;
using Xamarin.Forms;

namespace SibSoftProjectTest.ViewModel
{
    public class FavoritesViewModel : ViewModelBase
    {
        private readonly ICatsStorage _catsStorage;
        private readonly ICatsData _catsData;

        public State CurrentState { get; set; }

        public List<ImageModel> Cats { get; set; }

        public List<ImageModel> FavoritesCats { get; set; }

        public ICommand ItemWasChangedCommand { get; }

        public FavoritesViewModel(ICatsStorage catsStorage)
        {
            _catsStorage = catsStorage;

            ItemWasChangedCommand = new Command(ItemWasChanged);
        }

        public override void Init(object initData)
        {
            base.Init(initData);

            UpdateData();
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);

            UpdateData();
        }

        private void UpdateData()
        {
            CurrentState = State.Loading;

            var localCats = _catsStorage.Cats;
            var favoritesCatsIds = _catsStorage.CatsFavoritesIds;

            Cats = localCats;

            var favoritesCats = localCats?.Where(model => favoritesCatsIds?.Any(id => model.Id == id) == true).ToList();

            if (favoritesCats == null || favoritesCats.Count == 0)
            {
                CurrentState = State.NoData;
                return;
            }

            FavoritesCats = favoritesCats;

            CurrentState = State.Normal;
        }

        private void ItemWasChanged()
        {
            _catsStorage.Cats = Cats;
        }
    }
}
