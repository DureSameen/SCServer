using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.ViewModel
{
    public class EditionInfo
    {

        public EditionInfo()
        {
            Modules = new List<ModuleVm>(); 
        
        }


        public List<ModuleVm> Modules { get; set; }


    }
}
