using System;
using System.Collections.Generic;
using System.Text;
namespace ProjetoEscola.Entities
{
    class Coordenador : Pessoa
    {
        public int Registro { get; set; } = new Random().Next(1000, 9999);
        public List<Professor> Professores { get; set; } = new List<Professor>();
        public List<Turma> Turmas { get; set; } = new List<Turma>();

        public override string ToString() // IMPRIME O COORDENADOR E SEUS RELACIONADOS
        {
            StringBuilder printCoordenador = new StringBuilder();
            printCoordenador.AppendLine("-----------------------------------------------------------------------------");
            printCoordenador.AppendLine($"REGISTRO: {Registro}");
            printCoordenador.AppendLine($"NOME: {Nome.ToUpper()} {Sobrenome.ToUpper()}");
            printCoordenador.Append($"SEXO: {Sexo.ToUpper()} ");
            printCoordenador.Append($"IDADE: {Idade}\n");
            if (Professores.Count == 0)
            {
                printCoordenador.AppendLine("-- PROFESSORES ASSOCIADOS --");
                printCoordenador.AppendLine("COORDENADOR AINDA NÃO POSSUI PROFESSORES ASSOCIADOS!");
            }   
            else
            {
                printCoordenador.AppendLine("-- PROFESSORES ASSOCIADOS --");
                Professores.ForEach(x => printCoordenador.AppendLine(x.ToString()));
            }
            if (Turmas.Count == 0)
            {
                printCoordenador.AppendLine("-- TURMAS ASSOCIADAS --");
                printCoordenador.AppendLine("COORDENADOR AINDA NÃO É RESPONSÁVEL POR NENHUMA TURMA!");
            }    
            else
            {
                printCoordenador.AppendLine("-- TURMAS ASSOCIADAS --");
                Turmas.ForEach(x => printCoordenador.AppendLine($"NÚMERO TURMA {x.NumeroTurma} - DATA DE ABERTURA - {x.DataDeAbertura}"));
            }
            printCoordenador.Append("-----------------------------------------------------------------------------");
            return printCoordenador.ToString();
        }

    }
}
