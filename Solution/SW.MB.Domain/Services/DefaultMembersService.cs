﻿using SW.MB.Data.Contracts.UnitsOfWork;
using SW.MB.Data.Models.Entities;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Extensions;
using SW.MB.Domain.Models.Records;
using SW.MB.Domain.Services.Abstracts;

namespace SW.MB.Domain.Services {
    internal class DefaultMembersService : ServiceBase, IMembersService {
        private readonly IUnitOfWork _UnitOfWork;

        #region CONSTRUCTORS
        public DefaultMembersService(IUnitOfWork uow) : base() {
            _UnitOfWork = uow;
        }
        #endregion CONSTRUCTORS

        public IEnumerable<MemberRecord> GetAll() {
            return _UnitOfWork.Members.Select(x => x.ToRecord());
        }

        public void UpdateRange(params MemberRecord[] records) {
            foreach (MemberRecord record in records) {
                if (_UnitOfWork.Members.SingleOrDefault(x => x.ID == record.ID) is MemberEntity entity) {
                    SetAllProperties(entity, record.ToEntity());
                } else {
                    _UnitOfWork.Members.Add(record.ToEntity());
                }
            }

            _UnitOfWork.SaveChangesAsync();
        }
    }
}
