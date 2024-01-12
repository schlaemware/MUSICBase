using System.ComponentModel;

namespace SW.MB.UI.WPF.Interfaces
{
    public interface INavigationStore
    {
        public INavigableObject? CurrentViewModel { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public bool CanNavigateTo<T>() where T : INavigableObject;

        public void NavigateTo<T>() where T : INavigableObject;
    }
}
