using System.Collections.Generic;
using SibSoftProjectTest.Abstractions.Services;
using SibSoftProjectTest.Models;
using SibSoftProjectTest.Services.Storages.Base;

namespace SibSoftProjectTest.Services.Storages
{
    public class CatsLocalStorage : LocalStorageBase, ICatsStorage
    {
        public List<ImageModel> Cats
        {
            get { return GetValue<List<ImageModel>>(); }
            set { SetValue(value); }
        }

        public List<int> CatsFavoritesIds
        {
            get { return GetValue<List<int>>(); }
            set { SetValue(value); }
        }
    }
}
