﻿namespace ProjetoCadastroAssociado
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public List<AssociadoEmpresa> AssociadoEmpresas { get; set; }
    }
}
