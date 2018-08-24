using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBNOOKCODE.Models
{
    public class Nutricionista : RetornoWS
    {
        public string id { get; set; }
        public string nome { get; set; }
        public string CPF { get; set; }
        public string CRN { get; set; }
        public string endereco { get; set; }
        public string telefone { get; set; }
        public string celular { get; set; }
        public string email { get; set; }
        public string facebook { get; set; }
        public string instagram { get; set; }
        public string twitter { get; set; }
        public string senha { get; set; }
        public string foto { get; set; }

        public Nutricionista()
        {

        }

    }
}