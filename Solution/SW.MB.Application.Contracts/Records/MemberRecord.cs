﻿using SW.MB.Domain.Shared.Interfaces;

namespace SW.MB.Application.Contracts.Records
{
    public record class MemberRecord : PersonRecord<int>, IMember
    {

    }
}
