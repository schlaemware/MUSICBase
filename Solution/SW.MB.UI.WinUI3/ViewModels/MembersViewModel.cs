using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using SW.Framework.Extensions;
using SW.MB.Domain.Contracts.Services;
using SW.MB.UI.WinUI3.Commands;
using SW.MB.UI.WinUI3.Models;
using SW.MB.UI.WinUI3.Models.Observables;

namespace SW.MB.UI.WinUI3.ViewModels
{
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
      set {
        if (SetProperty(ref _SelectedMember, value)) {
          SaveChangesCommand.RaiseCanExecuteChanged();
        }
      }
    }

    #region COMMANDS
    public RelayCommand CreateNewCommand { get; }
    public RelayCommand DeleteCommand { get; }
    public RelayCommand DiscardChangesCommand { get; }
    public RelayCommand SaveChangesCommand { get; }
    #endregion

    #region CONSTRUCTORS
    public MembersViewModel() {
      LoadDataAsync();

      // Commands
      CreateNewCommand = new RelayCommand(() => CreateNewMemberCommand(), () => !IsEditMode);
      DeleteCommand = new RelayCommand(() => DeleteSelectedElement(), () => IsEditMode);
      DiscardChangesCommand = new RelayCommand(() => DiscardChanges(), () => IsEditMode);
      SaveChangesCommand = new RelayCommand(() => SaveChanges(), () => SelectedMember != null);
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
      IEnumerable<ObservableMember> members = App.GetService<IMembersDataService>().GetAll().Select(x => new ObservableMember(x));
      App.Dispatcher.TryEnqueue(() => members.ForEach(x => MembersCollection.Add(x)));
    }

    private async void LoadDataAsync() {
      await Task.Factory.StartNew(() => LoadData());
    }

    private void SaveChanges() {
      if (!IsEditMode && SelectedMember != null) {  // Invert because of timing. IsEditMode is set before execution of this function.
        IMembersDataService membersService = App.GetService<IMembersDataService>();
        membersService.UpdateRange(SelectedMember.ToRecord());
      }
    }
  }
}
