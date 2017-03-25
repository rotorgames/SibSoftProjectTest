using System.Collections.Generic;
using System.Threading.Tasks;
using SibSoftProjectTest.Abstractions.Services;
using SibSoftProjectTest.Models;

namespace SibSoftProjectTest.Services.Rest
{
    public class CatsStubRestService : ICatsData
    {
        public async Task<List<ImageModel>> GetCats()
        {
            // Emilation rest request time;
            await Task.Delay(1000);

            var id = 0;
            return new List<ImageModel>
            {
                new ImageModel(id++, "Cats", "FavoritesCats: Adoption, Bringing A Cat Home and Care", "https://www.petfinder.com/wp-content/uploads/2013/09/cat-black-superstitious-fcs-cat-myths-162286659.jpg"),
                new ImageModel(id++, "Persian Cats And Kittens", "FavoritesCats", "http://tenthlifecats.org/mm/images/featured-cat/chaos-kittens-2.jpg"),
                new ImageModel(id++, "101 Amusing Cat Facts", "ОDo you love cats? Here are 101 little-known facts about your pet that may surprise you!", "https://cdn.kinsights.com/cache/2f/a0/2fa05bebbd843b9aa91e348a7e77d5c2.jpg"),
                new ImageModel(id++, "Cats", "FavoritesCats: Adoption, Bringing A Cat Home and Care", "https://www.petfinder.com/wp-content/uploads/2013/09/cat-black-superstitious-fcs-cat-myths-162286659.jpg"),
                new ImageModel(id++, "Persian Cats And Kittens", "FavoritesCats", "http://tenthlifecats.org/mm/images/featured-cat/chaos-kittens-2.jpg"),
                new ImageModel(id++, "101 Amusing Cat Facts", "ОDo you love cats? Here are 101 little-known facts about your pet that may surprise you!", "https://cdn.kinsights.com/cache/2f/a0/2fa05bebbd843b9aa91e348a7e77d5c2.jpg"),
                new ImageModel(id++, "Cats", "FavoritesCats: Adoption, Bringing A Cat Home and Care", "https://www.petfinder.com/wp-content/uploads/2013/09/cat-black-superstitious-fcs-cat-myths-162286659.jpg"),
                new ImageModel(id++, "Persian Cats And Kittens", "FavoritesCats", "http://tenthlifecats.org/mm/images/featured-cat/chaos-kittens-2.jpg"),
                new ImageModel(id++, "101 Amusing Cat Facts", "ОDo you love cats? Here are 101 little-known facts about your pet that may surprise you!", "https://cdn.kinsights.com/cache/2f/a0/2fa05bebbd843b9aa91e348a7e77d5c2.jpg"),
                new ImageModel(id++, "Cats", "FavoritesCats: Adoption, Bringing A Cat Home and Care", "https://www.petfinder.com/wp-content/uploads/2013/09/cat-black-superstitious-fcs-cat-myths-162286659.jpg"),
                new ImageModel(id++, "Persian Cats And Kittens", "FavoritesCats", "http://tenthlifecats.org/mm/images/featured-cat/chaos-kittens-2.jpg"),
                new ImageModel(id++, "101 Amusing Cat Facts", "ОDo you love cats? Here are 101 little-known facts about your pet that may surprise you!", "https://cdn.kinsights.com/cache/2f/a0/2fa05bebbd843b9aa91e348a7e77d5c2.jpg"),
                new ImageModel(id++, "Cats", "FavoritesCats: Adoption, Bringing A Cat Home and Care", "https://www.petfinder.com/wp-content/uploads/2013/09/cat-black-superstitious-fcs-cat-myths-162286659.jpg"),
                new ImageModel(id++, "Persian Cats And Kittens", "FavoritesCats", "http://tenthlifecats.org/mm/images/featured-cat/chaos-kittens-2.jpg"),
                new ImageModel(id++, "101 Amusing Cat Facts", "ОDo you love cats? Here are 101 little-known facts about your pet that may surprise you!", "https://cdn.kinsights.com/cache/2f/a0/2fa05bebbd843b9aa91e348a7e77d5c2.jpg"),
                new ImageModel(id++, "Cats", "FavoritesCats: Adoption, Bringing A Cat Home and Care", "https://www.petfinder.com/wp-content/uploads/2013/09/cat-black-superstitious-fcs-cat-myths-162286659.jpg"),
                new ImageModel(id++, "Persian Cats And Kittens", "FavoritesCats", "http://tenthlifecats.org/mm/images/featured-cat/chaos-kittens-2.jpg"),
                new ImageModel(id++, "101 Amusing Cat Facts", "ОDo you love cats? Here are 101 little-known facts about your pet that may surprise you!", "https://cdn.kinsights.com/cache/2f/a0/2fa05bebbd843b9aa91e348a7e77d5c2.jpg"),
                new ImageModel(id++, "Cats", "FavoritesCats: Adoption, Bringing A Cat Home and Care", "https://www.petfinder.com/wp-content/uploads/2013/09/cat-black-superstitious-fcs-cat-myths-162286659.jpg"),
                new ImageModel(id++, "Persian Cats And Kittens", "FavoritesCats", "http://tenthlifecats.org/mm/images/featured-cat/chaos-kittens-2.jpg"),
                new ImageModel(id++, "101 Amusing Cat Facts", "ОDo you love cats? Here are 101 little-known facts about your pet that may surprise you!", "https://cdn.kinsights.com/cache/2f/a0/2fa05bebbd843b9aa91e348a7e77d5c2.jpg"),
                new ImageModel(id++, "Cats", "FavoritesCats: Adoption, Bringing A Cat Home and Care", "https://www.petfinder.com/wp-content/uploads/2013/09/cat-black-superstitious-fcs-cat-myths-162286659.jpg"),
                new ImageModel(id++, "Persian Cats And Kittens", "FavoritesCats", "http://tenthlifecats.org/mm/images/featured-cat/chaos-kittens-2.jpg"),
                new ImageModel(id++, "101 Amusing Cat Facts", "ОDo you love cats? Here are 101 little-known facts about your pet that may surprise you!", "https://cdn.kinsights.com/cache/2f/a0/2fa05bebbd843b9aa91e348a7e77d5c2.jpg"),
            };
        }
    }
}
