using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.ValueObject;

namespace User.Domain
{
    public interface ISmsCodeSender
    {
        Task SendAsync(PhoneNumber phone, string code);
    }
}
