using FamilyTree.SqlLiteHelper;
using FamilyTree.SqlliteModel;
using System;
using System.Collections.Generic;
using System.IO;

namespace FamilyTree.Algorithm.SearchAlgorithm
{
    public class PersonWithRelationShip
    {
        private readonly DatabaseContext _databaseContext;

        // Database path
        private readonly string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "familytree.db");

        public PersonWithRelationShip()
        {
            _databaseContext = new DatabaseContext(dbPath);
        }

        // Single recursive method to fetch a person and their relationships
        public Person GetPersonWithRelationships(int personId, HashSet<int> visited = null)
        {
            visited ??= new HashSet<int>();  // Initialize visited set if not provided

            // If we've already visited this person, stop recursion to prevent infinite loops
            if (visited.Contains(personId))
                return null;  // Prevent further recursion (circular reference detected)

            // Mark the current person ID as visited
            visited.Add(personId);

            // Fetch the person from the database
            var person = _databaseContext.GetPersonById(personId);
            if (person == null) return null;  // Return null if no person is found

            // Recursively fetch relationships
            if (person.FatherId.HasValue)
            {
                person.Father = GetPersonWithRelationships(person.FatherId.Value, visited);  // Pass visited set
            }

            if (person.MotherId.HasValue)
            {
                person.Mother = GetPersonWithRelationships(person.MotherId.Value, visited);  // Pass visited set
            }

            if (person.WifeId.HasValue)
            {
                person.Wife = GetPersonWithRelationships(person.WifeId.Value, visited);  // Pass visited set
            }

            return person;  // Return the fully populated person object
        }
    }
}