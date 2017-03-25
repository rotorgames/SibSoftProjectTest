using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using SibSoftProjectTest.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SibSoftProjectTest.Markups
{
    [ContentProperty(nameof(Text))]
    public class LocalizeExtension : IMarkupExtension
    {
        private readonly CultureInfo ci;
        private static readonly string ResourceId = typeof(Strings).FullName;

        public string Text { get; set; }

        public IValueConverter Converter { get; set; }

        public object ConverterParameter { get; set; }

        public LocalizeExtension()
        {
            ci = CultureInfo.InvariantCulture;
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return "";

            ResourceManager resmgr = new ResourceManager(ResourceId, typeof(LocalizeExtension).GetTypeInfo().Assembly);

            var translation = resmgr.GetString(Text, ci);

            if (translation == null)
            {
#if DEBUG
                throw new ArgumentException(
                    String.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, ResourceId, ci.Name),
                    "Text");
#else
                translation = Text; // HACK: returns the key, which GETS DISPLAYED TO THE USER
#endif
            }

            var convertTranslation = Converter?.Convert(translation, typeof(string), ConverterParameter, ci);

            return convertTranslation ?? translation;
        }
    }
}
