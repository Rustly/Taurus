using Orion.Core;
using Orion.Core.Events;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Taurus.Commands;
using Taurus.Configuration;
using Taurus.Events.Commands;

namespace Taurus.Implementation
{
    [Binding(nameof(TaurusCommandProvider), Author = "rusty")]
    public class TaurusCommandProvider : ICommandProvider
    {
        public ICollection<ICommand> Commands { get; set; }

        private readonly ILogger _logger;
        private readonly IServer _server;

        public TaurusCommandProvider(IServer server, ILogger logger, IConfig<TaurusConfig> config)
        {
            _logger = logger;
            _server = server;
            Commands = new List<ICommand>();
        }

        public void AddAttributedCommands(Type commandClass)
        {
            foreach (var method in commandClass.GetMethods())
            {
                var attr = method.GetCustomAttribute<CommandAttributes.CommandAttribute>();

                if (attr != null)
                {
                    Commands.Add(new AttributedCommand(method, attr.Names, attr.HelpText, method.GetCustomAttributes<CommandAttributes.CustomParser>()
                        .ToDictionary(s => s.Parser.Item1, s => s.Parser.Item2)));
                }
            }
        }

        public void HandleCommand(ICommand command, CommandArgs args)
        {
            try
            {
                command?.Execute(args);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "test");
            }
        }

        [EventHandler(nameof(TaurusCommandProvider))]
        private void HandleChat(Orion.Core.Events.Players.PlayerChatEvent args)
        {
            if (!args.Player.IsActive)
            {
                args.Cancel("playerinactive");
                return;
            }

            if (args.Message.Length > 500)
            {
                //todo, ban structure
            }

            _server.Events.Forward(args, new CommandExecuteEvent(), _logger);

            if (args.IsCanceled)
            {

            }
        }
    }
}
