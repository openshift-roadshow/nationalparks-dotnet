using NationalParks.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

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

        public void Update(string id, Park ParkIn) =>
            _parks.ReplaceOne(Park => Park.Id == id, ParkIn);

        public void Remove(Park ParkIn) =>
            _parks.DeleteOne(Park => Park.Id == ParkIn.Id);

        public void Remove(string id) => 
            _parks.DeleteOne(Park => Park.Id == id);
    }
}