using System;
using ProjetoEscola.Entities;
using System.Linq;

namespace ProjetoEscola
{
    public class Menu
    {
        public static int n; // CONTROLA OS CASES DO MENU INICIAL E RECEBE NUMEROS PARA MANIPULAÇÃO
        public static int j; // CONTROLA OS CASES DO MENU ATRIBUIÇÃO

        internal static void MenuInicial(Escola escola)
        {

            while (true)
            {
                Console.WriteLine("SELECIONE UMA OPÇÃO DE [0] A [7]");
                Console.WriteLine("[1] - CADASTRAR TURMA");
                Console.WriteLine("[2] - CADASTRAR COORDENADOR");
                Console.WriteLine("[3] - CADASTRAR PROFESSOR");
                Console.WriteLine("[4] - CADASTRAR ALUNO");
                Console.WriteLine("[5] - LISTAR TURMAS");
                Console.WriteLine("[6] - LISTAR COORDENADORES");
                Console.WriteLine("[7] - LISTAR PROFESSORES");
                Console.WriteLine("[8] - LISTAR ALUNOS");
                Console.WriteLine("[9] - INSERIR MEMBROS A TURMA");
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
                        escola.CadastrarCoordenador();
                        Console.Write("\nPRESSIONE ENTER PARA VOLTAR AO MENU INICIAL..");
                        Console.ReadLine();
                        break;
                    case 3:
                        escola.CadastrarProfessor();
                        Console.Write("\nPRESSIONE ENTER PARA VOLTAR AO MENU INICIAL..");
                        Console.ReadLine();
                        break;
                    case 4:
                        escola.CadastrarAluno();
                        Console.Write("\nPRESSIONE ENTER PARA VOLTAR AO MENU INICIAL..");
                        Console.ReadLine();
                        break;
                    case 5:
                        escola.ListarTurmas(escola.Turmas);
                        if (escola.Turmas.Count > 0)
                        {
                            Console.Write("\nDESEJA EXIBIR OS INTEGRANTES DE ALGUMA TURMA? (S/N): ");
                            string s = Validacao.ValidarSimOuNao(Console.ReadLine().ToUpper());
                            if (s == "S")
                                ListarDadosTurma(escola);
                        }
                        Console.Write("\nPRESSIONE ENTER PARA VOLTAR AO MENU INICIAL..");
                        Console.ReadLine();
                        break;
                    case 6:
                        escola.ListarCoordenadores(escola.Coordenadores);
                        Console.Write("\nPRESSIONE ENTER PARA VOLTAR AO MENU INICIAL..");
                        Console.ReadLine();
                        break;
                    case 7:
                        escola.ListarProfessores(escola.Professores);
                        Console.Write("\nPRESSIONE ENTER PARA VOLTAR AO MENU INICIAL..");
                        Console.ReadLine();
                        break;
                    case 8:
                        escola.ListarAlunos(escola.Alunos);
                        Console.Write("\nPRESSIONE ENTER PARA VOLTAR AO MENU INICIAL..");
                        Console.ReadLine();
                        break;
                    case 9:
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
            Console.WriteLine("[1] - INSERIR UM COORDENADOR A UMA TURMA");
            Console.WriteLine("[2] - INSERIR UM PROFESSOR A UMA TURMA");
            Console.WriteLine("[3] - INSERIR UM ALUNO A UMA TURMA");
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
                    while (escola.Coordenadores.Count == 0 && s != "N") // ENQUANTO NÃO HOUVER COORDENADOR CADASTRADO, PERGUNTA SE QUER CADASTRAR NA HORA
                        s = Validacao.NaoHaCoordenadores(escola);
                    if (escola.Turmas.Count == 0 || escola.Coordenadores.Count == 0) // PRECISA TER PELO MENOS UMA TURMA E UM ALUNO
                        Console.Write("\nÉ NECESSÁRIO TER PELO MENOS UM ALUNO E UMA TURMA CADASTRADA PARA FAZER A ATRIBUIÇÃO");

                    else // SE CHEGAR NESSE ELSE, SIGNIFICA QUE HÁ PELO MENOS UMA TURMA E UM COORDENADOR
                    {
                        escola.ListarCoordenadores(escola.Coordenadores);
                        AtribuirCoordenador(escola);
                    }
                    break;
                case 2:
                    s = "S";
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

                case 3:
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

        internal static void AtribuirCoordenador(Escola escola) // ATRIBUI UM PROFESSOR A UMA TURMA ESPECIFICA
        {
            Console.Write("\nDIGITE O REGISTRO DO COORDENADOR QUE DESEJA INSERIR NA TURMA: ");
            n = Validacao.ValidarNumeros(Console.ReadLine());

            Coordenador coordenador = escola.Coordenadores.Where(x => x.Registro == n).FirstOrDefault();
            if (coordenador != null)
            {
                escola.ListarTurmas(escola.Turmas);
                Console.Write("\nDIGITE O NÚMERO DA TURMA QUE DESEJA INSERIR O COORDENADOR(A): ");
                n = Validacao.ValidarNumeros(Console.ReadLine());
                Turma turma = escola.Turmas.Where(x => x.NumeroTurma == n).FirstOrDefault();
                if (turma != null)
                {
                    turma.AdicionarCoordenador(coordenador);
                    Console.Write("\nCOORDENADOR(A) ATRIBUÍDO COM SUCESSO!");
                }
                else
                    Console.WriteLine("\nTURMA NÃO ENCONTRADA!");
            }
            else
                Console.WriteLine("\nCOORDENADOR NÃO ENCONTRADO!");

        }
        internal static void AtribuirProfessor(Escola escola) // ATRIBUI UM PROFESSOR A UMA TURMA ESPECIFICA
        {
            Console.Write("\nDIGITE O REGISTRO DO PROFESSOR QUE DESEJA INSERIR NA TURMA: ");
            n = Validacao.ValidarNumeros(Console.ReadLine());

            Professor professor = escola.Professores.Where(x => x.Registro == n).FirstOrDefault();
            if (professor != null)
            {
                escola.ListarTurmas(escola.Turmas);
                Console.Write("\nDIGITE O NÚMERO DA TURMA QUE DESEJA INSERIR O PROFESSOR(A): ");
                n = Validacao.ValidarNumeros(Console.ReadLine());
                Turma turma = escola.Turmas.Where(x => x.NumeroTurma == n).FirstOrDefault();
                if (turma != null)
                {
                    turma.AdicionarProfessor(professor);
                    Console.Write("\nPROFESSOR(A) ATRIBUÍDO COM SUCESSO!");
                }
                else
                    Console.WriteLine("\nTURMA NÃO ENCONTRADA!");
            }
            else
                Console.WriteLine("\nPROFESSOR NÃO ENCONTRADO!");
            
        }
        internal static void AtribuirAlunos(Escola escola) // ATRIBUI UM ALUNO A UMA TURMA ESPECIFICA
        {
            Console.Write("\nDIGITE A MATRÍCULA DO ALUNO QUE DESEJA INSERIR NA TURMA: ");
            n = Validacao.ValidarNumeros(Console.ReadLine());

            Aluno aluno = escola.Alunos.Where(x => x.Matricula == n).FirstOrDefault();
            if (aluno != null)
            {
                escola.ListarTurmas(escola.Turmas);
                Console.Write("\nDIGITE O NÚMERO DA TURMA QUE DESEJA INSERIR O ALUNO(A): ");
                n = Validacao.ValidarNumeros(Console.ReadLine());
                Turma turma = escola.Turmas.Where(x => x.NumeroTurma == n).FirstOrDefault();
                if (turma != null)
                {
                    turma.AdicionarAluno(aluno);
                    Console.Write("\nALUNO(A) ATRIBUÍDO COM SUCESSO!");
                }
                else
                    Console.WriteLine("\nTURMA NÃO ENCONTRADA!");
            }
            else
                Console.WriteLine("\nALUNO NÃO ENCONTRADO!");
        }
        internal static void ListarDadosTurma(Escola escola) // LISTA OS INTEGRANTES DE UMA TURMA ESPECIFICA
        {
            Console.Write("\nDIGITE O NÚMERO DA TURMA QUE DESEJA LISTAR SEUS INTEGRANTES: ");
            n = Validacao.ValidarNumeros(Console.ReadLine());

            var turma = escola.Turmas.Where(x => x.NumeroTurma == n).FirstOrDefault();

            if (turma == null)
                Console.WriteLine("\nNÃO HÁ NINGUEM CADASTRADO NESSA TURMA\n");
            else if (turma.Professor != null || turma.Alunos.Count > 0)
                Console.WriteLine(turma);
        }
    }
}

