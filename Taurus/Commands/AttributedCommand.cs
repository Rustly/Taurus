using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Taurus.Permissions;

namespace Taurus.Commands
{
    public class AttributedCommand : ICommand
    {
        public IEnumerable<string> Names { get; private set; }

        public IEnumerable<string> Permissions { get; private set; }

        public string HelpText { get; private set; }

        private readonly MethodInfo _handler;
        private readonly Dictionary<Type, Func<string, object>> _parsers = new()
        {
            { typeof(int), (s) => int.Parse(s) },
            { typeof(byte), (s) => byte.Parse(s) },
            { typeof(short), (s) => short.Parse(s) },
        };

        public AttributedCommand(MethodInfo handler, string[] names, string helpText, Dictionary<Type, Func<string, object>> customParsers)
        {
            _handler = handler;
            Names = names;
            HelpText = helpText;

            foreach (var p in customParsers)
                _parsers[p.Key] = p.Value;
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
                    value = _parsers[param.ParameterType].Invoke(args.Parameters[i]);

                methodArgs[i] = value;
                i++;
            }

            _handler.Invoke(null, methodArgs);
        }
    }
}
