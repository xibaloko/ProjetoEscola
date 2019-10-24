namespace ProjetoEscola.Entities
{
    abstract class Pessoa
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Sexo { get; set; }
        public int Idade { get; set; }
    }
}
