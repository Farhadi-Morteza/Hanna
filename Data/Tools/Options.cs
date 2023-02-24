using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Tools
{
    public class Options : object
    {        
        public Enums.Provider Provider { get; set; }

        public string ConnectionString { get; set; }
    }
}
