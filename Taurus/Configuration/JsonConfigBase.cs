using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taurus.Configuration
{
    public abstract class JsonConfigBase<T> : IConfig<T> where T : new()
    {
        public T Settings { get; set; }

        public abstract string FilePath { get; }

        public JsonConfigBase()
        {
            if (File.Exists(FilePath))
                Read();
            else
                Settings = new T();

            Write();
        }

        public virtual void Read() => Settings = JsonConvert.DeserializeObject<T>(File.ReadAllText(FilePath), new JsonSerializerSettings() 
            { NullValueHandling = NullValueHandling.Ignore });

        public virtual void Write() => File.WriteAllText(FilePath, JsonConvert.SerializeObject(Settings, Formatting.Indented));
    }
}
