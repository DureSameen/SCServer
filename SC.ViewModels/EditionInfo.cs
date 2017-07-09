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
            
        }


        public List<SectionVm> Sections { get; set; }

         
    }
}
