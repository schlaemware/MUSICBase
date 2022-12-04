using Microsoft.Windows.ApplicationModel.Resources;

namespace SW.MB.UI.WinUI3.Extensions {
    public static class ResourceExtensions {
        private static readonly ResourceLoader _ResourceLoader = new();

        public static string GetLocalizedString(this string resourceKey) => _ResourceLoader.GetString(resourceKey);
    }
}