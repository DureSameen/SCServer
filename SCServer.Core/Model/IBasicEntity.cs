using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCServer.Core.Model
{
    public interface IBasicEntity : IBaseEntity 
    {

        string Name { get; set; }
        bool Enabled { get; set; }
    }
}
