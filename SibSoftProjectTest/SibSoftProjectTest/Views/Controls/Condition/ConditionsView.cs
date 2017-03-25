using SibSoftProjectTest.Enums.Condition;
using Xamarin.Forms;

namespace SibSoftProjectTest.Views.Controls.Condition
{
    [ContentProperty(nameof(Normal))]
    public class ConditionsView : ContentView
    {
        public static readonly BindableProperty StateProperty = BindableProperty.Create(nameof(State), typeof(State), typeof(ConditionsView), State.Normal);

        public State State
        {
            get { return (State)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly BindableProperty NormalProperty = BindableProperty.Create(nameof(Normal), typeof(View), typeof(ConditionsView));

        public View Normal
        {
            get { return (View)GetValue(NormalProperty); }
            set { SetValue(NormalProperty, value); }
        }

        public static readonly BindableProperty LoadingProperty = BindableProperty.Create(nameof(Loading), typeof(View), typeof(ConditionsView));

        public View Loading
        {
            get { return (View)GetValue(LoadingProperty); }
            set { SetValue(LoadingProperty, value); }
        }

        public static readonly BindableProperty NoDataProperty = BindableProperty.Create(nameof(NoData), typeof(View), typeof(ConditionsView));

        public View NoData
        {
            get { return (View)GetValue(NoDataProperty); }
            set { SetValue(NoDataProperty, value); }
        }

        public static readonly BindableProperty ErrorProperty = BindableProperty.Create(nameof(Error), typeof(View), typeof(ConditionsView));

        public View Error
        {
            get { return (View)GetValue(ErrorProperty); }
            set { SetValue(ErrorProperty, value); }
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(State):
                case nameof(Normal):
                case nameof(Loading):
                case nameof(Error):
                    UpdateCurrentView();
                    break;
            }
        }

        private void UpdateCurrentView()
        {
            View newView;

            switch (State)
            {
                case State.Loading:
                    newView = Loading;
                    break;
                case State.NoData:
                    newView = NoData;
                    break;
                case State.Error:
                    newView = Error;
                    break;

                default:
                    newView = Normal;
                    break;
            }

            Content = newView;
        }
    }
}
