using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyTree.SqlliteModel;

namespace FamilyTree.RelationDefinition
{
    public class RelationshipResult
    {
        public FirstPerson Person { get; set; }
        public string RelationshipName { get; set; }
    }

}
