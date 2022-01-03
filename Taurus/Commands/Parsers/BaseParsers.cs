namespace Taurus.Commands.Parsers
{
    public static class BaseParsers
    {
        private static readonly Dictionary<Type, Func<string, object>> _baseParsers;

        static BaseParsers()
            => _baseParsers = new()
            {
                { typeof(byte), (s) => byte.Parse(s) },
                { typeof(sbyte), (s) => sbyte.Parse(s) },
                { typeof(short), (s) => short.Parse(s) },
                { typeof(ushort), (s) => ushort.Parse(s) },
                { typeof(int), (s) => int.Parse(s) },
                { typeof(uint), (s) => uint.Parse(s) },
                { typeof(nint), (s) => nint.Parse(s) },
                { typeof(nuint), (s) => nuint.Parse(s) },
                { typeof(long), (s) => long.Parse(s) },
                { typeof(ulong), (s) => ulong.Parse(s) },
                { typeof(float), (s) => float.Parse(s) },
                { typeof(double), (s) => double.Parse(s) },
                { typeof(decimal), (s) => decimal.Parse(s) },
                { typeof(bool), (s) => bool.Parse(s) },
                { typeof(UserAccounts.UserAccount), (s) => EntityParsers.ParseUserAccount(s) },
                { typeof(UserGroups.UserGroup), (s) => EntityParsers.ParseUserGroup(s) },
                { typeof(Regions.Region), (s) => EntityParsers.ParseRegion(s) },
                { typeof(TimeSpan), (s) => TimeParser.ParseTimeSpan(s) },
                { typeof(DateTime), (s) => TimeParser.ParseDateTime(s) }
            };

        public static object GetValue(Type t, string parameter)
            => _baseParsers[t]?.Invoke(parameter) ?? throw new ArgumentNullException(nameof(t), "No parser found for this type!");

        public static Func<string, object> GetDelegate(Type t)
            => _baseParsers[t] ?? throw new ArgumentNullException(nameof(t), "No parser found for this type.");

        public static bool Add(Type t, Func<string, object> parser)
        {
            if (_baseParsers.ContainsKey(t))
                return false;
            _baseParsers.Add(t, parser);
            return true;
        }

        public static bool Remove(Type t)
            => _baseParsers.Remove(t);
    }
}
