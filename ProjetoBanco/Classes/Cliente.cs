using System;
using System.Linq;

namespace ProjetoBanco.Classes
{
    public class Cliente : Conta
    {
        private Cliente()
        { }

        public string Nome { get; private set; }

        public int Idade { get; private set; }

        public string Endereco { get; private set; }

        public long Telefone { get; private set; }

        public string CPF { get; private set; }

        public DateTime DataNascimento { get; private set; }

        public string NumConta { get; private set; }

        public decimal Saldo { get; private set; }

        public int Score { get; private set; }

        public bool EhMaiorIdade => ValidarSeClienteEMaiorDeIdade();

        public static Cliente CreateCliente(string nome, int idade, string endereco, long telefone, string cpf, DateTime dataNascimento)
        {
            return new Cliente { Nome = nome, Idade = idade, Endereco = endereco, Telefone = telefone, CPF = cpf, DataNascimento = dataNascimento, Saldo = 0, Score = 0 };
        }

        public override bool Depositar(decimal valorDeposito)
        {
            throw new NotImplementedException();
        }

        public override bool Sacar(decimal valorSaque)
        {
            throw new NotImplementedException();
        }

        public override string ToString() => $"Nome: {Nome} | Documento: {CPF} | Data de Nascimento: {DataNascimento} --- Sobrecrita de: { base.ToString()}";

        private bool ValidarSeClienteEMaiorDeIdade() => DateTime.Now.Year - DataNascimento.Year >= 18;

    }

}