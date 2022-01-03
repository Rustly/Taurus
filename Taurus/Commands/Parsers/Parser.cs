using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taurus.Commands.Parsers
{
    public static class Parser
    {
        private static readonly Lazy<Dictionary<Type, Func<string, object>>> _baseParsers = new(GeneratePrimitive);

        private static Dictionary<Type, Func<string, object>> GeneratePrimitive()
        {
            var func = new Dictionary<Type, Func<string, object>>();
            func[typeof(byte)] = (s) => byte.Parse(s);
            func[typeof(sbyte)] = (s) => sbyte.Parse(s);
            func[typeof(short)] = (s) => short.Parse(s);
            func[typeof(ushort)] = (s) => ushort.Parse(s);
            func[typeof(int)] = (s) => int.Parse(s);
            func[typeof(uint)] = (s) => uint.Parse(s);
            func[typeof(nint)] = (s) => nint.Parse(s);
            func[typeof(nuint)] = (s) => nuint.Parse(s);
            func[typeof(long)] = (s) => long.Parse(s);
            func[typeof(ulong)] = (s) => ulong.Parse(s);
            func[typeof(float)] = (s) => float.Parse(s);
            func[typeof(double)] = (s) => double.Parse(s);
            func[typeof(decimal)] = (s) => decimal.Parse(s);
            func[typeof(bool)] = (s) => bool.Parse(s);

            func[typeof(UserAccounts.UserAccount)] = (s) => EntityParsers.ParseUserAccount(s);
            func[typeof(UserGroups.UserGroup)] = (s) => EntityParsers.ParseUserGroup(s);
            func[typeof(Regions.Region)] = (s) => EntityParsers.ParseRegion(s);
            func[typeof(TimeSpan)] = (s) => TimeParser.ParseTimeSpan(s);
            func[typeof(DateTime)] = (s) => TimeParser.ParseDateTime(s);
            return func;
        }

        public static object GetValue(Type t, string parameter)
            => _baseParsers.Value[t]?.Invoke(parameter) ?? throw new ArgumentNullException(nameof(t), "No parser found for this type!");

        public static Func<string, object> GetDelegate(Type t)
            => _baseParsers.Value[t] ?? throw new ArgumentNullException(nameof(t), "No parser found for this type.");

        public static bool Add(Type t, Func<string, object> parser)
        {
            if (_baseParsers.Value.ContainsKey(t))
                return false;
            _baseParsers.Value.Add(t, parser);
            return true;
        }

        public static bool Remove(Type t)
            => _baseParsers.Value.Remove(t);
    }
}
