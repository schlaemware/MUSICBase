namespace SW.MB.Domain.Shared {
    public class MUSICBaseConfiguration
    {
        private DirectoryInfo? _directoryInfo;

        public DirectoryInfo ApplicationDirectory {
            get
            {
                if (_directoryInfo == null)
                {
                    throw new ApplicationException($"{nameof(ApplicationDirectory)} not registered!");
                }
                else if (!_directoryInfo.Exists)
                {
                    _directoryInfo.Create();
                }

                return _directoryInfo;
            }
            init
            {
                if (value != null)
                {
                    _directoryInfo = value;
                }
            }
        }

        public string? MySQLConnectionString { get; init; }
    }
}
