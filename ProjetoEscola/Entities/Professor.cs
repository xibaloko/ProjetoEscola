using System;
namespace ProjetoEscola.Entities
{
    class Professor : Pessoa
    {
        public int Registro { get; set; } = new Random().Next(1000, 9999);
        public Coordenador Coordenador { get; set; }

        public override string ToString() => // IMPRIME AS INFORMAÇÕES ESPECIFICAS DE UM PROFESSOR
            $"REGISTRO: {Registro} " +
            $"NOME: {Nome.ToUpper()} {Sobrenome.ToUpper()} " +
            $"SEXO: {Sexo.ToUpper()} " +
            $"IDADE: {Idade} " +
            $"COORDENADOR RESPONSÁVEL: {Coordenador.Nome.ToUpper()}";
    }
}
