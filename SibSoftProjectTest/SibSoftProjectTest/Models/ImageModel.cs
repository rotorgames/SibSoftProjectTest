using SibSoftProjectTest.Models.Base;

namespace SibSoftProjectTest.Models
{
    public class ImageModel : ModelBase
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public ImageModel()
        {
            
        }

        public ImageModel(string title, string description, string image)
        {
            Title = title;
            Description = description;
            Image = image;
        }
    }
}
