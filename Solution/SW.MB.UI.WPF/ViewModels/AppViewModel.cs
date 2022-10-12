using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using SW.Framework.WPF;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Models.Records;
using SW.MB.UI.WPF.Models.Observables;

namespace SW.MB.UI.WPF.ViewModels {
    public class AppViewModel : ViewModel {
        public ObservableCollection<ObservableComposition> Compositions { get; } = new();
        public ObservableCollection<ObservableMandator> Mandators { get; } = new();
        public ObservableCollection<ObservableMember> Members { get; } = new();
        public ObservableCollection<ObservableMusician> Musicians { get; } = new();
        public ObservableCollection<ObservableUser> Users { get; } = new();

        #region COMMANDS
        public ICommand StoreCompositionsCommand { get; }
        public ICommand StoreMandatorsCommand { get; }
        public ICommand StoreMembersCommand { get; }
        public ICommand StoreMusiciansCommand { get; }
        public ICommand StoreUsersCommand { get; }
        #endregion COMMANDS

        #region CONSTRUCTORS
        public AppViewModel(IServiceProvider serviceProvider) : base(serviceProvider) {
            StoreCompositionsCommand = new RelayCommand(obj => StoreCompositions(), obj => true);
            StoreMandatorsCommand = new RelayCommand(obj => StoreMandators(), obj => true);
            StoreMembersCommand = new RelayCommand(obj => StoreMembers(), obj => true);
            StoreMusiciansCommand = new RelayCommand(obj => StoreMusicians(), obj => true);
            StoreUsersCommand = new RelayCommand(obj => StoreUsers(), obj => true);

            LoadCompositions();
            LoadMandators();
            LoadMembers();
            LoadMusicians();
            LoadUsers();
        }
        #endregion CONSTRUCTORS

        private void LoadCompositions() {
            ICompositionsService service = ServiceProvider.GetRequiredService<ICompositionsService>();
            foreach (CompositionRecord composition in service.GetAll()) {
                Compositions.Add(new ObservableComposition(composition));
            }
        }

        private void LoadMandators() {
            IMandatorsService service = ServiceProvider.GetRequiredService<IMandatorsService>();
            foreach (MandatorRecord mandator in service.GetAll()) {
                Mandators.Add(new ObservableMandator(mandator));
            }
        }

        private void LoadMembers() {
            IMembersService service = ServiceProvider.GetRequiredService<IMembersService>();
            foreach (MemberRecord member in service.GetAll()) {
                Members.Add(new ObservableMember(member));
            }
        }

        private void LoadMusicians() {
            IMusiciansService service = ServiceProvider.GetRequiredService<IMusiciansService>();
            foreach (MusicianRecord musician in service.GetAll()) {
                Musicians.Add(new ObservableMusician(musician));
            }
        }

        private void LoadUsers() {
            IUsersService service = ServiceProvider.GetRequiredService<IUsersService>();
            foreach (UserRecord user in service.GetAll()) {
                Users.Add(new ObservableUser(user));
            }
        }

        private void StoreCompositions() {
            ICompositionsService service = ServiceProvider.GetRequiredService<ICompositionsService>();
            service.UpdateRange(Compositions.Select(x => x.ToRecord()).ToArray());
        }

        private void StoreMandators() {
            IMandatorsService service = ServiceProvider.GetRequiredService<IMandatorsService>();
            service.UpdateRange(Mandators.Select(x => x.ToRecord()).ToArray());
        }

        private void StoreMembers() {
            IMembersService service = ServiceProvider.GetRequiredService<IMembersService>();
            service.UpdateRange(Members.Select(x => x.ToRecord()).ToArray());
        }

        private void StoreMusicians() {
            IMusiciansService service = ServiceProvider.GetRequiredService<IMusiciansService>();
            service.UpdateRange(Musicians.Select(x => x.ToRecord()).ToArray());
        }

        private void StoreUsers() {
            IUsersService service = ServiceProvider.GetRequiredService<IUsersService>();
            service.UpdateRange(Users.Select(x => x.ToRecord()).ToArray());
        }
    }
}
