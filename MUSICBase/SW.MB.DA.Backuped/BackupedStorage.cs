using System.Runtime.CompilerServices;
using SW.MB.DA.Contracts.Repositories;
using SW.MB.DA.Contracts.Storages;

namespace SW.MB.DA.Backuped {
  internal class BackupedStorage : ICompositionsRepository, IMusiciansRepository {
    private readonly IRemoteStorage _RemoteStorage;
    private readonly ILocalStorage _LocalStorage;

    public BackupedStorage(IRemoteStorage remoteStorage, ILocalStorage localStorage) {
      _RemoteStorage = remoteStorage;
      _LocalStorage = localStorage;
    }
  }
}