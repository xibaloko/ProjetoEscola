using System;
using ProjetoEscola.Entities;
using System.Linq;
namespace ProjetoEscola
{
    public class Menu
    {
        internal static void MenuInicial(Escola escola)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("SELECIONE UMA OPÇÃO DE [1] A [3]\n");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("[1] - CADASTRAR");
                Console.WriteLine("[2] - LISTAR");
                Console.WriteLine("[3] - INSERIR");
                Console.WriteLine("[4] - REMOVER");
                Console.WriteLine("[ESC] - SAIR");

                ConsoleKeyInfo tecla = Console.ReadKey();

                switch (tecla.Key)
                {
                    case ConsoleKey.Escape:
                        Console.WriteLine("\nOOOBRIGADO! PRESSIONE ENTER PARA SAIR..");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.NumPad1:
                        MenuCadastrar(escola);
                        break;
                    case ConsoleKey.NumPad2:
                        MenuListar(escola);
                        break;
                    case ConsoleKey.NumPad3:
                        MenuInserir(escola);
                        break;
                    case ConsoleKey.NumPad4:
                        MenuRemover(escola);
                        break;
                    default:
                        Console.Write("\nVALOR INVÁLIDO, PRESSIONE QUALQUER TECLA PARA REINICIAR");
                        Console.ReadKey();
                        Console.Clear();
                        MenuInicial(escola);
                        break;
                }
            };
        } // MOSTRA AS OPÇÕES INICIAIS DO PROGRAMA
        internal static void MenuCadastrar(Escola escola)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("SELECIONE UMA OPÇÃO DE [1] A [4]\n");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("[1] - CADASTRAR TURMA");
                Console.WriteLine("[2] - CADASTRAR COORDENADOR");
                Console.WriteLine("[3] - CADASTRAR PROFESSOR");
                Console.WriteLine("[4] - CADASTRAR ALUNO");
                Console.WriteLine("[ESC] - VOLTAR AO MENU INICIAL");
                
                ConsoleKeyInfo tecla = Console.ReadKey();

                switch (tecla.Key)
                {
                    case ConsoleKey.Escape:
                        MenuInicial(escola);
                        break;
                    case ConsoleKey.NumPad1:
                        escola.CadastrarTurmas();
                        Console.Write("\nPRESSIONE QUALQUER TECLA PARA VOLTAR..");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.NumPad2:
                        escola.CadastrarCoordenador();
                        Console.Write("\nPRESSIONE QUALQUER TECLA PARA VOLTAR..");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.NumPad3:
                        escola.CadastrarProfessor(escola);
                        Console.Write("\nPRESSIONE QUALQUER TECLA PARA VOLTAR..");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.NumPad4:
                        escola.CadastrarAluno();
                        Console.Write("\nPRESSIONE QUALQUER TECLA PARA VOLTAR..");
                        Console.ReadKey();
                        break;
                    default:
                        Console.Write("\nPRESSIONE QUALQUER TECLA PARA VOLTAR..");
                        Console.ReadKey();
                        MenuCadastrar(escola);
                        break;
                }
            }
        } // PERMITE CADASTRAR INDIVÍDUOS NA ESCOLA PARA POSTERIORMENTE ALOCALOS
        internal static void MenuListar(Escola escola)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("SELECIONE UMA OPÇÃO DE [1] A [5]\n");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("[1] - LISTAR TURMA ESPECIFICA");
                Console.WriteLine("[2] - LISTAR TURMAS");
                Console.WriteLine("[3] - LISTAR COORDENADORES");
                Console.WriteLine("[4] - LISTAR PROFESSORES");
                Console.WriteLine("[5] - LISTAR ALUNOS");
                Console.WriteLine("[ESC] - VOLTAR AO MENU INICIAL");
                
                ConsoleKeyInfo tecla = Console.ReadKey();

                switch (tecla.Key)
                {
                    case ConsoleKey.Escape:
                        MenuInicial(escola);
                        break;
                    case ConsoleKey.NumPad1:
                        escola.ListarDadosTurma(escola);
                        Console.Write("\nPRESSIONE QUALQUER TECLA PARA VOLTAR..");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.NumPad2:
                        escola.ListarTurmas(escola.Turmas);
                        Console.Write("\nPRESSIONE QUALQUER TECLA PARA VOLTAR..");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.NumPad3:
                        escola.ListarCoordenadores(escola.Coordenadores);
                        Console.Write("\nPRESSIONE QUALQUER TECLA PARA VOLTAR..");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.NumPad4:
                        escola.ListarProfessores(escola.Professores);
                        Console.Write("\nPRESSIONE QUALQUER TECLA PARA VOLTAR..");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.NumPad5:
                        escola.ListarAlunos(escola.Alunos);
                        Console.Write("\nPRESSIONE QUALQUER TECLA PARA VOLTAR..");
                        Console.ReadKey();
                        break;
                    default:
                        Console.Write("\nPRESSIONE QUALQUER TECLA PARA VOLTAR..");
                        Console.ReadKey();
                        MenuListar(escola);
                        break;
                }
            }
        } // PERMITE LISTAR A QUALQUER MOMENTO TODOS OS CADASTRADOS NA ESCOLA
        internal static void MenuInserir(Escola escola) // CONTROLA AS OPÇÕES DE INSERÇÃO DE COORDENADORES, PROFESSORES E ALUNOS A TURMA
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("SELECIONE UMA OPÇÃO DE [1] A [3]\n");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("[1] - INSERIR UM COORDENADOR A UMA TURMA");
                Console.WriteLine("[2] - INSERIR UM PROFESSOR A UMA TURMA");
                Console.WriteLine("[3] - INSERIR UM ALUNO A UMA TURMA");
                Console.WriteLine("[ESC] - VOLTAR AO MENU INICIAL");


                ConsoleKeyInfo tecla = Console.ReadKey();

                switch (tecla.Key)
                {
                    case ConsoleKey.Escape:
                        MenuInicial(escola);
                        break;
                    case ConsoleKey.NumPad1:
                        Validacao.NaoHaTurmas(escola);
                        Validacao.NaoHaCoordenadores(escola);
                        if (escola.Turmas.Count == 0 || escola.Coordenadores.Count == 0)
                            Console.Write("\nÉ NECESSÁRIO TER PELO MENOS UM COORDENADOR E UMA TURMA CADASTRADA PARA FAZER A INSERÇÃO\n");
                        else
                        {
                            escola.ListarCoordenadores(escola.Coordenadores);
                            escola.AtribuirCoordenador(escola);
                        }
                        Console.WriteLine("\nPRESSIONE QUALQUER TECLA PARA VOLTAR..");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.NumPad2:
                        Validacao.NaoHaTurmas(escola);
                        Validacao.NaoHaProfessores(escola);
                        if (escola.Turmas.Count == 0 || escola.Professores.Count == 0)
                            Console.Write("\nÉ NECESSÁRIO TER PELO MENOS UM PROFESSOR E UMA TURMA CADASTRADA PARA FAZER A ATRIBUIÇÃO\n");
                        else
                        {
                            escola.ListarProfessores(escola.Professores);
                            escola.AtribuirProfessor(escola);
                        }
                        Console.WriteLine("\nPRESSIONE QUALQUER TECLA PARA VOLTAR..");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.NumPad3:
                        Validacao.NaoHaTurmas(escola);
                        Validacao.NaoHaAlunos(escola);
                        if (escola.Turmas.Count == 0 || escola.Alunos.Count == 0)
                            Console.Write("\nÉ NECESSÁRIO TER PELO MENOS UM ALUNO E UMA TURMA CADASTRADA PARA FAZER A ATRIBUIÇÃO\n");
                        else
                        {
                            escola.ListarAlunos(escola.Alunos);
                            escola.AtribuirAlunos(escola);
                        }
                        Console.WriteLine("\nPRESSIONE QUALQUER TECLA PARA VOLTAR..");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("\nVALOR INVÁLIDO, PRESSIONE ENTER PARA VOLTAR..");
                        Console.ReadKey();
                        MenuInserir(escola);
                        break;
                }
            }
        }
        internal static void MenuRemover(Escola escola) // CONTROLA AS OPÇÕES DE REMOÇÃO DE COORDENADORES, PROFESSORES E ALUNOS A TURMA
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("SELECIONE UMA OPÇÃO DE [1] A [3]\n");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("[1] - REMOVER UM COORDENADOR DE UMA TURMA");
                Console.WriteLine("[2] - REMOVER UM PROFESSOR A UMA TURMA");
                Console.WriteLine("[3] - REMOVER UM ALUNO A UMA TURMA");
                Console.WriteLine("[ESC] - VOLTAR AO MENU INICIAL");

                int n;
                Turma turma;
                ConsoleKeyInfo tecla = Console.ReadKey();

                switch (tecla.Key)
                {
                    case ConsoleKey.Escape:
                        MenuInicial(escola);
                        break;
                    case ConsoleKey.NumPad1:
                        Validacao.NaoHaTurmas(escola);
                        if (escola.Turmas.Count == 0)
                            Console.Write("\nÉ NECESSÁRIO TER PELO MENOS UMA TURMA CADASTRADA PARA FAZER A EXCLUSÃO");
                        else
                        {
                            escola.ListarTurmas(escola.Turmas);
                            Console.Write("\nDIGITE O NÚMERO DA TURMA QUE DESEJA REMOVER O COORDENADOR: ");
                            n = Validacao.ValidarNumeros(Console.ReadLine());
                            turma = escola.Turmas.Where(x => x.NumeroTurma == n).FirstOrDefault();
                            turma.RemoverCoordenador(turma);
                        }
                        Console.WriteLine("\nPRESSIONE QUALQUER TECLA PARA VOLTAR..");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.NumPad2:
                        Validacao.NaoHaTurmas(escola);
                        if (escola.Turmas.Count == 0)
                            Console.Write("\nÉ NECESSÁRIO TER PELO MENOS UMA TURMA CADASTRADA PARA FAZER A EXCLUSÃO");
                        else
                        {
                            escola.ListarTurmas(escola.Turmas);
                            Console.Write("\nDIGITE O NÚMERO DA TURMA QUE DESEJA REMOVER O PROFESSOR: ");
                            n = Validacao.ValidarNumeros(Console.ReadLine());
                            turma = escola.Turmas.Where(x => x.NumeroTurma == n).FirstOrDefault();
                            turma.RemoverProfessor(escola, turma);
                        }
                        Console.WriteLine("\nPRESSIONE QUALQUER TECLA PARA VOLTAR..");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.NumPad3:
                        Validacao.NaoHaTurmas(escola);
                        if (escola.Turmas.Count == 0)
                            Console.Write("\nÉ NECESSÁRIO TER PELO MENOS UMA TURMA CADASTRADA PARA FAZER A EXCLUSÃO");
                        else
                        {
                            escola.ListarTurmas(escola.Turmas);
                            Console.Write("\nDIGITE O NÚMERO DA TURMA QUE DESEJA REMOVER O ALUNO: ");
                            n = Validacao.ValidarNumeros(Console.ReadLine());
                            turma = escola.Turmas.Where(x => x.NumeroTurma == n).FirstOrDefault();
                            turma.RemoverAluno(escola, turma);
                        }
                        Console.WriteLine("\nPRESSIONE QUALQUER TECLA PARA VOLTAR..");
                        Console.ReadKey();
                        break;
                    default:
                        Console.Write("\nVALOR INVÁLIDO, PRESSIONE ENTER PARA VOLTAR..");
                        Console.ReadKey();
                        MenuRemover(escola);
                        break;
                }
            }
        }
    }
}

