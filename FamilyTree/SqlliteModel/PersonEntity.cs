using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.SqlliteModel
{
    public class PersonEntity
    {
        [AutoIncrement,PrimaryKey]
        public int PersonEntityId { get; set; }
        public string PersonName { get; set; }
        public string PersonAddress {  get; set; }
        public string Gender { get; set; }
        public string BirthDate {  get; set; }
    }
}
