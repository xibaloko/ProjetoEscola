using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoEscola.Entities
{
    class Coordenador : Pessoa
    {
        public int Registro { get; set; } = new Random().Next(1, 99999);

        public override string ToString() =>
            $"NOME: {Nome.ToUpper()} {Sobrenome.ToUpper()} " +
            $"REGISTRO: {Registro} " +
            $"SEXO: {Sexo.ToUpper()} " +
            $"IDADE: {Idade}";
    }
}
