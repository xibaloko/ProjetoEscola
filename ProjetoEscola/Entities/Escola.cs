using System;
using System.Collections.Generic;
using System.Linq;
namespace ProjetoEscola.Entities
{
    class Escola
    {
        public List<Turma> Turmas { get; set; } = new List<Turma>();
        public List<Coordenador> Coordenadores { get; set; } = new List<Coordenador>();
        public List<Professor> Professores { get; set; } = new List<Professor>();
        public List<Aluno> Alunos { get; set; } = new List<Aluno>();

        public void CadastrarTurmas() // CADASTRA UMA SEQUENCIA DE TURMAS
        {
            int numeroTurma, capacidadeTurma;

            Console.Write("\nDIGITE A QUANTIDADE DE TURMAS QUE SERÃO CADASTRADAS: ");
            int n = Validacao.ValidarNumeros(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.Write($"\nDIGITE O NÚMERO DA {i}ª TURMA OU [0] PARA VOLTAR: ");
                numeroTurma = Validacao.ValidarMenu(Console.ReadLine());

                if (Turmas.Exists(x => x.NumeroTurma == numeroTurma)) // CASO JÁ TENHA UMA TURMA COM O NÚMERO INFORMADO, IMPEDE O CADASTRO
                {
                    Console.WriteLine("\nIMPOSSIVEL CADASTRAR UMA TURMA, JÁ EXISTE UMA TURMA COM ESSE NÚMERO!");
                    return;
                }
                else if (numeroTurma != 0)
                {
                    Console.Write("\nDIGITE A CAPACIDADE MÁXIMA DE ALUNOS PARA ESSA TURMA: ");
                    capacidadeTurma = Validacao.ValidarNumeros(Console.ReadLine());

                    Turma turma = new Turma(numeroTurma, capacidadeTurma);
                    Turmas.Add(turma);
                    Console.Write("\nTURMA CADASTRADA!\n");
                }
                else return; // SE NENHUMA DAS CONDIÇÕES ACIMA FOREM ATENDIDAS O VALOR É ZERO, ENTÃO RETORNA PARA O MENU CADASTRAR
            }
        }
        public void CadastrarCoordenador() // CADASTRA UM COORDENADOR
        {
            Coordenador coordenador = new Coordenador();
            string s;
            string[] vet;
            int n;

            Console.Write("\nDIGITE O NOME COMPLETO DO COORDENADOR: ");
            s = Validacao.ValidarLetras(Console.ReadLine().TrimStart().TrimEnd());
            vet = s.Split(' ');
            coordenador.Nome = vet[0];
            for (int i = 1; i < vet.Length; i++) // PREENCHE O SOBRENOME PULANDO O PRIMEIRO ÍNDICE DO VETOR(NOME)
                coordenador.Sobrenome += vet[i] + " ";

            Console.Write($"\nDIGITE O SEXO DO(A) {coordenador.Nome.ToUpper()} [M/F]: ");
            s = Validacao.ValidarSexo(Console.ReadLine().ToUpper());
            coordenador.Sexo = s;

            Console.Write($"\nDIGITE A IDADE DO(A) {coordenador.Nome.ToUpper()}: ");
            n = Validacao.ValidadeMaioridade(Console.ReadLine());
            coordenador.Idade = n;

            Coordenadores.Add(coordenador);
            Console.Write("\nCOORDENADOR CADASTRADO!\n");
        }
        public void CadastrarProfessor(Escola escola) // CADASTRA UM PROFESSOR
        {
            Professor professor = new Professor();
            string s;
            string[] vet;
            int n;

            if (escola.Coordenadores.Count > 0) // CADEIA DE CONDIÇÕES PARA VERIFICAR A EXISTENCIA DE UM COORDENADOR E ATRIBUI-LO A UM PROFESSOR
            {
                escola.ListarCoordenadores(escola.Coordenadores);
                Console.Write($"\nDIGITE O REGISTRO DO(A) COORDENADOR RESPONSÁVEL POR ESSE PROFESSOR: ");
                n = Validacao.ValidarNumeros(Console.ReadLine());
                Coordenador coordenador = escola.Coordenadores.Find(x => x.Registro == n);
                if (coordenador != null)
                {
                    coordenador.Professores.Add(professor);
                    professor.Coordenador = coordenador;
                }
                else
                {
                    Console.WriteLine($"\nNÃO HÁ NENHUM COORDENADOR COM O REGISTRO: {n}");
                    return;
                }
            }
            else
            {
                Console.WriteLine("\nIMPOSSÍVEL CADASTRAR PROFESSOR, NÃO HÁ NENHUM COORDENADOR CADASTRADO!");
                return;
            }

            Console.Write("\nDIGITE O NOME COMPLETO DO PROFESSOR: ");
            s = Validacao.ValidarLetras(Console.ReadLine().TrimStart().TrimEnd());
            vet = s.Split(' ');
            professor.Nome = vet[0];
            for (int i = 1; i < vet.Length; i++)
                professor.Sobrenome += vet[i] + " ";
            
            Console.Write($"\nDIGITE O SEXO DO(A) PROFº {professor.Nome.ToUpper()} [M/F]: ");
            s = Validacao.ValidarSexo(Console.ReadLine().ToUpper());
            professor.Sexo = s;

            Console.Write($"\nDIGITE A IDADE DO(A) PROFº {professor.Nome.ToUpper()}: ");
            n = Validacao.ValidadeMaioridade(Console.ReadLine());
            professor.Idade = n;

            Professores.Add(professor);
            Console.Write("\nPROFESSOR CADASTRADO!\n");
        }
        public void CadastrarAluno() // CADASTRA UM ALUNO
        {
            Aluno aluno = new Aluno();
            string s;
            string[] vet;
            int n;

            Console.Write("\nDIGITE O NOME COMPLETO DO ALUNO: ");
            s = Validacao.ValidarLetras(Console.ReadLine().TrimStart().TrimEnd());
            vet = s.Split(' ');
            aluno.Nome = vet[0];
            for (int i = 1; i < vet.Length; i++)
                aluno.Sobrenome += vet[i] + " ";

            Console.Write($"\nDIGITE O SEXO DO(A) {aluno.Nome.ToUpper()} [M/F]: ");
            s = Validacao.ValidarSexo(Console.ReadLine().ToUpper());
            aluno.Sexo = s;

            Console.Write($"\nDIGITE A IDADE DO(A) {aluno.Nome.ToUpper()}: ");
            n = Validacao.ValidadeMaioridade(Console.ReadLine());
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
        public void AtribuirCoordenador(Escola escola) // ATRIBUI UM COORDENADOR A UMA TURMA ESPECIFICA DA ESCOLA
        {
            Console.Write("\nDIGITE O REGISTRO DO COORDENADOR QUE DESEJA INSERIR NA TURMA: ");
            int n = Validacao.ValidarNumeros(Console.ReadLine());

            Coordenador coordenador = escola.Coordenadores.Where(x => x.Registro == n).FirstOrDefault();
            if (coordenador != null)
            {
                escola.ListarTurmas(escola.Turmas);
                Console.Write("\nDIGITE O NÚMERO DA TURMA QUE DESEJA INSERIR O COORDENADOR(A): ");
                n = Validacao.ValidarNumeros(Console.ReadLine());
                Turma turma = escola.Turmas.Where(x => x.NumeroTurma == n).FirstOrDefault();
                if (turma != null)
                {
                    turma.AdicionarCoordenador(coordenador, turma);
                    Console.Write("\nCOORDENADOR(A) ATRIBUÍDO COM SUCESSO!\n");
                }
                else
                    Console.Write("\nTURMA NÃO ENCONTRADA!\n");
            }
            else
                Console.Write("\nCOORDENADOR NÃO ENCONTRADO!\n");
        }
        public void AtribuirProfessor(Escola escola) // ATRIBUI UM PROFESSOR A UMA TURMA ESPECIFICA DA ESCOLA
        {
            Console.Write("\nDIGITE O REGISTRO DO PROFESSOR QUE DESEJA INSERIR NA TURMA: ");
            int registroProfessor = Validacao.ValidarNumeros(Console.ReadLine());

            Professor professor = escola.Professores.Where(x => x.Registro == registroProfessor).FirstOrDefault();
            if (professor != null)
            {
                escola.ListarTurmas(escola.Turmas);
                Console.Write("\nDIGITE O NÚMERO DA TURMA QUE DESEJA INSERIR O PROFESSOR(A): ");
                int numeroTurma = Validacao.ValidarNumeros(Console.ReadLine());
                Turma turma = escola.Turmas.Where(x => x.NumeroTurma == numeroTurma).FirstOrDefault();
                if (turma != null)
                {
                    turma.AdicionarProfessor(escola, professor, registroProfessor);
                    Console.Write("\nPROFESSOR(A) ATRIBUÍDO COM SUCESSO!\n");
                }
                else
                    Console.WriteLine("\nTURMA NÃO ENCONTRADA!\n");
            }
            else
                Console.WriteLine("\nPROFESSOR NÃO ENCONTRADO!\n");
        }
        public void AtribuirAlunos(Escola escola) // ATRIBUI UM ALUNO A UMA TURMA ESPECIFICA DA ESCOLA
        {
            Console.Write("\nDIGITE A MATRÍCULA DO ALUNO QUE DESEJA INSERIR NA TURMA: ");
            int n = Validacao.ValidarNumeros(Console.ReadLine());

            Aluno aluno = escola.Alunos.Where(x => x.Matricula == n).FirstOrDefault();
            if (aluno != null)
            {
                escola.ListarTurmas(escola.Turmas);
                Console.Write("\nDIGITE O NÚMERO DA TURMA QUE DESEJA INSERIR O ALUNO(A): ");
                n = Validacao.ValidarNumeros(Console.ReadLine());
                Turma turma = escola.Turmas.Where(x => x.NumeroTurma == n).FirstOrDefault();
                if (turma != null)
                {
                    escola.Alunos.Remove(aluno);
                    turma.AdicionarAluno(aluno);
                }
                else
                    Console.WriteLine("\nTURMA NÃO ENCONTRADA!\n");
            }
            else
                Console.WriteLine("\nALUNO NÃO ENCONTRADO!\n");
        }
        public void ListarTurmas(List<Turma> turmas) // APRESENTA AS TURMAS EXISTENTES
        {
            Console.Write($"\nHÁ {turmas.Count} TURMA(S) CADASTRADA(S)!\n");
            turmas.ForEach(x => Console.WriteLine(x));
        }
        public void ListarCoordenadores(List<Coordenador> coordenadores) // APRESENTA OS COORDENADORES EXISTENTES
        {
            Console.Write($"\nHÁ {coordenadores.Count} COORDENADOR(ES) CADASTRADO(S)!\n");
            coordenadores.ForEach(x => Console.WriteLine(x));
        }
        public void ListarProfessores(List<Professor> professores) // APRESENTA OS PROFESSORES EXISTENTES
        {
            Console.Write($"\nHÁ {professores.Count} PROFESSOR(ES) CADASTRADO(S)!\n");
            professores.ForEach(x => Console.WriteLine(x));
        }
        public void ListarAlunos(List<Aluno> alunos) // APRESENTA OS ALUNOS EXISTENTES
        {
            Console.Write($"\nHÁ {alunos.Count} ALUNO(S) CADASTRADO(S)!\n");
            alunos.ForEach(x => Console.WriteLine(x));
        }
        public void ListarDadosTurma(Escola escola) // LISTA OS INTEGRANTES DE UMA TURMA ESPECIFICA
        {
            Console.Write("\nDIGITE O NÚMERO DA TURMA QUE DESEJA LISTAR SEUS INTEGRANTES: ");
            int n = Validacao.ValidarNumeros(Console.ReadLine());

            Turma turma = escola.Turmas.Where(x => x.NumeroTurma == n).FirstOrDefault();

            if (turma == null)
                Console.Write("\nTURMA NÃO ENCONTRADA!\n");
            else if (turma.Professor == null && turma.Alunos.Count == 0 && turma.Coordenador == null)
                Console.Write("\nNÃO HÁ NINGUEM CADASTRADO NESSA TURMA\n");
            else Console.WriteLine(turma);
        }
    }
}
