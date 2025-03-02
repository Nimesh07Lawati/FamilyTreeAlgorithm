using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.SqlliteModel
{
    public  class SharedProperties
    {
        public int FatherId { get; set; }

        public SharedProperties(int fatherId)
        {
            FatherId = fatherId;
        }

      
    }
}
