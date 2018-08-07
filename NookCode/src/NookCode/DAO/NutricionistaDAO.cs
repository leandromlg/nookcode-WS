using MongoDB.Bson;
using MongoDB.Driver;
using NookCode.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NookCode.DAO
{
    public class NutricionistaDAO
    {
        public async Task<string> CadastrarNutricionista(Nutricionista nutri)
        {
            try
            {
                BsonDocument NewNutricionista = new BsonDocument {
                 { "Nome" , nutri.Nome },
                 { "CPF" , nutri.CPF },
                 { "CRN" , nutri.CRN },
                 { "Endereco" , nutri.Endereco },
                 { "Telefone" , nutri.Telefone },
                 { "Celular" , nutri.Celular },
                 { "Email" , nutri.Email },
                 { "Senha" , nutri.Senha },
                 { "Instagram" , nutri.Instagram },
                 { "Facebook" , nutri.Facebook },
                 { "Twitter" , nutri.Twitter }
             };

                BsonDocument[] seedData = { NewNutricionista };
                BsonDocument[] Data = seedData;
                String uri = "mongodb://nookcodeadm:St*+8802@ds115472.mlab.com:15472/nookcode";

                var client = new MongoClient(uri);
                var db = client.GetDatabase("nookcode");

                var MongoDBnutricionistas = db.GetCollection<BsonDocument>("nutricionistas");
                await MongoDBnutricionistas.InsertManyAsync(Data);

                return "true";
            }
            catch (Exception)
            {
                return "false";           
            }
        }

        public List<BsonDocument> GetNutricionista()
        {
            try
            {

                String uri = "mongodb://nookcodeadm:St*+8802@ds115472.mlab.com:15472/nookcode";

                var client = new MongoClient(uri);
                var db = client.GetDatabase("nookcode");

                var filter = Builders<BsonDocument>.Filter.Gte("Nome", 10);
                var sort = Builders<BsonDocument>.Sort.Ascending("CRN");

                List<Nutricionista> lista = new List<Nutricionista>();

                var MongoDBnutricionistas = db.GetCollection<BsonDocument>("nutricionistas");

                var list = MongoDBnutricionistas.Find(new BsonDocument()).ToList();
                // await MongoDBnutricionistas.Find(filter).Sort(sort).ForEachAsync(song => lista.Add(new Nutricionista(song["Nome"].ToString(), song["CPF"].ToString(), song["CRN"].ToString())));

                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
