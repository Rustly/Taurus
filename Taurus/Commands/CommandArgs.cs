using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taurus.Commands
{
    public class CommandArgs
    {
        public IList<string> Parameters { get; private set; }

        public ICommandSender Sender { get; private set; }

        public CommandArgs(IList<string> parameters, ICommandSender sender)
        {
            Parameters = parameters;
            Sender = sender;
        }
    }
}
