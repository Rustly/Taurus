using Orion.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taurus.Configuration
{
    [Binding(nameof(TaurusConfig), Author = "rusty")]
    public class TaurusConfig : JsonConfigBase<TaurusConfig>
    {
        public override string FilePath => "s";

        public string CommandSpecifier { get; set; } = "/";

        public string CommandSpecifierSilent { get; set; } = ".";
    }
}
