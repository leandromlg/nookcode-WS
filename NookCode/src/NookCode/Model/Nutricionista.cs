using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NookCode.Model
{
    public class Nutricionista
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string CRN { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string Senha { get; set; }
        public string Foto { get; set; }

        public Nutricionista()
        {

        }

        public Nutricionista(string nome, string cpf, string crn)
        {
            this.Nome = nome;
            this.CPF = cpf;
            this.CRN = crn;
        }
    }
}
