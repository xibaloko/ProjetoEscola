using System;
using System.Text;
using System.Collections.Generic;

namespace ProjetoEscola.Entities
{
    class Turma
    {
        public int NumeroTurma { get; set; }
        public DateTime DataDeAbertura { get; set; }
        public Coordenador Coordenador { get; set; }
        public Professor Professor { get; set; }
        public List<Aluno> Alunos { get; set; } = new List<Aluno>();

        public Turma(int numeroturma)
        {
            NumeroTurma = numeroturma;
            DataDeAbertura = DateTime.Now;
        }
        public void AdicionarCoordenador(Coordenador coordenador)
        {
            Coordenador = coordenador;
        }
        public void RemoverCoordenador()
        {
            Coordenador = null;
        }
        public void AdicionarProfessor(Professor professor) // ADICIONA UM OBJETO PROFESSOR A LISTA DE PROFESSORES
        {
            Professor = professor;
        }
        public void RemoverProfessor()
        {
            Professor = null;
        }
        public void AdicionarAluno(Aluno aluno) // ADICIONA UM OBJETO ALUNO A LISTA DE ALUNOS
        {
            Alunos.Add(aluno);
        }
        public void RemoverAluno(Aluno aluno) // REMOVE UM OBJETO ALUNO DA LISTA DE ALUNOS
        {
            Alunos.Remove(aluno);
        }
        public override string ToString() // IMPRIME O OBJETO TURMA
        {
            StringBuilder printTurma = new StringBuilder();
            printTurma.AppendLine("-----------------------------------------------------------------------------");
            printTurma.AppendLine($"TURMA - {NumeroTurma.ToString().ToUpper()} // DATA DE ABERTURA - {DataDeAbertura}");
            printTurma.AppendLine(Coordenador == null ? "TURMA AINDA NÃO POSSUI COORDENADOR" : $"COORDENADOR: {Coordenador}");
            printTurma.AppendLine(Professor == null ? "TURMA AINDA NÃO POSSUI PROFESSOR" : $"PROFESSOR: {Professor}");
            if (Alunos.Count == 0)
            {
                printTurma.AppendLine("TURMA AINDA NÃO POSSUI ALUNOS");
            }
            else
                Alunos.ForEach(x => printTurma.AppendLine(x.ToString()));
            printTurma.AppendLine("-----------------------------------------------------------------------------");
            return printTurma.ToString();
        }
    }
}
