using System.Collections.Generic;
using SibSoftProjectTest.Abstractions.Services;
using SibSoftProjectTest.Models;
using SibSoftProjectTest.Services.Storages.Base;

namespace SibSoftProjectTest.Services.Storages
{
    public class ImagesLocalStorage : LocalStorageBase, IImagesData
    {
        public List<ImageModel> Images
        {
            get { return GetValue<List<ImageModel>>(); }
            set { SetValue(value); }
        }
    }
}
