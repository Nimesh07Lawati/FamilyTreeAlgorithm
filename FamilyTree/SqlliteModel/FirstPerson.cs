using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.SqlliteModel
{
    public class FirstPerson
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? FatherName { get; set; }
        public int?  FatherId { get; set; }

        public string? MotherName { get; set; }
        public int? MotherId { get;set; }
        [Ignore]
        public FirstPerson? Father { get; set; }

        [Ignore]
        public FirstPerson? Mother { get; set; }
    }
}
