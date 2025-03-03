using FamilyTree.SqlliteModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyTree.SqlLiteHelper
{
    public class DatabaseContext : IDisposable
    {
        private readonly SQLiteConnection _database;
        private bool _disposed = false; 

        public DatabaseContext(string dbPath)
        {
            try
            {//this is git hub test
                _database = new SQLiteConnection(dbPath);
                _database.CreateTable<Person>(); // Create the table if it doesn't exist
                _database.CreateTable<FirstPerson>();
            }
            catch (Exception ex)
            {
                // Log or handle error if the database initialization fails
                throw new Exception("Database initialization failed", ex);
            }
        }
        public FirstPerson GetFirstPersonById(int id) {
            try
            {
                return _database.Find<FirstPerson>(id);
            }
            catch (Exception ex)
            {
                // Log or handle error for retrieving a person
                throw new Exception($"Failed to get person with ID {id}", ex);
            }
        }

        public void SaveFirstPerson(FirstPerson person)
        {
            try
            {
                _database.InsertOrReplace(person);
            }
            catch (Exception ex)
            {
                // Log or handle error for saving a person
                throw new Exception("Failed to save person", ex);
            }
        }
        public List<FirstPerson> GetAllFirstPerson()
        {
            try
            {
                return _database.Table<FirstPerson>().ToList();
            }
            catch (Exception ex)
            {
                // Log or handle error for fetching all people
                throw new Exception("Failed to get all people", ex);
            }
        }
        public void DeleteAllFirstPerson()
        {
            try
            {
                _database.DeleteAll<FirstPerson>();
            }
            catch (Exception ex)
            {
                // Log or handle error for deleting all people
                throw new Exception("Failed to delete all people", ex);
            }
        }

        public Person GetPersonById(int id)
        {
            try
            {
                return _database.Find<Person>(id);
            }
            catch (Exception ex)
            {
                // Log or handle error for retrieving a person
                throw new Exception($"Failed to get person with ID {id}", ex);
            }
        }

        public void SavePerson(Person person)
        {
            try
            {
                _database.InsertOrReplace(person);
            }
            catch (Exception ex)
            {
                // Log or handle error for saving a person
                throw new Exception("Failed to save person", ex);
            }
        }

        public List<Person> GetAllPeople()
        {
            try
            {
                return _database.Table<Person>().ToList();
            }
            catch (Exception ex)
            {
                // Log or handle error for fetching all people
                throw new Exception("Failed to get all people", ex);
            }
        }

        public void DeleteAllPeople()
        {
            try
            {
                _database.DeleteAll<Person>();
            }
            catch (Exception ex)
            {
                // Log or handle error for deleting all people
                throw new Exception("Failed to delete all people", ex);
            }
        }

      
        public void Dispose()
        {
            if (_disposed) return;

            try
            {
                _database.Close();
            }
            catch (Exception ex)
            {
                // Log or handle error for closing the database connection
                throw new Exception("Failed to close the database connection", ex);
            }
            finally
            {
                _disposed = true;
            }
        }
    }
}
