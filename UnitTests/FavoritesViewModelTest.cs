using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SibSoftProjectTest.Abstractions.Services;
using SibSoftProjectTest.Enums.Condition;
using SibSoftProjectTest.Models;
using SibSoftProjectTest.ViewModel;

namespace UnitTests
{
    [TestClass]
    public class FavoritesViewModelTest
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

        [TestMethod]
        public void NoDataTest()
        {
            var catsStorage = new CatsStorage();

            catsStorage.Cats = new List<ImageModel>
            {
                new ImageModel(27, String.Empty, String.Empty, String.Empty),
                new ImageModel(37, String.Empty, String.Empty, String.Empty),
            };

            var vm = new FavoritesViewModel(catsStorage);

            vm.Init(null);

            Assert.AreEqual(vm.CurrentState, State.NoData);

            catsStorage.CatsFavoritesIds = new List<int>
            {
                55
            };

            vm.Init(null);

            Assert.AreEqual(vm.CurrentState, State.NoData);

            catsStorage.CatsFavoritesIds = new List<int>
            {
                catsStorage.Cats.First().Id
            };

            vm.Init(null);

            Assert.AreEqual(vm.CurrentState, State.Normal);
        }

        [TestMethod]
        public void FavoritesCatsTest()
        {
            var catsStorage = new CatsStorage();

            catsStorage.Cats = new List<ImageModel>
            {
                new ImageModel(27, String.Empty, String.Empty, String.Empty),
                new ImageModel(37, String.Empty, String.Empty, String.Empty),
            };

            var vm = new FavoritesViewModel(catsStorage);

            vm.Init(null);

            Assert.IsFalse(vm.FavoritesCats?.Any() == true);
            Assert.AreEqual(vm.Cats.Count, 2);

            catsStorage.CatsFavoritesIds = new List<int>
            {
                33
            };

            vm.Init(null);

            Assert.IsFalse(vm.FavoritesCats?.Any() == true);

            catsStorage.CatsFavoritesIds = new List<int>
            {
                catsStorage.Cats.First().Id
            };

            vm.Init(null);

            Assert.IsTrue(vm.FavoritesCats.Any());
            Assert.AreEqual(vm.FavoritesCats.First().Id, catsStorage.Cats.First().Id);
        }

        [TestMethod]
        public void ItemWasChangedTest()
        {
            var catsStorage = new CatsStorage();

            catsStorage.Cats = new List<ImageModel>
            {
                new ImageModel(27, String.Empty, String.Empty, String.Empty),
                new ImageModel(37, String.Empty, String.Empty, String.Empty),
            };

            var vm = new FavoritesViewModel(catsStorage);

            vm.Init(null);

            Assert.AreEqual(catsStorage.SetCatsCount, 1);

            Assert.IsTrue(vm.ItemWasChangedCommand.CanExecute(catsStorage.Cats.First()));

            vm.ItemWasChangedCommand.Execute(catsStorage.Cats.First());

            Assert.AreEqual(catsStorage.SetCatsCount, 2);
        }
    }
}
