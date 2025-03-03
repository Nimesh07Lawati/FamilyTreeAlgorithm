using FamilyTree.RelationDefinition;
using FamilyTree.SqlLiteHelper;
using FamilyTree.SqlliteModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.Algorithm.SearchAlgorithm
{
    public  class FirstPersonSearchAlgorithm
    {
        private readonly DatabaseContext _databaseContext;

        private readonly string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "familytree.db");
        public FirstPersonSearchAlgorithm()
        {
            _databaseContext=new DatabaseContext(dbPath);
        }
        public List<RelationshipResult> GetPersonWithRelationships(int personId, string relationship = "Self", List<RelationshipResult> results = null)
        {
            results ??= new List<RelationshipResult>();

            var person = _databaseContext.GetFirstPersonById(personId);
            if (person == null) return results;

            results.Add(new RelationshipResult
            {
                Person = person,
                RelationshipName = relationship
            });

            if (person.FatherId.HasValue)
            {
                GetPersonWithRelationships(person.FatherId.Value, GetRelationshipName(relationship, "Father"), results);
            }

            if (person.MotherId.HasValue)
            {
                GetPersonWithRelationships(person.MotherId.Value, GetRelationshipName(relationship, "Mother"), results);
            }

            return results;
        }
        private string GetRelationshipName(string currentRelation, string parentType)
        {
            if (currentRelation == "Self")
                return parentType; 

            if (currentRelation == "Father" || currentRelation == "Mother")
                return (parentType == "Father") ? "Grandfather" : "Grandmother";

            if (currentRelation.StartsWith("Grand"))
                return "Great-" + currentRelation;

            return parentType; 
        }

    }
}
