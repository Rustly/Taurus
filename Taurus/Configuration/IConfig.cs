using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taurus.Configuration
{
    public interface IConfig<T>
    {
        public T Settings { get; set; }

        public void Read();

        public void Write();
    }
}
