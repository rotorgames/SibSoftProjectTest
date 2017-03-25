using System.Collections.Generic;
using SibSoftProjectTest.Models;

namespace SibSoftProjectTest.Abstractions.Services
{
    public interface ICatsStorage
    {
        List<ImageModel> Cats { get; set; }

        List<int> CatsFavoritesIds { get; set; }
    }
}
