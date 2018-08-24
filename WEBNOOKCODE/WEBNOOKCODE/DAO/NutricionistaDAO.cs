using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WEBNOOKCODE.Models;

namespace WEBNOOKCODE.DAO
{
    public class NutricionistaDAO
    {
        public async Task<string> CadastrarNutricionista(Nutricionista nutri)
        {
            var resultado = GetNutricionista();
            bool cadastrado = false;
            List<Nutricionista> nutriList = new List<Nutricionista>();
            BsonDocument NewNutricionista = new BsonDocument {
                 { "Nome" , nutri.nome },
                 { "CPF" , nutri.CPF },
                 { "CRN" , nutri.CRN },
                 { "Endereco" , nutri.endereco },
                 { "Telefone" , nutri.telefone },
                 { "Celular" , nutri.celular },
                 { "Email" , nutri.email },
                 { "Senha" , nutri.senha },
                 { "Instagram" , nutri.instagram },
                 { "Facebook" , nutri.facebook },
                 { "Twitter" , nutri.twitter }
             };

            BsonDocument[] seedData = { NewNutricionista };
            BsonDocument[] Data = seedData;
            String uri = "mongodb://nookcodeadm:St*+8802@ds115472.mlab.com:15472/nookcode";

            var client = new MongoClient(uri);
            var db = client.GetDatabase("nookcode");

            var MongoDBnutricionistas = db.GetCollection<BsonDocument>("nutricionistas");

            foreach (var item in resultado)
            {
                var teste = item.ToString().Replace("_", "");
                teste = teste.Replace("ObjectId(", "");
                teste = teste.Replace(")", "");
                var teste2 = item.Values;
                nutriList.Add(JsonConvert.DeserializeObject<Nutricionista>(teste));
            }

            foreach (var item in nutriList)
            {
                if (item.email == nutri.email)
                {
                    cadastrado = true;
                }
            }

            if (cadastrado)
            {
                try
                {
                    var updateFilter = Builders<BsonDocument>.Filter.Eq("Email", nutri.email);

                    var update = Builders<BsonDocument>.Update.Set("Nome", nutri.nome);
                    MongoDBnutricionistas.UpdateOne(updateFilter, update);
                    var update2 = Builders<BsonDocument>.Update.Set("CPF", nutri.CPF);
                    MongoDBnutricionistas.UpdateOne(updateFilter, update2);
                    var update3 = Builders<BsonDocument>.Update.Set("CRN", nutri.CRN);
                    MongoDBnutricionistas.UpdateOne(updateFilter, update3);
                    var update4 = Builders<BsonDocument>.Update.Set("Endereco", nutri.endereco);
                    MongoDBnutricionistas.UpdateOne(updateFilter, update4);
                    var update5 = Builders<BsonDocument>.Update.Set("Telefone", nutri.telefone);
                    MongoDBnutricionistas.UpdateOne(updateFilter, update5);
                    var update6 = Builders<BsonDocument>.Update.Set("Celular", nutri.celular);
                    MongoDBnutricionistas.UpdateOne(updateFilter, update6);
                    var update7 = Builders<BsonDocument>.Update.Set("Instagram", nutri.instagram);
                    MongoDBnutricionistas.UpdateOne(updateFilter, update7);
                    var update8 = Builders<BsonDocument>.Update.Set("Facebook", nutri.facebook);
                    MongoDBnutricionistas.UpdateOne(updateFilter, update8);
                    var update9 = Builders<BsonDocument>.Update.Set("Twitter", nutri.twitter);
                    MongoDBnutricionistas.UpdateOne(updateFilter, update9);

                    return "true";
                }
                catch (Exception)
                {
                    return "false";
                }
            }
            else
            {
                try
                { 
                    await MongoDBnutricionistas.InsertManyAsync(Data);

                    return "true";
                }
                catch (Exception)
                {
                    return "false";
                }
            }

          
        }

        public string RegistroLogin(Nutricionista nutri)
        {      
            try
            {
                BsonDocument NewNutricionista = new BsonDocument {
                 { "Nome" , nutri.nome },
                 { "CPF" , "" },
                 { "CRN" , "" },
                 { "Endereco" , "" },
                 { "Telefone" , "" },
                 { "Celular" , nutri.celular },
                 { "Email" , nutri.email },
                 { "Senha" , nutri.senha },
                 { "Instagram" , "" },
                 { "Facebook" , "" },
                 { "Twitter" , "" }
             };

                BsonDocument[] seedData = { NewNutricionista };
                BsonDocument[] Data = seedData;
                String uri = "mongodb://nookcodeadm:St*+8802@ds115472.mlab.com:15472/nookcode";
                var cadastrado = false;
                var client = new MongoClient(uri);
                var db = client.GetDatabase("nookcode");
                List<Nutricionista> nutriList = new List<Nutricionista>();
                var MongoDBnutricionistas = db.GetCollection<BsonDocument>("nutricionistas");

                var resultado = GetNutricionista();

                foreach (var item in resultado)
                {
                    var teste = item.ToString().Replace("_", "");
                    teste = teste.Replace("ObjectId(", "");
                    teste = teste.Replace(")", "");
                    var teste2 = item.Values;
                    nutriList.Add(JsonConvert.DeserializeObject<Nutricionista>(teste));
                }

                foreach (var item in nutriList)
                {
                    if (item.email == nutri.email)
                    {
                        cadastrado = true;
                    }
                }

                if (cadastrado)
                {
                    return "Email já cadastrado!";
                }

                MongoDBnutricionistas.InsertMany(Data);

                return "Cadastrado com sucesso!";
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

                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}