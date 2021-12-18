using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taurus
{
    internal interface IWrapping<out TWrapped>
    {
        TWrapped Wrapped { get; }
    }
}
