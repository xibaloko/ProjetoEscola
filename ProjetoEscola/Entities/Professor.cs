using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoEscola.Entities
{
    class Professor : Pessoa
    {
        public int Registro { get; set; }

        public Professor()
        {
            Random random = new Random();
            Registro = random.Next(1, 99999);
        }
        public override string ToString() => 
            $"NOME: {Nome.ToUpper()} {Sobrenome.ToUpper()} " +
            $"REGISTRO: {Registro} " +
            $"SEXO: {Sexo.ToUpper()} " +
            $"IDADE: {Idade}";
    }
}
