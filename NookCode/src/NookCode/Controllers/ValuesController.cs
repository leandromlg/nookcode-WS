using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace NookCode.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        static BsonDocument[] CreateSeedData()
        {
            BsonDocument nutricionista1 = new BsonDocument {
        { "Nome" , "Leandro Marcelino" },
        { "CPF" , "09548369443" },
        { "CRN" , "7879" },
        { "Endereco" , "Rua Prefeito Francisco Assis Neves Nobrega" },
        { "Telefone" , "83999325493" },
        { "Celular" , "83999325493" },
        { "Email" , "leandrogomes@gmail.com" },
        { "Senha" , "senha123" },
        { "Instagram" , "leandromlg" },
        { "Facebook" , "leandromlg" },
        { "Twitter" , "leandromlg" }
      };

            BsonDocument nutricionista2 = new BsonDocument {
          { "Nome" , "Glaube Nobrega" },
        { "CPF" , "09548369443" },
        { "CRN" , "7880" },
        { "Endereco" , "Rua Prefeito Francisco Assis Neves Nobrega" },
        { "Telefone" , "83999325493" },
        { "Celular" , "83999325493" },
        { "Email" , "glaube@gmail.com" },
        { "Senha" , "senha123" },
        { "Instagram" , "glaubeonobrega" },
        { "Facebook" , "glaubeonobrega" },
        { "Twitter" , "glaubeonobrega" }
      };

            BsonDocument nutricionista3 = new BsonDocument {
          { "Nome" , "Bruno Felix" },
        { "CPF" , "09548369443" },
        { "CRN" , "7881" },
        { "Endereco" , "Rua Prefeito Francisco Assis Neves Nobrega" },
        { "Telefone" , "83999325493" },
        { "Celular" , "83999325493" },
        { "Email" , "brunofelix@gmail.com" },
        { "Senha" , "senha123" },
        { "Instagram" , "felixbruno" },
        { "Facebook" , "felixbruno" },
        { "Twitter" , "felixbruno" },
      };

            BsonDocument[] SeedData = { nutricionista1, nutricionista2, nutricionista3 };
            return SeedData;
        }

        async static Task AsyncCrud(BsonDocument[] seedData)
        {
            // Create seed data
            //BsonDocument[] songData = seedData;

            //// Standard URI format: mongodb://[dbuser:dbpassword@]host:port/dbname
            //String uri = "mongodb://nookcodeadm:St*+8802@ds115472.mlab.com:15472/nookcode";

            //var client = new MongoClient(uri);
            //var db = client.GetDatabase("nookcode");

            ///*
            // * First we'll add a few songs. Nothing is required to create the
            // * songs collection; it is created automatically when we insert.
            // */

            //var songs = db.GetCollection<BsonDocument>("nutricionistas");

            //// Use InsertOneAsync for single BsonDocument insertion.
            //await songs.InsertManyAsync(songData);

            ///*
            // * Then we need to give Boyz II Men credit for their contribution to
            // * the hit "One Sweet Day".
            // */

            //////var updateFilter = Builders<BsonDocument>.Filter.Eq("Title", "One Sweet Day");
            //////var update = Builders<BsonDocument>.Update.Set("Artist", "Mariah Carey ft. Boyz II Men");

            //////await songs.UpdateOneAsync(updateFilter, update);

            ///*
            // * Finally we run a query which returns all the hits that spent 10 
            // * or more weeks at number 1.
            // */

            //var filter = Builders<BsonDocument>.Filter.Gte("Nome", 10);
            //var sort = Builders<BsonDocument>.Sort.Ascending("CRN");

            //await songs.Find(filter).Sort(sort).ForEachAsync(song =>
            //  Console.WriteLine("In the {0}, {1} by {2} topped the charts for {3} straight weeks",
            //    song["Nome"], song["CPF"], song["Celular"], song["Email"])
            //);

            // Since this is an example, we'll clean up after ourselves.
            ////await db.DropCollectionAsync("songs");
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            //BsonDocument[] seedData = CreateSeedData();
            //AsyncCrud(seedData).Wait();
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
