﻿using System.Windows;
using SW.MB.UI.WPF.Views.Windows;

namespace SW.MB.UI.WPF {
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App: Application {
    public App() {

    }

    protected override void OnStartup(StartupEventArgs e) {
      base.OnStartup(e);

      MainWindow = new AppWindow();
      MainWindow.Show();
    }
  }
}