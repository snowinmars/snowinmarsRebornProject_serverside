﻿using System;

namespace Simr.Common.Enums
{
    [Flags]
    public enum UserRoles
    {
        Banned = 0,

        User = 1,

        Admin = 2,

        Root = 4,
    }
}