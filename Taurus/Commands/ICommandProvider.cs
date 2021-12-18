using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taurus.Commands
{
    public interface ICommandProvider
    {
        public ICollection<ICommand> Commands { get; protected set; }

        public void HandleCommand(ICommand command, CommandArgs args);

        public void AddAttributedCommands(Type commandClass);
    }
}
