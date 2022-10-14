using System;
using Microsoft.Extensions.DependencyInjection;
using SW.Framework.WPF;

namespace SW.MB.UI.WPF.ViewModels {
  public class AppViewModel: ViewModel {
    public ViewModel? CompositionsViewModel { get; }
    public ViewModel? MandatorsViewModel { get; }
    public ViewModel? MembersViewModel { get; }
    public ViewModel? MusiciansViewModel { get; }
    public ViewModel? SettingsViewModel { get; }
    public ViewModel? UpdatesViewModel { get; }
    public ViewModel? UsersViewModel { get; }

    #region CONSTRUCTORS
    public AppViewModel(IServiceProvider serviceProvider) : base(serviceProvider) {
      CompositionsViewModel = serviceProvider.GetService<CompositionsViewModel>();
      MandatorsViewModel = serviceProvider.GetService<MandatorsViewModel>();
      MembersViewModel = serviceProvider.GetService<MembersViewModel>();
      MusiciansViewModel = serviceProvider.GetService<MusiciansViewModel>();
      SettingsViewModel = serviceProvider.GetService<SettingsViewModel>();
      UpdatesViewModel = serviceProvider.GetService<UpdatesViewModel>();
      UsersViewModel = serviceProvider.GetService<UsersViewModel>();
    }
    #endregion CONSTRUCTORS
  }
}
