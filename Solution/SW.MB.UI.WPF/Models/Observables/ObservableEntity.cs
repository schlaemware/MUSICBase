using CommunityToolkit.Mvvm.ComponentModel;
using SW.MB.UI.WPF.Interfaces;

namespace SW.MB.UI.WPF.Models.Observables
{
    public abstract class ObservableEntity<T> : ObservableObject, INavigableObject where T : struct
    {
        public T ID { get; }
    }
}
