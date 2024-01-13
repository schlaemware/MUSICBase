using System.Collections.ObjectModel;
using System.Windows.Threading;
using AutoMapper;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using SW.MB.Application.Contracts.Records;
using SW.MB.Application.Contracts.Services;
using SW.MB.UI.WPF.Models;
using SW.MB.UI.WPF.Models.Observables;

namespace SW.MB.UI.WPF.ViewModels {
    public abstract class DataViewModel<TObservable, TRecord, TKey> : BaseViewModel where TObservable : ObservableEntity<TRecord, TKey> where TRecord : EntityRecord<TKey> where TKey : struct, IEquatable<TKey>
    {
        protected readonly IMapper _mapper;

        public ObservableCollection<TObservable> Items { get; } = [];

        public IAsyncRelayCommand SynchronizeDataCommand { get; }

        public DataViewModel(IMapper mapper) : base() {
            _mapper = mapper;

            SynchronizeDataCommand = new AsyncRelayCommand(SynchronizeData);
        }

        protected virtual async Task SynchronizeData() {
            foreach (TRecord rec in await App.ServiceProvider.GetRequiredService<IDataService<TRecord, TKey>>().GetRecordsAsync()) {
                await Dispatcher.CurrentDispatcher.BeginInvoke(() => Items.Add(_mapper.Map<TObservable>(rec)));
            }
        }
    }
}
