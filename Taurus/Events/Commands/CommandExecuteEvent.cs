using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orion.Core.Events;
using Taurus.Commands;

namespace Taurus.Events.Commands
{
    [Event("taurus-commandexecute")]
    public class CommandExecuteEvent : Event
    {
        public ICommand Command { get; set; }

        public CommandArgs Args { get; set; }
    }
}
