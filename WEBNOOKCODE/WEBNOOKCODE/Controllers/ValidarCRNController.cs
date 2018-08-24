using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Http;
using WEBNOOKCODE.Models;

namespace WEBNOOKCODE.Controllers
{
    public class ValidarCRNController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Json("VAZIO");
        }

        // GET api/values/5
        public IHttpActionResult Get(string estado, string CRN)
        {
            string body = string.Empty;
            string url = string.Format("https://www.consultacrm.com.br/api/index.php?tipo=crm&uf={0}&q={1}&chave=7658691226&destino=json", estado,CRN);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Accept = "application/json";
            request.ContentType = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                body = reader.ReadToEnd();
            }
            if (body != null)
            {
                var retornoWS = JsonConvert.DeserializeObject<CRNWSRetorno>(body);
                return Json(retornoWS.item);
            }
            else
            {
                return null;
            }
            
        }

        // POST api/values
        public string Post()
        {
            return "VAZIO";
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