using NationalParks.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

using System.Collections.Generic;
using System.Linq;

using System;
using System.IO;

namespace NationalParks.Services
{
    public class ParkService
    {
        private readonly IMongoCollection<Park> _parks;

        public ParkService(INationalparksDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _parks = database.GetCollection<Park>(settings.ParksCollectionName);
        }

        public List<Park> Get() =>
            _parks.Find(Park => true).ToList();

        public Park Get(string id) =>
            _parks.Find<Park>(Park => Park.Id == id).FirstOrDefault();

        public Park Create(Park Park)
        {
            _parks.InsertOne(Park);
            return Park;
        }

        public string Load()
        {
            // Loading twice should not duplicate the dataset.
            _parks.DeleteMany(Builders<Park>.Filter.Empty);

            string line;
            int inserted = 0;
            var batch = new List<Park>();

            using (TextReader file = File.OpenText(@"nationalparks.json"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    var bsonDocument = BsonDocument.Parse(line);
                    batch.Add(BsonSerializer.Deserialize<Park>(bsonDocument));

                    if (batch.Count >= 1000)
                    {
                        _parks.InsertMany(batch);
                        inserted += batch.Count;
                        batch.Clear();
                    }
                }
            }

            if (batch.Count > 0)
            {
                _parks.InsertMany(batch);
                inserted += batch.Count;
            }

            return "Items inserted in database: " + inserted;
        }

        public void Update(string id, Park ParkIn) =>
            _parks.ReplaceOne(Park => Park.Id == id, ParkIn);

        public void Remove(Park ParkIn) =>
            _parks.DeleteOne(Park => Park.Id == ParkIn.Id);

        public void Remove(string id) => 
            _parks.DeleteOne(Park => Park.Id == id);
    }
}