using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using Microsoft.Extensions.DependencyInjection;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Models.Records;
using SW.MB.UI.WPF.Models.Observables;

namespace SW.MB.UI.WPF.ViewModels {
  public class MembersViewModel: PageViewModel {
    private ObservableMember? _SelectedMember;

    public ObservableCollection<ObservableMember> Members { get; } = new();

    public ICollectionView MembersView { get; }

    public ObservableMember? SelectedMember {
      get => _SelectedMember;
      set => SetProperty(ref _SelectedMember, value);
    }

    #region CONSTRUCTORS
    public MembersViewModel(IServiceProvider serviceProvider) : base(serviceProvider) {
      IMandatorsService.MandatorChanged += IMandatorsService_MandatorChanged;

      LoadMembers();

      MembersView = CreateView(Members);
    }
    #endregion CONSTRUCTORS

    private static ICollectionView CreateView(object source) {
      ICollectionView view = CollectionViewSource.GetDefaultView(source);
      view.SortDescriptions.Add(new SortDescription(nameof(ObservableMember.Lastname), ListSortDirection.Ascending));
      view.SortDescriptions.Add(new SortDescription(nameof(ObservableMember.Firstname), ListSortDirection.Ascending));
      view.SortDescriptions.Add(new SortDescription(nameof(ObservableMember.ID), ListSortDirection.Ascending));

      return view;
    }

    private void LoadMembers() {
      if (ServiceProvider.GetService<IMembersService>() is IMembersService service) {
        Members.Clear();

        foreach (MemberRecord member in service.GetAll(ActiveMandator?.ToRecord())) {
          Members.Add(new ObservableMember(member));
        }
      }
    }

    private void StoreMembers() {
      if (ServiceProvider.GetService<IMembersService>() is IMembersService service) {
        service.UpdateRange(Members.Select(x => x.ToRecord()).ToArray());
        LoadMembers();
      }
    }

    #region CALLBACKS
    private void IMandatorsService_MandatorChanged(object? sender, EventArgs e) {
      LoadMembers();
    }
    #endregion CALLBACKS
  }
}
