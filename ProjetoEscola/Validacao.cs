using System;
using System.Text.RegularExpressions;
using ProjetoEscola.Entities;

namespace ProjetoEscola
{
    public class Validacao
    {
        public static string ValidarSimOuNao(string s) // MÉTODO USADO PARA VALIDAR INPUTS DE SIM OU NÃO
        {
            while (s != "S" && s != "N")
            {
                Console.Write("\nVALOR INVÁLIDO, DIGITE APENAS LETRAS (S/N): ");
                Console.WriteLine();
                s = Console.ReadLine().ToUpper();
            }
            return s;
        }

        public static int ValidarNumeros(string s) // VALIDAR INPUTS DE NUMEROS INTEIROS MAIORES QUE 0
        {
            int result;
            while (!int.TryParse(s, out result) || result <= 0)
            {
                Console.Write("\nVALOR INVÁLIDO, DIGITE APENAS VALORES INTEIROS POSITIVOS: ");
                s = Console.ReadLine();
            }
            return result;
        }

        public static int ValidarMenuInicial(string s) // VALIDAR INPUTS DE NÚMEROS INTEIROS MAIORES OU IGUAIS A 0
        {
            int result;
            while (!int.TryParse(s, out result))
            {
                Console.Write("\nVALOR INVÁLIDO, DIGITE APENAS VALORES INTEIROS POSITIVOS: ");
                s = Console.ReadLine();
            }
            return result;
        }

        public static string ValidarLetrasComEspaco(string s) // VALIDAR APENAS LETRAS DE DUAS PALAVRAS OU MAIS
        {
            while (!Regex.IsMatch(s, @"^[a-z A-Z]+$") || string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s))
            {
                Console.Write("\nVALOR INVÁLIDO, DIGITE APENAS LETRAS [A-Z]: ");
                s = Console.ReadLine();
            }
            return s;
        }

        public static string ValidarLetrasSemEspaco(string s) // VALIDAR APENAS LETRAS DE APENAS UMA PALAVRA
        {
            while (!Regex.IsMatch(s, @"^[a-zA-Z]+$") || string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s))
            {
                Console.Write("\nVALOR INVÁLIDO, DIGITE APENAS LETRAS [A-Z] E APENAS UMA PALAVRA: ");
                s = Console.ReadLine();
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

        internal static string NaoHaTurmas(Escola escola) // SE JA HOUVER UMA TURMA, CHAMA O CADASTRAR TURMA
        {
            Console.WriteLine("\nNÃO HÁ NENHUMA TURMA CADASTRADA, DESEJA CADASTRAR? (S/N)");
            string s = ValidarSimOuNao(Console.ReadLine().ToUpper());
            if (s == "S")
            {
                escola.CadastrarTurmas();
                return "S";
            }
            else
                return "N";
        }
        internal static string NaoHaProfessores(Escola escola) // SE JA HOUVER UM PROFESSOR, CHAMA O CADASTRAR PROFESSOR
        {
            Console.WriteLine("\nNÃO HÁ NENHUM PROFESSOR CADASTRADO, DESEJA CADASTRAR UM? (S/N)");
            string s = ValidarSimOuNao(Console.ReadLine().ToUpper());
            if (s == "S")
            {
                escola.CadastrarProfessor();
                return "S";
            }
            else
                return "N";
        }
        internal static string NaoHaAlunos(Escola escola) // SE JA HOUVER UM ALUNO, CHAMA O CADASTRAR ALUNO
        {
            Console.WriteLine("\nNÃO HÁ NENHUM ALUNO CADASTRADO, DESEJA CADASTRAR UM? (S/N)");
            string s = ValidarSimOuNao(Console.ReadLine().ToUpper());
            if (s == "S")
            {
                escola.CadastrarAluno();
                return "S";
            }
            else
                return "N";
        }
    }
}
