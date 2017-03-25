using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace SibSoftProjectTest.Views.Cells
{
    public partial class CustomImageCell : ViewCell
    {
        public static readonly BindableProperty ImageProperty = BindableProperty.Create(nameof(Image), typeof(string), typeof(CustomImageCell), string.Empty, propertyChanged:OnImageChanged);

        public string Image
        {
            get { return (string)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(CustomImageCell));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly BindableProperty DescriptionProperty = BindableProperty.Create(nameof(Description), typeof(string), typeof(CustomImageCell), defaultBindingMode:BindingMode.TwoWay);

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        public static readonly BindableProperty IsFavoriteButtonVisibleProperty = BindableProperty.Create(nameof(IsFavoriteButtonVisible), typeof(bool), typeof(CustomImageCell), true);

        public bool IsFavoriteButtonVisible
        {
            get { return (bool)GetValue(IsFavoriteButtonVisibleProperty); }
            set { SetValue(IsFavoriteButtonVisibleProperty, value); }
        }

        public static readonly BindableProperty IsFavoriteProperty = BindableProperty.Create(nameof(IsFavorite), typeof(bool), typeof(CustomImageCell), false, BindingMode.TwoWay);

        public bool IsFavorite
        {
            get { return (bool)GetValue(IsFavoriteProperty); }
            set { SetValue(IsFavoriteProperty, value); }
        }

        public static readonly BindableProperty FavoriteCommandProperty = BindableProperty.Create(nameof(FavoriteCommand), typeof(ICommand), typeof(CustomImageCell));

        public ICommand FavoriteCommand
        {
            get { return (ICommand)GetValue(FavoriteCommandProperty); }
            set { SetValue(FavoriteCommandProperty, value); }
        }

        public static readonly BindableProperty FavoriteCommandParameterProperty = BindableProperty.Create(nameof(FavoriteCommandParameter), typeof(object), typeof(CustomImageCell));

        public object FavoriteCommandParameter
        {
            get { return (object)GetValue(FavoriteCommandParameterProperty); }
            set { SetValue(FavoriteCommandParameterProperty, value); }
        }

        public static readonly BindableProperty WasChangedCommandProperty = BindableProperty.Create(nameof(WasChangedCommand), typeof(ICommand), typeof(CustomImageCell));

        public ICommand WasChangedCommand
        {
            get { return (ICommand)GetValue(WasChangedCommandProperty); }
            set { SetValue(WasChangedCommandProperty, value); }
        }

        public static readonly BindableProperty WasChangedCommandParameterProperty = BindableProperty.Create(nameof(WasChangedCommandParameter), typeof(object), typeof(CustomImageCell));

        public object WasChangedCommandParameter
        {
            get { return (object)GetValue(WasChangedCommandParameterProperty); }
            set { SetValue(WasChangedCommandParameterProperty, value); }
        }

        public CustomImageCell()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            UpdateImage();

            base.OnBindingContextChanged();
        }

        private static void OnImageChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var self = (CustomImageCell) bindable;
            self.UpdateImage();
        }

        private void OnFavoriteTapped(object sender, EventArgs e)
        {
            if(FavoriteCommand?.CanExecute(FavoriteCommandParameter) == true)
                FavoriteCommand.Execute(FavoriteCommandParameter);
        }

        private void UpdateImage()
        {
            // It is the recomendation for FFImageLoading
            // https://github.com/luberda-molinet/FFImageLoading/wiki/Xamarin.Forms-Advanced#usage-in-listview-with-listviewcachingstrategyrecycleelement-enabled 
            MainImage.Source = Image;
        }

        private void OnEditButtonTapped(object sender, EventArgs e)
        {
            if (DescriptionLabel.IsVisible)
            {
                TurnEditing();
                DescriptionEditor.Focus();
            }
        }

        private void OnDescriptionEditorUnfocused(object sender, FocusEventArgs e)
        {
            var self = (Editor) sender;

            if(self.IsVisible)
                TurnEditing();
        }

        private void TurnEditing()
        {
            DescriptionLabel.IsVisible = !DescriptionLabel.IsVisible;
            DescriptionEditor.IsVisible = !DescriptionEditor.IsVisible;

            ForceUpdateSize();

            if (DescriptionLabel.IsVisible && WasChangedCommand?.CanExecute(WasChangedCommandParameter) == true)
                WasChangedCommand.Execute(WasChangedCommandParameter);
        }
    }
}
