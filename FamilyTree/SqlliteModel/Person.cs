using SQLite;

namespace FamilyTree.SqlliteModel
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }
        public string Name { get; set; }

        // Foreign keys
        public int? FatherId { get; set; }
        public int? MotherId { get; set; }
        public int? WifeId { get; set; }

        // Names of related entities (stored in the database)
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string WifeName { get; set; }

        // Navigation properties (not stored in the database)
        [Ignore]
        public Person Father { get; set; }

        [Ignore]
        public Person Mother { get; set; }

        [Ignore]
        public Person Wife { get; set; }
    }
}