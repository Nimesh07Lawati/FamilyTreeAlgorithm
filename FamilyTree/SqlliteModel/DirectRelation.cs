using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.SqlliteModel
{
    public class DirectRelation
    {
        [PrimaryKey,AutoIncrement]
        public int DirectRelationId { get; set; }
        public string? RelationType {  get; set; }
        public int FirstPersonId { get; set; }
        public int SecondPersonId {  get; set; }
    }
}
