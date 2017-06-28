using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCServer.Core.Dto
{
    public abstract class BasicDto: BaseDto 
    {
        public string Name { get; set; }
        public bool Enabled { get; set; }
    }
}
