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
    public class LoginController : ApiController
    {
        // POST api/values
        public IHttpActionResult Post([FromBody]Nutricionista nutri)
        {
            try
            {
                nutri.codigo = "99";
                nutri.mensagem = "Erro não tratado";
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

                foreach (var item in nutriList)
                {
                    if (item.email == nutri.email)
                    {
                        var senha = MD5.GetSenhaMD5(item.senha);
                        if (senha == nutri.senha)
                        {
                            nutri.celular = item.celular;
                            nutri.CPF = item.CPF;
                            nutri.CRN = item.CRN;
                            nutri.endereco = item.endereco;
                            nutri.facebook = item.facebook;
                            nutri.foto = item.foto;
                            nutri.id = item.id;
                            nutri.instagram = item.instagram;
                            nutri.nome = item.nome;
                            nutri.telefone = item.telefone;
                            nutri.twitter = item.twitter;

                            nutri.codigo = "00";
                            nutri.mensagem = "Sucesso";
                        }
                        else
                        {
                            nutri.codigo = "03";
                            nutri.mensagem = "Senha invalida";
                        }
                    }
                    else
                    {
                        if (nutri.codigo == "99")
                        {
                            nutri.codigo = "04";
                            nutri.mensagem = "Email não cadastrado";
                        }
                    }
                }
                return Json(nutri);
            }
            catch (Exception)
            {
                Nutricionista retorno = new Nutricionista();
                retorno.codigo = "99";
                retorno.mensagem = "Erro não tratado";
                return Json(retorno);
            }
        }
    }
}