using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using SW.Framework.Extensions;
using SW.MB.Domain.Contracts.Services;
using SW.MB.UI.WinUI3.Models;
using SW.MB.UI.WinUI3.Models.Observables;

namespace SW.MB.UI.WinUI3.ViewModels {
  public class MembersViewModel: ObservableRecipient {
    private bool _IsEditMode;
    private ObservableMember? _SelectedMember;

    public bool IsEditMode {
      get => _IsEditMode;
      set {
        if (SetProperty(ref _IsEditMode, value)) {
          CreateNewCommand.RaiseCanExecuteChanged();
          DeleteCommand.RaiseCanExecuteChanged();
          DiscardChangesCommand.RaiseCanExecuteChanged();
          SaveChangesCommand.RaiseCanExecuteChanged();
        }
      }
    }

    public OrderedObservableCollection<ObservableMember> MembersCollection { get; } = new();

    public ObservableMember? SelectedMember {
      get => _SelectedMember;
      set => SetProperty(ref _SelectedMember, value);
    }

    #region COMMANDS
    public Helpers.RelayCommand CreateNewCommand { get; }
    public Helpers.RelayCommand DeleteCommand { get; }
    public Helpers.RelayCommand DiscardChangesCommand { get; }
    public Helpers.RelayCommand SaveChangesCommand { get; }
    #endregion

    #region CONSTRUCTORS
    public MembersViewModel() {
      LoadDataAsync();

      // Commands
      CreateNewCommand = new Helpers.RelayCommand(() => CreateNewMemberCommand(), () => !IsEditMode);
      DeleteCommand = new Helpers.RelayCommand(() => DeleteSelectedElement(), () => IsEditMode);
      DiscardChangesCommand = new Helpers.RelayCommand(() => DiscardChanges(), () => IsEditMode);
      SaveChangesCommand = new Helpers.RelayCommand(() => SaveChanges());
    }
    #endregion CONSTRUCTORS

    private void CreateNewMemberCommand() {
      IsEditMode = true;
      ObservableMember newMember = new();
      MembersCollection.Add(newMember);
      SelectedMember = newMember;
    }

    private void DeleteSelectedElement() {
      if (SelectedMember is ObservableMember delete) {
        SelectedMember = null;
        MembersCollection.Remove(delete);
        DiscardChanges();
      }
    }

    private void DiscardChanges() {
      System.Diagnostics.Debug.WriteLine("Discard changes...");
      IsEditMode = false;
    }

    private void LoadData() {
      IEnumerable<ObservableMember> members = App.GetService<IMembersService>().GetAll().Select(x => new ObservableMember(x));
      App.Dispatcher.TryEnqueue(() => members.ForEach(x => MembersCollection.Add(x)));
    }

    private async void LoadDataAsync() {
      await Task.Factory.StartNew(() => LoadData());
    }

    private void SaveChanges() {
      if (!IsEditMode) {  // Invert because of timing. IsEditMode is set before execution of this function.
        System.Diagnostics.Debug.WriteLine("Save changes...");
      }
    }
  }
}
