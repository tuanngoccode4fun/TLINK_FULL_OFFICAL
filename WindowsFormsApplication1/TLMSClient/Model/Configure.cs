using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLMSClient.Model
{
    [Serializable]
    public class Configure
    {

        public int Timer { get; set; }
        public string Database { get; set; }
        public bool IsStartWithWindow { get; set; }

    }
}
