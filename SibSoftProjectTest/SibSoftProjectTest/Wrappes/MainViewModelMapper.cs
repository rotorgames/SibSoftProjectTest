using System;
using System.Collections.Generic;
using FreshMvvm;
using SibSoftProjectTest.ViewModel.Base;
using Xamarin.Forms;

namespace SibSoftProjectTest.Wrappes
{
    public class MainViewModelMapper : IFreshPageModelMapper
    {
        private readonly Dictionary<Type, string> _children;

        public MainViewModelMapper()
        {
            _children = new Dictionary<Type, string>();
        }

        public string GetPageTypeName(Type pageModelType)
        {
            if (_children.ContainsKey(pageModelType))
                return _children[pageModelType];

            throw new InvalidOperationException($"{pageModelType.FullName} was not registered");
        }

        public void Register<TViewModel, TPage>()
            where TViewModel : ViewModelBase
            where TPage : Page
        {
            var vmType = typeof(TViewModel);
            var pageType = typeof(TPage);

            if (!_children.ContainsKey(vmType))
            {
                _children.Add(vmType, pageType.AssemblyQualifiedName);
            }
            else
            {
                throw new InvalidOperationException($"You can't register ViewModel '{vmType.FullName}' secondary");
            }
        }
    }
}
