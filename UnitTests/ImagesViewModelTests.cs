using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SibSoftProjectTest.Abstractions.Services;
using SibSoftProjectTest.Enums.Condition;
using SibSoftProjectTest.Models;
using SibSoftProjectTest.ViewModel;

namespace UnitTests
{
    [TestClass]
    public class ImagesViewModelTests
    {
        public class CatsStorage : ICatsStorage
        {
            private List<ImageModel> _cats;

            public int SetCatsCount { get; set; }

            public List<ImageModel> Cats
            {
                get { return _cats; }
                set
                {
                    _cats = value;
                    SetCatsCount++;
                }
            }

            public List<int> CatsFavoritesIds { get; set; }
        }

        public class CatsData : ICatsData
        {
            public int InvokingCount { get; set; }

            public List<ImageModel> Cats { get; set; }

            public CancellationTokenSource TokenCource { get; set; }

            public async Task<List<ImageModel>> GetCats()
            {
                InvokingCount++;

                if (TokenCource != null)
                    await Task.Delay(5000, TokenCource.Token);

                return await Task.FromResult(Cats);
            }
        }

        [TestMethod]
        public void TastStateConditions()
        {
            var catsStorage = new CatsStorage();
            var catsData = new CatsData();

            var vm = new ImagesViewModel(catsStorage, catsData);

            vm.Init(null);

            Assert.AreEqual(vm.CurrentState, State.NoData);

            vm.Init(null);

            catsData.TokenCource = new CancellationTokenSource();

            vm.Init(null);

            Assert.AreEqual(vm.CurrentState, State.Loading);

            catsData.TokenCource.Cancel();
            catsData.TokenCource = null;

            Assert.AreEqual(vm.CurrentState, State.Error);

            catsData.Cats = new List<ImageModel>
            {
                 new ImageModel(0, String.Empty, String.Empty, String.Empty)
            };

            vm.Init(null);

            Assert.AreEqual(vm.CurrentState, State.Normal);
        }

        [TestMethod]
        public void StorageTest()
        {
            var catsStorage = new CatsStorage();
            var catsData = new CatsData();

            catsData.Cats = new List<ImageModel>
            {
                new ImageModel(27, String.Empty, String.Empty, String.Empty),
                new ImageModel(37, String.Empty, String.Empty, String.Empty),
            };

            var vm = new ImagesViewModel(catsStorage, catsData);

            vm.Init(null);

            Assert.AreEqual(catsStorage.Cats.Count, 2);
            Assert.AreEqual(catsStorage.Cats.Last().Id, 37);

            vm.Init(null);

            Assert.AreEqual(catsData.InvokingCount, 1);
        }

        [TestMethod]
        public void ThereAreFavoritesInStorageTest()
        {
            var catsStorage = new CatsStorage();
            var catsData = new CatsData();

            catsStorage.Cats = new List<ImageModel>
            {
                new ImageModel(27, String.Empty, String.Empty, String.Empty),
                new ImageModel(37, String.Empty, String.Empty, String.Empty),
            };

            var vm = new ImagesViewModel(catsStorage, catsData);

            vm.Init(null);

            Assert.IsFalse(vm.Cats.Any(model => model.IsFavorite));
            
            catsStorage.CatsFavoritesIds = new List<int>
            {
                catsStorage.Cats.First().Id
            };

            vm.Init(null);

            Assert.AreEqual(1, vm.Cats.Count(model => model.IsFavorite));
        }

        [TestMethod]
        public void RepeatTest()
        {
            var catsStorage = new CatsStorage();
            var catsData = new CatsData();

            var vm = new ImagesViewModel(catsStorage, catsData);

            vm.Init(null);

            Assert.IsNull(vm.Cats);

            catsData.Cats = new List<ImageModel>
            {
                new ImageModel(27, String.Empty, String.Empty, String.Empty),
                new ImageModel(37, String.Empty, String.Empty, String.Empty),
            };

            Assert.IsTrue(vm.RepeatCommand.CanExecute(null));
            
            vm.RepeatCommand.Execute(null);

            Assert.AreEqual(vm.Cats.Count, 2);
        }

        [TestMethod]
        public void AddToFavoriteTest()
        {
            var catsStorage = new CatsStorage();
            var catsData = new CatsData();

            catsStorage.Cats = new List<ImageModel>
            {
                new ImageModel(27, String.Empty, String.Empty, String.Empty),
                new ImageModel(37, String.Empty, String.Empty, String.Empty),
            };

            var vm = new ImagesViewModel(catsStorage, catsData);

            vm.Init(null);

            Assert.IsTrue(vm.FavoriteCommand.CanExecute(catsStorage.Cats.First()));

            vm.FavoriteCommand.Execute(catsStorage.Cats.First());

            Assert.IsTrue(vm.Cats.First().IsFavorite);
            Assert.IsFalse(vm.Cats.Last().IsFavorite);

            Assert.IsTrue(catsStorage.Cats.First().IsFavorite);
            Assert.IsFalse(catsStorage.Cats.Last().IsFavorite);

            Assert.AreEqual(catsStorage.CatsFavoritesIds.Count, 1);
            Assert.AreEqual(catsStorage.CatsFavoritesIds.First(), catsStorage.Cats.First().Id);
        }

        [TestMethod]
        public void ItemWasChangedTest()
        {
            var catsStorage = new CatsStorage();
            var catsData = new CatsData();

            catsStorage.Cats = new List<ImageModel>
            {
                new ImageModel(27, String.Empty, String.Empty, String.Empty),
                new ImageModel(37, String.Empty, String.Empty, String.Empty),
            };

            var vm = new ImagesViewModel(catsStorage, catsData);

            vm.Init(null);

            Assert.AreEqual(catsStorage.SetCatsCount, 1);

            Assert.IsTrue(vm.ItemWasChangedCommand.CanExecute(catsStorage.Cats.First()));

            vm.ItemWasChangedCommand.Execute(catsStorage.Cats.First());

            Assert.AreEqual(catsStorage.SetCatsCount, 2);
        }
    }
}
