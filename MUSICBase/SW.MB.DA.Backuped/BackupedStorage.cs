using System.Runtime.CompilerServices;
using SW.MB.DA.Contracts.Repositories;
using SW.MB.DA.Contracts.Storages;
using SW.MB.DA.Models.Records;

namespace SW.MB.DA.Backuped {
    internal class BackupedStorage : IStorage {
        private readonly IRemoteStorage _RemoteStorage;
        private readonly ILocalStorage _LocalStorage;

        #region CONSTRUCTORS
        public BackupedStorage(IRemoteStorage remoteStorage, ILocalStorage localStorage) {
            _RemoteStorage = remoteStorage;
            _LocalStorage = localStorage;
        }
        #endregion CONSTRUCTORS

        #region ICOMPOSITIONSREPOSITORY
        List<CompositionRecord> ICompositionsRepository.GetAll() {
            return _RemoteStorage.GetAll();
        }
        #endregion ICOMPOSITIONSREPOSITORY
    }
}