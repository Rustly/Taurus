using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taurus.Permissions;

namespace Taurus.Commands
{
    public interface ICommand
    {
        public IEnumerable<string> Names { get; }

        public IEnumerable<string> Permissions { get; }

        public string HelpText { get; }

        public bool CanExecute(IPermissible user);

        public void Execute(CommandArgs args);
    }

    public static class CommandExtensions
    {
        public static bool HasAlias(this ICommand c, string name) => c.Names.Any(s => s == name);
    }
}
