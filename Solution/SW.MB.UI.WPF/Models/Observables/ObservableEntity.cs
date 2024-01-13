using CommunityToolkit.Mvvm.ComponentModel;
using SW.MB.Application.Contracts.Records;
using SW.MB.Domain.Shared.Interfaces;
using SW.MB.UI.WPF.Interfaces;

namespace SW.MB.UI.WPF.Models.Observables
{
    public abstract class ObservableEntity<TRecord, TKey> : ObservableObject, IEntity<TKey>, INavigableObject where TRecord : EntityRecord<TKey> where TKey : struct, IEquatable<TKey>
    {
        public TKey ID { get; init; }

        public DateTime Created { get; init; }

        public string CreatedBy { get; init; }

        public DateTime Updated { get; init; }

        public string UpdatedBy { get; init; }
    }
}
