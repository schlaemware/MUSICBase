﻿using SW.MB.Domain.Models.Records;

namespace SW.MB.Domain.Contracts.Services {
    public interface IBandsService {
        public IEnumerable<BandRecord> GetAll();
        public IEnumerable<BandRecord> GetAll(params MandatorRecord?[]? mandators);

        public void Update(BandRecord record);

        public void UpdateRange(params BandRecord[] records);
    }
}
