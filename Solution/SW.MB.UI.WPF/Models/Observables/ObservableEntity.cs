using CommunityToolkit.Mvvm.ComponentModel;

namespace SW.MB.UI.WPF.Models.Observables
{
    public abstract class ObservableEntity<T> : ObservableObject where T : struct
    {
        public T ID { get; }
    }
}
