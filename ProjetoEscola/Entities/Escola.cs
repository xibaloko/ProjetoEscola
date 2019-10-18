﻿using System;
using System.Collections.Generic;

namespace ProjetoEscola.Entities
{
    class Escola
    {
        public List<Turma> Turmas { get; set; } = new List<Turma>();
        public List<Professor> Professores { get; set; } = new List<Professor>();
        public List<Aluno> Alunos { get; set; } = new List<Aluno>();

        public void CadastrarTurmas() // CADASTRA UMA SEQUENCIA DE TURMAS
        {
            int numeroTurma;
            Console.Write("\nDIGITE A QUANTIDADE DE TURMAS QUE SERÃO CADASTRADAS: ");
            int n = Validacao.ValidarNumeros(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.Write($"\nDIGITE O NÚMERO DA {i}ª TURMA OU [0] PARA VOLTAR: ");
                numeroTurma = Validacao.ValidarMenuInicial(Console.ReadLine());

                if (Turmas.Exists(x => x.NumeroTurma == numeroTurma))
                {
                    Console.WriteLine("\nIMPOSSIVEL CADASTRAR UMA TURMA, JÁ EXISTE UMA TURMA COM ESSE NÚMERO!");
                    return;
                }
                else if (numeroTurma != 0)
                {
                    Turma turma = new Turma(numeroTurma);
                    Turmas.Add(turma);
                    Console.Write("\nTURMA CADASTRADA!\n");
                }
                else
                    return;
            }

        }
        public void CadastrarProfessor() // CADASTRA UM ÚNICO PROFESSOR
        {
            Professor professor = new Professor();
            string s;
            int n;

            Console.Write("\nDIGITE O NOME DO PROFESSOR(A): ");
            s = Validacao.ValidarLetrasSemEspaco(Console.ReadLine());
            professor.Nome = s;

            Console.Write($"\nDIGITE O SOBRENOME DO PROFº {professor.Nome.ToUpper()}: ");
            s = Validacao.ValidarLetrasComEspaco(Console.ReadLine());
            professor.Sobrenome = s;

            Console.Write($"\nDIGITE O SEXO DO(A) PROFº {professor.Nome.ToUpper()} [M/F]: ");
            s = Validacao.ValidarSexo(Console.ReadLine().ToUpper());
            professor.Sexo = s;

            Console.Write($"\nDIGITE A IDADE DO(A) PROFº {professor.Nome.ToUpper()}: ");
            n = Validacao.ValidarNumeros(Console.ReadLine());
            professor.Idade = n;

            Professores.Add(professor);
            Console.Write("\nPROFESSOR CADASTRADO!\n");
        }
        public void CadastrarAluno() // CADASTRA UM UNICO ALUNO
        {
            Aluno aluno = new Aluno();
            string s;
            int n;

            Console.Write("\nDIGITE O PRIMEIRO NOME DO ALUNO(A): ");
            s = Validacao.ValidarLetrasSemEspaco(Console.ReadLine());
            aluno.Nome = s;

            Console.Write($"\nDIGITE O SOBRENOME DO {aluno.Nome.ToUpper()}: ");
            s = Validacao.ValidarLetrasComEspaco(Console.ReadLine());
            aluno.Sobrenome = s;

            Console.Write($"\nDIGITE O SEXO DO(A) {aluno.Nome.ToUpper()}: ");
            s = Validacao.ValidarSexo(Console.ReadLine().ToUpper());
            aluno.Sexo = s;

            Console.Write($"\nDIGITE A IDADE DO(A): {aluno.Nome.ToUpper()}: ");
            n = Validacao.ValidarNumeros(Console.ReadLine());
            aluno.Idade = n;

            Console.Write($"\nO ALUNO(A) {aluno.Nome.ToUpper()} É BOLSISTA? (S/N): ");
            s = Validacao.ValidarSimOuNao(Console.ReadLine().ToUpper());

            if (s != "S")
                aluno.Bolsista = false;
            else
                aluno.Bolsista = true;

            Alunos.Add(aluno);
            Console.Write("\nALUNO CADASTRADO!\n");
        }
        public void ListarTurmas(List<Turma> turmas) // APRESENTA AS TURMAS EXISTENTES
        {
            Console.Write($"\nHÁ {turmas.Count} TURMA(S) CADASTRADA(S)!\n");

            foreach (Turma s in turmas)
                Console.Write($"\n{turmas.IndexOf(s) + 1} - {s}");
            Console.WriteLine();
        }
        public void ListarProfessores(List<Professor> professores) // APRESENTA OS PROFESSORES EXISTENTES
        {
            Console.Write($"\nHÁ {professores.Count} PROFESSOR(ES) CADASTRADO(S)!\n");

            foreach (Professor s in professores)
                Console.Write($"\n{professores.IndexOf(s) + 1} - {s}");
            Console.WriteLine();
        }
        public void ListarAlunos(List<Aluno> alunos) // APRESENTA OS ALUNOS EXISTENTES
        {
            Console.Write($"\nHÁ {alunos.Count} ALUNO(S) CADASTRADO(S)!\n");

            foreach (Aluno s in alunos)
                Console.Write($"\n{alunos.IndexOf(s) + 1} - {s}");
            Console.WriteLine();
        }
    }
}