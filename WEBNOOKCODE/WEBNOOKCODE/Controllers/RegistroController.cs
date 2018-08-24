using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WEBNOOKCODE.DAO;
using WEBNOOKCODE.Models;

namespace WEBNOOKCODE.Controllers
{
    public class RegistroController : ApiController
    {
        // GET api/values
        public IHttpActionResult Get()
        {
            NutricionistaDAO nDAO = new NutricionistaDAO();
            var resultado = nDAO.GetNutricionista();
            List<Nutricionista> nutriList = new List<Nutricionista>();

            foreach (var item in resultado)
            {
                var teste = item.ToString().Replace("_", "");
                teste = teste.Replace("ObjectId(", "");
                teste = teste.Replace(")", "");
                var teste2 = item.Values;
                nutriList.Add(JsonConvert.DeserializeObject<Nutricionista>(teste));
            }
            return Json(nutriList);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public string Post([FromBody]Nutricionista nutri)
        {
            try
            {
                NutricionistaDAO nDAO = new NutricionistaDAO();
                var resultado = nDAO.RegistroLogin(nutri);

                return resultado;
            }
            catch (Exception)
            {
                return "Erro";
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

    }
}