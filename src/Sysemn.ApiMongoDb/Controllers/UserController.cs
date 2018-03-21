using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Sysemn.ApiMongoDb.Models;

namespace Sysemn.ApiMongoDb.Controllers
{
    [Route("Sysemn/[controller]")]
    public class UserController : Controller
    {
        private IMongoDatabase _mongoDb;
        public UserController() => _mongoDb = new MongoClient("mongodb://localhost:27017").GetDatabase("UserBd");

        [HttpGet]
        public IEnumerable<UserModel> Get() => _mongoDb.GetCollection<UserModel>("Users").Find(FilterDefinition<UserModel>.Empty).ToList();

        [HttpGet("{login}")]
        public UserModel Get(string login) => _mongoDb.GetCollection<UserModel>("Users").Find(x => x.Login == login).FirstOrDefault();

        [HttpPost]
        public void Post([FromBody]UserModel userModel) => _mongoDb.GetCollection<UserModel>("Users").InsertOne(userModel);

        [HttpPut]
        public void Put([FromBody]UserModel userModel)
        {
            var filter = Builders<UserModel>.Filter.Eq("Id", userModel.Id);

            var updatestatement = Builders<UserModel>.Update.Set("Id", userModel.Id);
            updatestatement = updatestatement.Set("Name", userModel.Name);
            updatestatement = updatestatement.Set("Login", userModel.Login);
            updatestatement = updatestatement.Set("Email", userModel.Email);

            _mongoDb.GetCollection<UserModel>("Users").UpdateOne(filter, updatestatement);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id) => _mongoDb.GetCollection<UserModel>("Users").DeleteOne<UserModel>(x => x.Id == id);
    }
}
