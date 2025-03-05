using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.SqlliteModel
{
    public class IndirectRelation
    {
        [PrimaryKey,AutoIncrement]
        public int IndirectRelationId { get; set; }
        public string RelationType { get; set; }
        public int FirstPersonID {  get; set; }
        public int SecondPersonID { get; set; }
    }
}
