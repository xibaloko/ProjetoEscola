using System;
using System.Collections.Generic;

namespace ProjetoEscola.Entities
{
    class Turma
    {
        public int NumeroTurma { get; set; }
        public DateTime DataDeAbertura { get; set; }
        public Professor Professor { get; set; }
        public List<Aluno> Alunos { get; set; } = new List<Aluno>();

        public Turma(int numeroturma)
        {
            NumeroTurma = numeroturma;
            DataDeAbertura = DateTime.Now;
        }
        public void AdicionarProfessor(Professor professor) // ADICIONA UM OBJETO PROFESSOR A LISTA DE PROFESSORES
        {
            Professor = professor;
        }
        public void AdicionarAluno(Aluno aluno) // ADICIONA UM OBJETO ALUNO A LISTA DE ALUNOS
        {
            Alunos.Add(aluno);
        }
        public void RemoverAluno(Aluno aluno) // REMOVE UM OBJETO ALUNO DA LISTA DE ALUNOS
        {
            Alunos.Remove(aluno);
        }
        public void ListarRelacionados() // EXIBI OS RELACIONADOS A TURMA
        {
            Console.WriteLine($"NUMERO TURMA: {NumeroTurma}\n" +
                $"DATA DE ABERTURA: {DataDeAbertura}\n" +
                $"PROFESSOR - {Professor}");

            foreach (Aluno aluno in Alunos)
                Console.WriteLine($"ALUNO - {aluno}");
        }
        public override string ToString() => $"TURMA: {NumeroTurma} - DATA DE ABERTURA: {DataDeAbertura}"; // IMPRIME O OBJETO TURMA
    }
}
