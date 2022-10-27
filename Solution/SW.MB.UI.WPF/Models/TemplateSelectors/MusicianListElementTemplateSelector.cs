using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using SW.MB.UI.WPF.Models.Observables;

namespace SW.MB.UI.WPF.Models.TemplateSelectors {
    public class MusicianListElementTemplateSelector : DataTemplateSelector {
        private const string ORIGIN_TEMPLATE_KEY = "MusicianListOriginTemplate";
        private const string PSEUDONYM_TEMPLATE_KEY = "MusicianListPseudonymTemplate";
        private const string BAND_TEMPLATE_KEY = "BandListTemplate";

        private DataTemplate? OriginTemplate;
        private DataTemplate? PseudonymTemplate;

        public override DataTemplate SelectTemplate(object item, DependencyObject container) {
            OriginTemplate ??= Application.Current.FindResource(ORIGIN_TEMPLATE_KEY) as DataTemplate ?? throw new KeyNotFoundException(ORIGIN_TEMPLATE_KEY);
            PseudonymTemplate ??= Application.Current.FindResource(PSEUDONYM_TEMPLATE_KEY) as DataTemplate ?? throw new KeyNotFoundException(PSEUDONYM_TEMPLATE_KEY);

            if (item is ObservableMusician musician) {
                return musician.Origin is null ? OriginTemplate : PseudonymTemplate;
            }

            return base.SelectTemplate(item, container);
        }
    }
}