using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using NookCode.Model;
using NookCode.DAO;
using Newtonsoft.Json;

namespace NookCode.Controllers
{
    [Route("api/[controller]")]
    public class NutricionistaController : Controller
    {
        [HttpGet]
        public string Get()
        {
            NutricionistaDAO nDAO = new NutricionistaDAO();
            var resultado = nDAO.GetNutricionista();
            List<Nutricionista> nutriList = new List<Nutricionista>();

            foreach (var item in resultado)
            {
                var teste = item.ToString().Replace("_","");
                teste = teste.Replace("ObjectId(", "");
                teste = teste.Replace(")", "");
                var teste2 = item.Values;
                nutriList.Add(JsonConvert.DeserializeObject<Nutricionista>(teste));
            }


            return JsonConvert.SerializeObject(nutriList);
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]Nutricionista nutri)
        {
            try
            {
                NutricionistaDAO nDAO = new NutricionistaDAO();
                var resultado = nDAO.CadastrarNutricionista(nutri);
                return "Gravado com sucesso!";
            }
            catch (Exception)
            {
                return "Erro";
            }
           
        }

    }
}
