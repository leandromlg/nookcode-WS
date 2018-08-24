using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBNOOKCODE.Models
{
    public class CRNWSRetorno
    {
        public string url { get; set; }
        public int total { get; set; }
        public string status { get; set; }
        public string mensagem { get; set; }
        public string api_limite { get; set; }
        public string api_consultas { get; set; }
        public List<Item> item { get; set; }
    }
}