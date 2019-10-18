using System;
using ProjetoEscola.Entities;

namespace ProjetoEscola
{
    class Program
    {
        static void Main(string[] args)
        {
            Escola escola = new Escola();
            Menu.MenuInicial(escola);
        }
    }
}
