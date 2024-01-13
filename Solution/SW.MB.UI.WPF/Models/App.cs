namespace SW.MB.UI.WPF.Models {
    public static class App {
        private static IServiceProvider? _ServiceProvider;

        public static IServiceProvider ServiceProvider {
            get => _ServiceProvider ?? throw new ApplicationException($"{nameof(ServiceProvider)} is not initialized!");
            private set => _ServiceProvider = value;
        }

        public static void RegisterServiceProvider(IServiceProvider provider) {
            ServiceProvider = provider;
        }
    }
}
