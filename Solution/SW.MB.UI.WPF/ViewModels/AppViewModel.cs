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
  public class AppViewModel: ViewModel {
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
      if (ServiceProvider.GetService<ICompositionsService>() is ICompositionsService service) {
        Compositions.Clear();
        foreach (CompositionRecord composition in service.GetAll()) {
          Compositions.Add(new ObservableComposition(composition));
        }
      }
    }

    private void LoadMandators() {
      if (ServiceProvider.GetService<IMandatorsService>() is IMandatorsService service) {
        Mandators.Clear();
        foreach (MandatorRecord mandator in service.GetAll()) {
          Mandators.Add(new ObservableMandator(mandator));
        }
      }
    }

    private void LoadMembers() {
      if (ServiceProvider.GetService<IMembersService>() is IMembersService service) {
        foreach (MemberRecord member in service.GetAll()) {
          Members.Add(new ObservableMember(member));
        }
      }
    }

    private void LoadMusicians() {
      if (ServiceProvider.GetService<IMusiciansService>() is IMusiciansService service) {
        foreach (MusicianRecord musician in service.GetAll()) {
          Musicians.Add(new ObservableMusician(musician));
        }
      }
    }

    private void LoadUsers() {
      if (ServiceProvider.GetRequiredService<IUsersService>() is IUsersService service) {
        foreach (UserRecord user in service.GetAll()) {
          Users.Add(new ObservableUser(user));
        }
      }
    }

    private void StoreCompositions() {
      if (ServiceProvider.GetService<ICompositionsService>() is ICompositionsService service) {
        service.UpdateRange(Compositions.Select(x => x.ToRecord()).ToArray());
        LoadCompositions();
      }
    }

    private void StoreMandators() {
      if (ServiceProvider.GetService<IMandatorsService>() is IMandatorsService service) {
        service.UpdateRange(Mandators.Select(x => x.ToRecord()).ToArray());
        LoadMandators();
      }
    }

    private void StoreMembers() {
      if (ServiceProvider.GetService<IMembersService>() is IMembersService service) {
        service.UpdateRange(Members.Select(x => x.ToRecord()).ToArray());
        LoadMembers();
      }
    }

    private void StoreMusicians() {
      if (ServiceProvider.GetService<IMusiciansService>() is IMusiciansService service) {
        service.UpdateRange(Musicians.Select(x => x.ToRecord()).ToArray());
        LoadMusicians();
      }
    }

    private void StoreUsers() {
      if (ServiceProvider.GetService<IUsersService>() is IUsersService service) {
        service.UpdateRange(Users.Select(x => x.ToRecord()).ToArray());
        LoadUsers();
      }
    }
  }
}
