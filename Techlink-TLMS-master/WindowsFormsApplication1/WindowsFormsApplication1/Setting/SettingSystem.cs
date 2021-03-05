using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    [Serializable]
  public   class SettingSystem
    {
        public string LastUser { get; set; }
        public DateTime LastUsing { get; set; }
        public string Database_ERP { get; set; }
        public string Database_SFT { get; set; }
        public string Language { get; set; }
    }
}
