using Automate.Interfaces;
using Automate.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Automate.Utils
{
    public class MongoDBService : IMongoDBService
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<User> _users;
        private readonly IMongoCollection<Tache> _taches;

        public MongoDBService(string databaseName)
        {
            var client = new MongoClient("mongodb://localhost:27017/AutomateDB");
            _database = client.GetDatabase(databaseName);
            _users = _database.GetCollection<User>("Users");
            _taches = _database.GetCollection<Tache>("Taches");
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }

        public User? Authenticate(string? username, string? password)
        {
            User? user = _users.Find(u => u.Username == username).FirstOrDefault();
            if (user != null && BCrypt.Net.BCrypt.EnhancedVerify(password, user.Password))
            {
                return user;
            }
            return null;
        }

        public void RegisterUser(User user)
        {
            _users.InsertOne(user);
        }

        public void AjouterTache(Tache tache)
        {
            _taches.InsertOne(tache);
        }

        public void UpdateTask(Tache nouvelleTache)
        {
            var result = _taches.ReplaceOne(tache => tache.Id == nouvelleTache.Id, nouvelleTache);
            _taches.ReplaceOne(tache => tache.Id == nouvelleTache.Id, nouvelleTache);

        }

        public void DeleteTache(ObjectId id)
        {
            _taches.DeleteOne(tache => tache.Id == id);
        }


        public List<Tache> GetTachesForMonth(int year, int month)
        {
            IMongoCollection<BsonDocument> collection = _database.GetCollection<BsonDocument>("Taches");

            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Gte("Date", new DateTime(year, month, 1)),
                Builders<BsonDocument>.Filter.Lt("Date", new DateTime(year, month, 1).AddMonths(1))
            );

            List<BsonDocument> documents = collection.Find(filter).ToList();

            List<Tache> taches = new();
            foreach (BsonDocument doc in documents)
            {
                string type = doc["Type"].AsString;
                ObjectId id = doc["_id"].AsObjectId;

                string description = doc.Contains("Description") && doc["Description"].IsBsonNull ? string.Empty : doc["Description"].AsString;
                string alert = doc.Contains("Alert") && doc["Alert"].IsBsonNull ? string.Empty : doc["Alert"].AsString;

                Tache tache = Tache.CreateInstance(type, description, alert, doc["Date"].ToUniversalTime());
                tache.Id = id;
                taches.Add(tache);
            }
            return taches;
        }


        public List<Alert> GetAllAlerts()
        {
            IMongoCollection<BsonDocument>? collection = _database.GetCollection<BsonDocument>("Taches");

            List<BsonDocument>? documents = collection.Find(new BsonDocument()).ToList();

            List<Alert>? alerts = new();

            foreach (BsonDocument doc in documents)
            {
                string description = doc.Contains("Description") && doc["Description"] != BsonNull.Value
                    ? doc["Description"].AsString
                    : string.Empty;

                string alertValue = doc.Contains("Alert") && doc["Alert"] != BsonNull.Value
                    ? doc["Alert"].AsString
                    : string.Empty;

                TypeAlertInt alertType = Enum.TryParse(alertValue, out TypeAlertInt parsedAlert)
                    ? parsedAlert
                    : TypeAlertInt.AucuneAlerte;

                DateTime date = doc["Date"].ToUniversalTime();

                Alert alert = new(description, alertType, date);
                alerts.Add(alert);
            }

            return alerts;
        }
    }
}
