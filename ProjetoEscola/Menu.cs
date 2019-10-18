using System;
using ProjetoEscola.Entities;

namespace ProjetoEscola
{
    public class Menu
    {
        public static int n; // CONTROLA OS CASES DO MENU INICIAL E RECEBE NUMEROS PARA MANIPULAÇÃO
        public static int j; // CONTROLA OS CASES DO MENU ATRIBUIÇÃO

        internal static void MenuInicial(Escola escola)
        {

            while(true)
            {
                Console.WriteLine("SELECIONE UMA OPÇÃO DE [0] A [7]");
                Console.WriteLine("[1] - CADASTRAR TURMA");
                Console.WriteLine("[2] - CADASTRAR PROFESSOR");
                Console.WriteLine("[3] - CADASTRAR ALUNO");
                Console.WriteLine("[4] - LISTAR TURMAS");
                Console.WriteLine("[5] - LISTAR PROFESSORES");
                Console.WriteLine("[6] - LISTAR ALUNOS");
                Console.WriteLine("[7] - INSERIR PROFESSORES E ALUNOS NA TURMA");
                Console.WriteLine("[0] - SAIR\n");

                n = Validacao.ValidarMenuInicial(Console.ReadLine());

                switch (n)
                {
                    case 0:
                        Console.Write("\nOBRIGADO! PRESSIONE ENTER PARA SAIR..");
                        Console.ReadLine();
                        Environment.Exit(0);
                        break;
                    case 1:
                        escola.CadastrarTurmas();
                        Console.Write("\nPRESSIONE ENTER PARA VOLTAR AO MENU INICIAL..");
                        Console.ReadLine();
                        break;
                    case 2:
                        escola.CadastrarProfessor();
                        Console.Write("\nPRESSIONE ENTER PARA VOLTAR AO MENU INICIAL..");
                        Console.ReadLine();
                        break;
                    case 3:
                        escola.CadastrarAluno();
                        Console.Write("\nPRESSIONE ENTER PARA VOLTAR AO MENU INICIAL..");
                        Console.ReadLine();
                        break;
                    case 4:
                        escola.ListarTurmas(escola.Turmas);
                        if(escola.Turmas.Count > 0)
                        {
                            Console.Write("\nDESEJA EXIBIR OS INTEGRANTES DE ALGUMA TURMA? (S/N): ");
                            string s = Validacao.ValidarSimOuNao(Console.ReadLine().ToUpper());
                            if (s == "S")
                                ListarDadosTurma(escola);
                        }
                        Console.Write("\nPRESSIONE ENTER PARA VOLTAR AO MENU INICIAL..");
                        Console.ReadLine();
                        break;
                    case 5:
                        escola.ListarProfessores(escola.Professores);
                        Console.Write("\nPRESSIONE ENTER PARA VOLTAR AO MENU INICIAL..");
                        Console.ReadLine();
                        break;
                    case 6:
                        escola.ListarAlunos(escola.Alunos);
                        Console.Write("\nPRESSIONE ENTER PARA VOLTAR AO MENU INICIAL..");
                        Console.ReadLine();
                        break;
                    case 7:
                        MenuAtribuir(escola);
                        Console.Write("\nPRESSIONE ENTER PARA VOLTAR AO MENU INICIAL..");
                        Console.ReadLine();
                        break;
                    default:
                        Console.Write("\nVALOR INVÁLIDO, PRESSIONE ENTER PARA REINICIAR");
                        Console.ReadLine();
                        Console.Clear();
                        MenuInicial(escola);
                        break;
                }
                Console.Clear();
            };

        }
        internal static void MenuAtribuir(Escola escola) // MENU DE DECISÃO PARA ATRIBUIÇÃO DE PROFESSORES E ALUNOS A TURMAS
        {
            Console.WriteLine("\nSELECIONE UMA OPÇÃO DE [0] A [2]");
            Console.WriteLine("[1] - INSERIR UM PROFESSOR A UMA TURMA");
            Console.WriteLine("[2] - INSERIR UM ALUNO A UMA TURMA");
            Console.WriteLine("[0] - VOLTAR AO MENU INICIAL\n");
            j = Validacao.ValidarMenuInicial(Console.ReadLine());

            switch (j)
            {
                case 0:
                    break;

                case 1:
                    string s = "S";
                    while (escola.Turmas.Count == 0 && s != "N") // ENQUANTO NÃO HOUVER TURMA CADASTRADA, PERGUNTA SE QUER CADASTRAR NA HORA
                        s = Validacao.NaoHaTurmas(escola);
                    s = "S";
                    while (escola.Professores.Count == 0 && s != "N") // ENQUANTO NÃO HOUVER PROFESSOR CADASTRADO, PERGUNTA SE QUER CADASTRAR NA HORA
                        s = Validacao.NaoHaProfessores(escola);
                    if (escola.Turmas.Count == 0 || escola.Professores.Count == 0) // PRECISA TER PELO MENOS UMA TURMA E UM PROFESSOR
                        Console.Write("\nÉ NECESSÁRIO TER PELO MENOS UM PROFESSOR E UMA TURMA CADASTRADA PARA FAZER A ATRIBUIÇÃO\n");

                    else // SE CHEGAR NESSE ELSE, SIGNIFICA QUE HÁ PELO MENOS UMA TURMA E UM PROFESSOR
                    {
                        escola.ListarProfessores(escola.Professores);
                        AtribuirProfessor(escola);
                    }
                    break;

                case 2:
                    s = "S";
                    while (escola.Turmas.Count == 0 && s != "N") // ENQUANTO NÃO HOUVER TURMA CADASTRADA, PERGUNTA SE QUER CADASTRAR NA HORA
                        s = Validacao.NaoHaTurmas(escola);
                    s = "S";
                    while (escola.Alunos.Count == 0 && s != "N") // ENQUANTO NÃO HOUVER ALUNO CADASTRADO, PERGUNTA SE QUER CADASTRAR NA HORA
                        s = Validacao.NaoHaAlunos(escola);
                    if (escola.Turmas.Count == 0 || escola.Alunos.Count == 0) // PRECISA TER PELO MENOS UMA TURMA E UM ALUNO
                        Console.Write("\nÉ NECESSÁRIO TER PELO MENOS UM ALUNO E UMA TURMA CADASTRADA PARA FAZER A ATRIBUIÇÃO");

                    else // SE CHEGAR NESSE ELSE, SIGNIFICA QUE HÁ PELO MENOS UMA TURMA E UM ALUNO
                    {
                        escola.ListarAlunos(escola.Alunos);
                        AtribuirAlunos(escola);
                    }
                    break;
            }
        }
        internal static void AtribuirProfessor(Escola escola) // ATRIBUI UM PROFESSOR A UMA TURMA ESPECIFICA
        {
            Console.Write("\nDIGITE O REGISTRO DO PROFESSOR QUE DESEJA INSERIR NA TURMA: ");
            n = Validacao.ValidarNumeros(Console.ReadLine());

            foreach (Professor professor in escola.Professores)
            {
                if (professor.Registro == n)
                {
                    escola.ListarTurmas(escola.Turmas);
                    Console.Write("\nDIGITE O NÚMERO DA TURMA QUE DESEJA INSERIR O PROFESSOR(A): ");
                    n = Validacao.ValidarNumeros(Console.ReadLine());

                    foreach (Turma turma in escola.Turmas)
                        if (turma.NumeroTurma == n)
                        {
                            turma.AdicionarProfessor(professor);
                            Console.Write("\nPROFESSOR ATRIBUÍDO COM SUCESSO!\n");
                        }
                }

            }
        }
        internal static void AtribuirAlunos(Escola escola) // ATRIBUI UM ALUNO A UMA TURMA ESPECIFICA
        {
            Console.Write("\nDIGITE A MATRÍCULA DO ALUNO QUE DESEJA INSERIR NA TURMA: ");
            n = Validacao.ValidarNumeros(Console.ReadLine());

            foreach (Aluno aluno in escola.Alunos)
            {
                if (aluno.Matricula == n)
                {
                    escola.ListarTurmas(escola.Turmas);
                    Console.Write("\nDIGITE O NÚMERO DA TURMA QUE DESEJA INSERIR O ALUNO(A): ");
                    n = Validacao.ValidarNumeros(Console.ReadLine());
                    Console.WriteLine();

                    foreach (Turma turma in escola.Turmas)
                        if (turma.NumeroTurma == n)
                        {
                            turma.AdicionarAluno(aluno);
                            Console.Write("\nALUNO(A) ATRIBUÍDO COM SUCESSO!\n");
                        }
                }
            }
        }
        internal static void ListarDadosTurma(Escola escola) // LISTA OS INTEGRANTES DE UMA TURMA ESPECIFICA
        {
            Console.Write("\nDIGITE O NÚMERO DA TURMA QUE DESEJA LISTAR SEUS INTEGRANTES: ");
            n = Validacao.ValidarNumeros(Console.ReadLine());

            foreach (Turma turma in escola.Turmas)
            {
                if (turma.NumeroTurma == n)
                {
                    if (turma.Professor != null || turma.Alunos.Count > 0)
                        turma.ListarRelacionados();
                    else
                        Console.WriteLine("\nNÃO HÁ NINGUEM CADASTRADO NESSA TURMA\n");
                }                                 
            }
        }
    }
}

