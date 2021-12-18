using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taurus.Permissions;

namespace Taurus.Commands
{
    public class ManualCommand : ICommand
    {
        public IEnumerable<string> Names { get; private set; }

        public IEnumerable<string> Permissions { get; private set; }

        public string HelpText { get; private set; }

        private readonly Action<CommandArgs> _handler;

        public ManualCommand(Action<CommandArgs> handler, params string[] names)
        {
            _handler = handler;
            Names = names;
        }

        public ManualCommand WithPermissions(params string[] permissions)
        {
            Permissions = permissions;
            return this;
        }

        public ManualCommand WithHelp(string helpText)
        {
            HelpText = helpText;
            return this;
        }

        public bool CanExecute(IPermissible user)
        {
            return Permissions.Any(s => user.HasPermission(s));
        }

        public void Execute(CommandArgs args)
        {
            _handler(args);
        }
    }
}
