using JOKER.NetE.Common.Core;
using Microsoft.AspNetCore.Builder;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JOKER.NetE.Extension.ServiceExtensions
{
    public static class ApplicationSetup
    {
        public static void UseApplicationSetup(this WebApplication app)
        {
            app.Lifetime.ApplicationStarted.Register(() =>
            {
                App.IsRun = true;
            });

            app.Lifetime.ApplicationStopped.Register(() =>
            {
                App.IsRun = false;

                // 清除日志
                Log.CloseAndFlush();
            });
        }

    }
}
