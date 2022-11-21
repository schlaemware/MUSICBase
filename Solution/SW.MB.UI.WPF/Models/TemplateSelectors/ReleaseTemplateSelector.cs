using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using SW.MB.UI.WPF.Models.Observables;

namespace SW.MB.UI.WPF.Models.TemplateSelectors {
    public class ReleaseTemplateSelector: DataTemplateSelector {
    private const string FUTURE_RELEASE_TEMPLATE_KEY = "ReleaseTemplate";
    private const string CURRENT_RELEASE_TEMPLATE_KEY = "CurrentReleaseTemplate";
    private const string PAST_RELEASE_TEMPLATE_KEY = "PastReleaseTemplate";

    private DataTemplate? _FutureTemplate;
    private DataTemplate? _CurrentTemplate;
    private DataTemplate? _PastTemplate;

    public override DataTemplate SelectTemplate(object item, DependencyObject container) {
      _FutureTemplate ??= FindTemplate(FUTURE_RELEASE_TEMPLATE_KEY);
      _CurrentTemplate ??= FindTemplate(CURRENT_RELEASE_TEMPLATE_KEY);
      _PastTemplate ??= FindTemplate(PAST_RELEASE_TEMPLATE_KEY);

      if (item is ObservableRelease release) {
        if (release.Version > Assembly.GetExecutingAssembly().GetName().Version) {
          return _FutureTemplate;
        } else if (release.Version == Assembly.GetExecutingAssembly().GetName().Version) {
          return _CurrentTemplate;
        }

        return _PastTemplate;
      }

      return base.SelectTemplate(item, container);
    }

    private DataTemplate FindTemplate(string key) {
      return Application.Current.FindResource(key) as DataTemplate ?? throw new KeyNotFoundException(key);
    }
  }
}