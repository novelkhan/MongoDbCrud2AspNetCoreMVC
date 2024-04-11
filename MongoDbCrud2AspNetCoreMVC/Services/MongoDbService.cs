using MongoDB.Driver;
using MongoDbCrud2AspNetCoreMVC.Models;

namespace MongoDbCrud2AspNetCoreMVC.Services
{
    public class MongoDbService
    {
        private readonly IMongoCollection<Person> _collection;

        public MongoDbService()
        {
            var client = new MongoClient("mongodb+srv://nvl:q3mfFJz5HM68eLNk@cluster1.2auwomk.mongodb.net/PersonDB2");
            var database = client.GetDatabase("PersonDB2");
            _collection = database.GetCollection<Person>("Persons");
        }

        public async Task<List<Person>> GetAll()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<Person> GetById(string id)
        {
            return await _collection.Find(person => person._id == id).FirstOrDefaultAsync();
        }

        public async Task Create(Person person)
        {
            await _collection.InsertOneAsync(person);
        }

        public async Task Update(string id, Person person)
        {
            await _collection.ReplaceOneAsync(p => p._id == id, person);
        }

        public async Task Delete(string id)
        {
            await _collection.DeleteOneAsync(p => p._id == id);
        }
    }
}
