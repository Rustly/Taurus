using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taurus.Commands
{
    public static class CommandAttributes
    {
        [AttributeUsage(AttributeTargets.Parameter)]
        public sealed class OptionalParameter : Attribute
        {
            public object DefaultValue { get; private set; }

            public OptionalParameter(object defaultValue)
            {
                DefaultValue = defaultValue;
            }
        }

        [AttributeUsage(AttributeTargets.Method)]
        public sealed class CustomParser : Attribute
        {
            public Tuple<Type, Func<string, object>> Parser { get; private set; }

            public CustomParser(Type type, Func<string, object> parser)
            {
                Parser = new(type, parser);
            }
        }

        [AttributeUsage(AttributeTargets.Method)]
        public sealed class CommandAttribute : Attribute
        {
            public string[] Names { get; private set; }

            public string HelpText { get; private set; }

            public CommandAttribute(string helpText, params string[] names)
            {
                Names = names;
                HelpText = helpText;
            }
        }
    }
}
