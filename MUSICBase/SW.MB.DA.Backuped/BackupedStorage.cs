using System.Runtime.CompilerServices;
using SW.MB.DA.Contracts.Storages;

[assembly: InternalsVisibleTo("SW.MB.UI.WPF")]

namespace SW.MB.DA.Backuped {
  internal class BackupedStorage : IStorage {
    private readonly IRemoteStorage _RemoteStorage;
    private readonly ILocalStorage _LocalStorage;

    public BackupedStorage(IRemoteStorage remoteStorage, ILocalStorage localStorage) {
      _RemoteStorage = remoteStorage;
      _LocalStorage = localStorage;
    }
  }
}