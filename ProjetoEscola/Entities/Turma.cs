using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
namespace ProjetoEscola.Entities
{
    class Turma
    {
        public int NumeroTurma { get; set; }
        public int CapacidadeTurma { get; set; }
        public DateTime DataDeAbertura { get; set; }
        public Coordenador Coordenador { get; set; }
        public Professor Professor { get; set; }
        public List<Aluno> Alunos { get; set; } = new List<Aluno>();

        public Turma(int numeroturma, int capacidadeturma)
        {
            NumeroTurma = numeroturma;
            DataDeAbertura = DateTime.Now;
            CapacidadeTurma = capacidadeturma;
        }
        public void AdicionarCoordenador(Coordenador coordenador, Turma turma) // ADICIONA O COORDENADOR TURMA E A TURMA A LISTA DE TURMAS DO COORDENADOR 
        {
            Coordenador = coordenador;
            coordenador.Turmas.Add(turma);
        }
        public void RemoverCoordenador(Turma turma) // CASO TENHA UM COORDENADOR ATRIBUIDO, PERGUNTA SE QUER REMOVE-LO
        {
            if (turma.Coordenador != null)
            {
                Console.Write($"\nDESEJA REMOVER O COORDENADOR {Coordenador.Nome.ToUpper()} DA TURMA {turma.NumeroTurma} (S/N): ");
                string s = Validacao.ValidarSimOuNao(Console.ReadLine().ToUpper());
                if (s == "S")
                {
                    Coordenador.Turmas.Remove(turma);
                    Coordenador = null;
                    Console.WriteLine("\nCOORDENADOR REMOVIDO COM SUCESSO!");
                }
            }
            else
                Console.WriteLine("\nNÃO HÁ NENHUM COORDENADOR NESTA TURMA!");
        }
        public void AdicionarProfessor(Escola escola, Professor professor, int registro) // ADICIONA UM PROFESSOR A TURMA REMOVENDO DA LISTA CASO ELE JA ESTEJA EM OUTRA TURMA TAMBÉM
        {
            int contagem = 0;

            foreach (Turma turma in escola.Turmas)
            {
                if (turma.Professor != null && turma.Professor.Registro.Equals(registro))
                    contagem += 1;
            }
            if (contagem >= 1)
            {
                Professor = professor;
                escola.Professores.Remove(professor);
            }
            else
            {
                Professor = professor;
            }
        }
        public void RemoverProfessor(Escola escola, Turma turma) // REMOVE O PROFESSOR DA TURMA E O REALOCA NA LISTA DE PROFESSORES
        {
            if (turma.Professor != null)
            {
                Console.Write($"\nDESEJA REMOVER O PROFESSOR(A) {Professor.Nome.ToUpper()} DA TURMA {turma.NumeroTurma} (S/N): ");
                string s = Validacao.ValidarSimOuNao(Console.ReadLine().ToUpper());
                if (s == "S")
                {
                    bool professor = escola.Professores.Exists(x => x.Registro == Professor.Registro);
                    if (professor)
                    {
                        Professor = null;
                        Console.WriteLine("\nPROFESSOR REMOVIDO COM SUCESSO!");
                    }
                    else
                    {
                        escola.Professores.Add(Professor);
                        Professor = null;
                        Console.WriteLine("\nPROFESSOR REMOVIDO E REALOCADO PARA LISTA DE PROFESSORES DISPONÍVEIS");
                    }
                }
            }
            else
                Console.WriteLine("NÃO HÁ NENHUM PROFESSOR NESTA TURMA!");
        }
        public void AdicionarAluno(Aluno aluno) // ADICIONA UM ALUNO A LISTA DE ALUNOS
        {
            if (Alunos.Count < CapacidadeTurma)
            {
                Alunos.Add(aluno);
                Console.Write("\nALUNO(A) ATRIBUÍDO COM SUCESSO!\n");
            }
            else
                Console.Write("\nLIMITE DA TURMA ATINGIDO!\n");
        }
        public void RemoverAluno(Escola escola, Turma turma) // REMOVE UM ALUNO DA TURMA E O REALOCA A LISTA DE ALUNOS DA ESCOLA
        {
            if (turma.Alunos.Count > 0)
            {
                Console.Write("\nDIGITE A MATRÍCULA DO ALUNO(A) QUE DESEJA REMOVER DA TURMA: ");
                int n = Validacao.ValidarNumeros(Console.ReadLine());
                Aluno aluno = turma.Alunos.Where(x => x.Matricula == n).FirstOrDefault();
                if(aluno != null)
                {
                    escola.Alunos.Add(aluno);
                    turma.Alunos.Remove(aluno);
                    Console.Write("\nO ALUNO(A) FOI REMOVIDO DA TURMA E REALOCADO NA LISTA DE ALUNOS DA ESCOLA!");
                }
                else Console.Write("\nALUNO NÃO ENCONTRADO!");
            }
            else
                Console.Write("\nNÃO HÁ NENHUM ALUNO(A) CADASTRADO NA TURMA!");
        }
        public override string ToString() // IMPRIME A TURMA E SEUS RELACIONADOS
        {
            StringBuilder printTurma = new StringBuilder();
            printTurma.AppendLine("-----------------------------------------------------------------------------");
            printTurma.AppendLine($"TURMA - {NumeroTurma.ToString().ToUpper()} // DATA DE ABERTURA - {DataDeAbertura}");
            printTurma.AppendLine(Coordenador == null ? "TURMA AINDA NÃO POSSUI COORDENADOR" : $"COORDENADOR - {Coordenador.Nome.ToUpper()}");
            printTurma.AppendLine(Professor == null ? "TURMA AINDA NÃO POSSUI PROFESSOR" : $"PROFESSOR - {Professor}");
            if (Alunos.Count == 0) 
                printTurma.AppendLine("TURMA AINDA NÃO POSSUI ALUNOS");
            else
            {
                printTurma.AppendLine("-- ALUNOS DA TURMA --");
                Alunos.ForEach(x => printTurma.AppendLine($"ALUNO - {x.ToString()}"));
            }
            printTurma.AppendLine("-----------------------------------------------------------------------------");
            return printTurma.ToString();
        }
    }
}
