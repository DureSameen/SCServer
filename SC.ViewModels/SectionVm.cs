using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.ViewModel
{
    

    public class SectionVm
    {

        public SectionVm()
        {
            Modules = new List<ModuleVm>();

        }
        public string Name { get; set; }

        public List<ModuleVm> Modules { get; set; }


    }
}
