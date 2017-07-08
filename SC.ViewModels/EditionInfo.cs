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
            Sections = new List<SectionVm>();
            Modules = new List<ModuleVm>();
        }


        public List<SectionVm> Sections { get; set; }

        public List<ModuleVm> Modules { get; set; }
    }
}
