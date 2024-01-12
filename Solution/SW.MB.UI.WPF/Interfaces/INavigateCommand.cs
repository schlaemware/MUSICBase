using System.Windows.Input;

namespace SW.MB.UI.WPF.Interfaces
{
    public interface INavigateCommand : ICommand
    {
        public bool CanExecute();

        public void Execute();
    }

    public interface INavigateCommand<T> : INavigateCommand where T : INavigableObject;
}
