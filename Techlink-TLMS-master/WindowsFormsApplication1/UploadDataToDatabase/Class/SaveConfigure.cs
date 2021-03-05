using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadDataToDatabase
{
    [Serializable]
    public class SaveConfigure
    {
        public    DateTime fromdate { get; set; }
        public DateTime tomdate { get; set; }
        public int hours { get; set; }
        public int minutes { get; set; }
        public int seconds { get; set; }
        public int hours_mail { get; set; }
        public int minutes_mail { get; set; }
        public int seconds_mail { get; set; }
        public bool UpdateShipping { get; set; }
        public bool UpdateProduction { get; set; }
        public bool UpdateMaterial{ get; set; }



    }


}
