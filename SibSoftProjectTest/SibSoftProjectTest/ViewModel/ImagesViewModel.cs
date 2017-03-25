using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using SibSoftProjectTest.Abstractions.Services;
using SibSoftProjectTest.Enums.Condition;
using SibSoftProjectTest.Models;
using SibSoftProjectTest.ViewModel.Base;
using Xamarin.Forms;

namespace SibSoftProjectTest.ViewModel
{
    public class ImagesViewModel : ViewModelBase
    {
        private readonly ICatsStorage _catsStorage;
        private readonly ICatsData _catsData;

        public State CurrentState { get; set; }

        public List<ImageModel> Cats { get; set; }

        public ICommand FavoriteCommand { get; }

        public ICommand RepeatCommand { get; }

        public ICommand ItemWasChangedCommand { get; }

        public ImagesViewModel(ICatsStorage catsStorage, ICatsData catsData)
        {
            _catsStorage = catsStorage;
            _catsData = catsData;

            FavoriteCommand = new Command<ImageModel>(OnFavorite);
            RepeatCommand = new Command(OnRepeat);
            ItemWasChangedCommand = new Command(ItemWasChanged);
        }

        public override void Init(object initData)
        {
            base.Init(initData);

            UpdateData();
        }

        private async void UpdateData()
        {
            CurrentState = State.Loading;

            var localCats = _catsStorage.Cats;
            var favoritesCatsIds = _catsStorage.CatsFavoritesIds;

            if (localCats == null)
            {
                try
                {
                    localCats = await _catsData.GetCats();
                    _catsStorage.Cats = localCats;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    CurrentState = State.Error;
                    return;
                }
            }

            if (favoritesCatsIds != null)
            {
                foreach (var catModel in localCats)
                    catModel.IsFavorite = favoritesCatsIds.Any(id => id == catModel.Id);
            }

            Cats = localCats;

            CurrentState = State.Normal;
        }

        private void OnFavorite(ImageModel model)
        {
            model.IsFavorite = !model.IsFavorite;
            _catsStorage.CatsFavoritesIds = Cats
                .Where(imageModel => imageModel.IsFavorite)
                .Select(imageModel => imageModel.Id)
                .ToList();
        }

        private void OnRepeat()
        {
            UpdateData();
        }

        private void ItemWasChanged()
        {
            _catsStorage.Cats = Cats;
        }
    }
}
