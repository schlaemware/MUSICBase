using System;
using System.Collections.Generic;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using SW.MB.UI.WinUI3.Contracts.Services;
using SW.MB.UI.WinUI3.ViewModels;
using SW.MB.UI.WinUI3.Views.Pages;

namespace SW.MB.UI.WinUI3.Services {
  internal class PageService: IPageService {
    private readonly Dictionary<string, Type> _Pages = new();

    #region CONSTRUCTORS
    public PageService() {
      Configure<CompositionsViewModel, CompositionsPage>();
      Configure<HomeViewModel, HomePage>();
      Configure<LoginViewModel, LoginPage>();
      Configure<MandatorsViewModel, MandatorsPage>();
      Configure<MembersViewModel, MembersPage>();
      Configure<MusiciansViewModel, MusiciansPage>();
      Configure<ProgramsViewModel, ProgramsPage>();
      Configure<SettingsViewModel, SettingsPage>();
      Configure<UpdatesViewModel, UpdatesPage>();
      Configure<UsersViewModel, UsersPage>();
    }
    #endregion CONSTRUCTORS

    public Type GetPageType(string key) {
      Type? pageType;

      lock (_Pages) {
        if (!_Pages.TryGetValue(key, out pageType)) {
          throw new ArgumentException($"Page not found: {key}. Did you forget to call PageService.Configure?");
        }
      }

      return pageType;
    }

    private void Configure<VM, V>() where VM : ObservableObject where V : Page {
      lock (_Pages) {
        string? key = typeof(VM).FullName;
        if (key == null) {
          throw new ArgumentException($"Type {typeof(VM).FullName} not found!");
        } else if (_Pages.ContainsKey(key)) {
          throw new ArgumentException($"The viewmodel {key} is already configured in {GetType().FullName}!");
        }

        Type type = typeof(V);
        if (_Pages.Any(p => p.Value == type)) {
          throw new ArgumentException($"the page {type.FullName} is already configured in {GetType().FullName}!");
        }

        _Pages.Add(key, type);
      }
    }
  }
}
