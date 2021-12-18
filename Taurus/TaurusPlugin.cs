using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orion.Core;
using System.Threading.Tasks;
using Serilog;
using Orion.Core.Players;
using Taurus.Implementation;
using Orion.Core.Utils;

namespace Taurus
{
    [Plugin("taurus-api", Author = "rusty")]
    public class TaurusPlugin : OrionPlugin
    {
        internal static IServer serverReference; // shit temporary fix

        public TaurusPlugin(IServer server, ILogger log, Commands.ICommandProvider commands) : base(server, log)
        {
            serverReference = server;

            commands.AddAttributedCommands(typeof(TaurusCommands));
        }
    }
}
