using System.Reflection;
using Taurus.Commands.Parsers;
using Taurus.Permissions;

namespace Taurus.Commands
{
    public class AttributedCommand : ICommand
    {
        public IEnumerable<string> Names { get; private set; }

        public IEnumerable<string> Permissions { get; private set; }

        public string HelpText { get; private set; }

        private readonly MethodInfo _handler;

        public AttributedCommand(MethodInfo handler, string[] names, string helpText)
        {
            _handler = handler;
            Names = names;
            HelpText = helpText;
        }

        public bool CanExecute(IPermissible user)
        {
            return Permissions.Any(s => user.HasPermission(s));
        }

        public void Execute(CommandArgs args)
        {
            var i = 0;
            var handlerParameters = _handler.GetParameters();
            var methodArgs = new object[handlerParameters.Length];

            foreach (var param in handlerParameters)
            {
                object value;

                if (i < args.Parameters.Count)
                {
                    var optionalAttr = param.GetCustomAttribute<CommandAttributes.OptionalParameter>();

                    if (optionalAttr != null)
                        value = optionalAttr.DefaultValue;
                    else
                    {
                        // send error
                        return;
                    }
                }
                else
                    value = Parser.GetValue(param.ParameterType, args.Parameters[i]);

                methodArgs[i] = value;
                i++;
            }

            _handler.Invoke(null, methodArgs);
        }
    }
}
