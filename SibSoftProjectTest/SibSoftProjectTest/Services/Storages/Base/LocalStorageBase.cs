using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SibSoftProjectTest.Services.Storages.Base
{
    public abstract class LocalStorageBase
    {
        private Application CurrentApp => Application.Current;

        protected TResult GetValue<TResult>([CallerMemberName] string propertyName = null)
        {
            object result;
            if (CurrentApp.Properties.TryGetValue(propertyName, out result))
                return (TResult) result;

            return default(TResult);
        }

        protected void SetValue<TValue>(TValue value, bool needSave = true, [CallerMemberName] string propertyName = null)
        {
            CurrentApp.Properties.Add(propertyName, value);

            if(needSave)
                Save();
        }

        protected void RemoveValue(bool needSave = true, [CallerMemberName] string propertyName = null)
        {
            CurrentApp.Properties.Remove(propertyName);

            if(needSave)
                Save();
        }

        private async void Save()
        {
            await SaveAsync();
        }

        private Task SaveAsync()
        {
            return CurrentApp.SavePropertiesAsync();
        }
    }
}
