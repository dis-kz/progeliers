using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ProjectCtr: CurrentTransform
    {
        public string ConNum { get; set; }
        public string Title { get; set; }

        public int IdProjectEquip { get; set; }
        public int? IdProjectNumber { get; set; }
        public int? IdNote { get; set; }
    }
}
