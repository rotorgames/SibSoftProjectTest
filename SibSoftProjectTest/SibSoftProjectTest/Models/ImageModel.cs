using Newtonsoft.Json;
using SibSoftProjectTest.Models.Base;

namespace SibSoftProjectTest.Models
{
    public class ImageModel : ModelBase
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        [JsonIgnore]
        public bool IsFavorite { get; set; }

        public ImageModel()
        {
            
        }

        public ImageModel(int id, string title, string description, string image)
        {
            Id = id;
            Title = title;
            Description = description;
            Image = image;
        }
    }
}
