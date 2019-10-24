using System;
namespace ProjetoEscola.Entities
{
    class Aluno : Pessoa
    {
        public int Matricula { get; set; } = new Random().Next(1000, 9999);
        public bool Bolsista { get; set; }

        public override string ToString() => // IMPRIME AS INFORMAÇÕES ESPECIFICAS DE UM ALUNO
            $"MATRICULA: {Matricula} " +
            $"NOME: {Nome.ToUpper()} {Sobrenome.ToUpper()} " +
            $"BOLSISTA: {(Bolsista ? "SIM" : "NÃO")} " +
            $"SEXO: {Sexo} " +
            $"IDADE: {Idade}";
    }
}
