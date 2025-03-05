using FamilyTree.SqlliteModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTree.SqlLiteHelper
{
    public class DataBaseHelper
    {
        private readonly SQLiteConnection _database;
        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "familytree.db");

        public DataBaseHelper()
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<PersonEntity>();
            _database.CreateTable<DirectRelation>();
            _database.CreateTable<IndirectRelation>();
        }

        // PERSON CRUD
        public void InsertPerson(PersonEntity person)
        {
            _database.Insert(person);
        }

        public List<PersonEntity> GetAllPersons()
        {
            return _database.Table<PersonEntity>().ToList();
        }

        public PersonEntity GetPersonById(int id)
        {
            return _database.Table<PersonEntity>().FirstOrDefault(p => p.PersonEntityId == id);
        }

        public void UpdatePerson(PersonEntity person)
        {
            _database.Update(person);
        }

        public void DeletePerson(int id)
        {
            var person = GetPersonById(id);
            if (person != null)
                _database.Delete(person);
        }

        // DIRECT RELATION CRUD
        public void InsertDirectRelation(DirectRelation relation)
        {
            _database.Insert(relation);
        }

        public List<DirectRelation> GetAllDirectRelations()
        {
            return _database.Table<DirectRelation>().ToList();
        }

        public DirectRelation GetDirectRelationById(int id)
        {
            return _database.Table<DirectRelation>().FirstOrDefault(r => r.DirectRelationId == id);
        }

        public void UpdateDirectRelation(DirectRelation relation)
        {
            _database.Update(relation);
        }

        public void DeleteDirectRelation(int id)
        {
            var relation = GetDirectRelationById(id);
            if (relation != null)
                _database.Delete(relation);
        }

        // INDIRECT RELATION CRUD
        public void InsertIndirectRelation(IndirectRelation relation)
        {
            _database.Insert(relation);
        }

        public List<IndirectRelation> GetAllIndirectRelations()
        {
            return _database.Table<IndirectRelation>().ToList();
        }

        public IndirectRelation GetIndirectRelationById(int id)
        {
            return _database.Table<IndirectRelation>().FirstOrDefault(r => r.IndirectRelationId == id);
        }

        public void UpdateIndirectRelation(IndirectRelation relation)
        {
            _database.Update(relation);
        }

        public void DeleteIndirectRelation(int id)
        {
            var relation = GetIndirectRelationById(id);
            if (relation != null)
                _database.Delete(relation);
        }
    }
}
