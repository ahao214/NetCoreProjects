﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Domain
{
    public enum UserAccessResult
    {
        Ok, PhoneNumberNotFound, Lockout, NoPassword, PasswordError
    }
}
