namespace ProjetoCadastroAssociado
{
    public class Associado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public List<AssociadoEmpresa> AssociadoEmpresas { get; set; }
    }
}
