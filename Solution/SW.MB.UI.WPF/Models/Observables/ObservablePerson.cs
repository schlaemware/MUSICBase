using SW.MB.Application.Contracts.Records;
using SW.MB.Domain.Shared.Interfaces;

namespace SW.MB.UI.WPF.Models.Observables {
    public abstract class ObservablePerson<TRecord, TKey> : ObservableEntity<TRecord, TKey>, IPerson<TKey> where TRecord : PersonRecord<TKey> where TKey : struct, IEquatable<TKey> {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateOnly? DateOfBirth { get; set; }
    }
}
