using System;
using System.Text.RegularExpressions;
using ProjetoEscola.Entities;
namespace ProjetoEscola
{
    public class Validacao
    {
        public static string ValidarSimOuNao(string s) // VALIDAR INPUTS DE SIM OU NÃO
        {
            while (s != "S" && s != "N")
            {
                Console.Write("\nVALOR INVÁLIDO, DIGITE APENAS LETRAS (S/N): ");
                Console.WriteLine();
                s = Console.ReadLine().ToUpper();
            }
            return s;
        }

        public static int ValidarNumeros(string s) // VALIDAR INPUTS DE NÚMEROS INTEIROS MAIORES QUE 0
        {
            int result;
            while (!int.TryParse(s, out result) || result <= 0)
            {
                Console.Write("\nVALOR INVÁLIDO, DIGITE APENAS VALORES INTEIROS POSITIVOS: ");
                s = Console.ReadLine();
            }
            return result;
        }

        public static int ValidadeMaioridade(string s) // VALIDAR IDADE MÍNIMA E MÁXIMA DOS INDIVIDUOS DA ESCOLA
        {
            int result;
            while (!int.TryParse(s, out result) || result < 18 || result > 100)
            {
                Console.Write("\nVALOR INVÁLIDO, DIGITE IDADE ENTRE 18 E 100 ANOS: ");
                s = Console.ReadLine();
            }
            return result;
        }

        public static int ValidarMenu(string s) // VALIDAR INPUTS DE NÚMEROS INTEIROS MAIORES OU IGUAIS A 0
        {
            int result;
            while (!int.TryParse(s, out result) || result < 0)
            {
                Console.Write("\nVALOR INVÁLIDO, DIGITE APENAS VALORES INTEIROS POSITIVOS OU 0: ");
                s = Console.ReadLine();
            }
            return result;
        }

        public static string ValidarLetras(string s) // VALIDAR APENAS LETRAS DE NOME E SOBRENOME
        {
            string[] vet = s.Split(' ');

            while (!Regex.IsMatch(s, @"^[a-z A-Z]+$") || string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s) || vet.Length < 2)
            {
                Console.Write("\nVALOR INVÁLIDO, DIGITE O NOME COMPLETO E APENAS LETRAS [A-Z]: ");
                s = Console.ReadLine();
                vet = s.Split(' ');
            }
            return s;
        }

        public static string ValidarSexo(string s) // VALIDAR INPUTS DE SEXO, APENAS M OU F
        {
            while (s != "M" && s != "F")
            {
                Console.Write("\nVALOR INVÁLIDO PARA SEXO, DIGITE (M/F): ");
                s = Console.ReadLine().ToUpper();
            }
            return s;
        }

        internal static void NaoHaTurmas(Escola escola) // VERIFICA SE HÁ TURMAS, CASO NÃO HAJA, PERMITE CADASTRAR UMA OU MAIS
        {
            string s = "S";
            while (escola.Turmas.Count == 0 && s != "N")
            {
                Console.Write("\nNÃO HÁ NENHUMA TURMA CADASTRADA, DESEJA CADASTRAR? (S/N): ");
                s = ValidarSimOuNao(Console.ReadLine().ToUpper());
                if (s == "S")
                    escola.CadastrarTurmas();
            }
        }
        internal static void NaoHaCoordenadores(Escola escola) // VERIFICA SE HÁ COORDENADORES, CASO NÃO HAJA, PERMITE CADASTRAR UM
        {
            string s = "S";
            while (escola.Coordenadores.Count == 0 && s != "N")
            {
                Console.Write("\nNÃO HÁ NENHUM COORDENADOR CADASTRADO, DESEJA CADASTRAR UM? (S/N): ");
                s = ValidarSimOuNao(Console.ReadLine().ToUpper());
                if (s == "S")
                    escola.CadastrarCoordenador();
            }
        }
        internal static void NaoHaProfessores(Escola escola) // VERIFICA SE HÁ PROFESSORES, CASO NÃO HAJA, PERMITE CADASTRAR UM
        {
            string s = "S";
            while (escola.Professores.Count == 0 && s != "N")
            {
                Console.Write("\nNÃO HÁ NENHUM PROFESSOR CADASTRADO, DESEJA CADASTRAR UM? (S/N): ");
                s = ValidarSimOuNao(Console.ReadLine().ToUpper());
                if (s == "S")
                    escola.CadastrarProfessor(escola);
            }
        }
        internal static void NaoHaAlunos(Escola escola) // VERIFICA SE HÁ ALUNOS, CASO NÃO HAJA, PERMITE CADASTRAR UM
        {
            string s = "S";
            while (escola.Alunos.Count == 0 && s != "N")
            {
                Console.Write("\nNÃO HÁ NENHUM ALUNO CADASTRADO, DESEJA CADASTRAR UM? (S/N): ");
                s = ValidarSimOuNao(Console.ReadLine().ToUpper());
                if (s == "S")
                    escola.CadastrarAluno();
            }
        }
    }
}
