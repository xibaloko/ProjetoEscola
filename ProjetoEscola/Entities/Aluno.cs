using System;

namespace ProjetoEscola.Entities
{
    class Aluno : Pessoa
    {
        public int Matricula { get; set; } = new Random().Next(1, 99999);
        public bool Bolsista { get; set; }

        public override string ToString() =>
            $"NOME: {Nome.ToUpper()} {Sobrenome.ToUpper()} " +
            $"MATRICULA: {Matricula} " +
            $"BOLSISTA: {(Bolsista ? "SIM" : "NÃO")} " +
            $"SEXO: {Sexo} " +
            $"IDADE: {Idade}";
    }
}
