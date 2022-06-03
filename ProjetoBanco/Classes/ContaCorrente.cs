using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBanco.Classes
{
    class ContaCorrente : Conta
    {
        public ContaCorrente(Cliente cliente, decimal saldo)
            : base(cliente, saldo)
        { }

        public override bool Depositar(decimal valorDeposito)
        {
            if (valorDeposito <= 0)
            {

                MensagemTransacao = $"Valor do depósito é inválido!";
                return false;
            }

            Saldo += Saldo + (valorDeposito + 0.5m);

            MensagemTransacao = $"Depósito de {valorDeposito} efetuado com sucesso!";

            return true;
        }

        public override bool Sacar(decimal valorSaque)
        {
            if (Saldo <= 0m)
            {
                MensagemTransacao = $"O saldo é insuficiente para saque, sua conta está com o valor atual de: {Saldo}";
                return false;
            }

            if (Saldo < valorSaque)
            {
                MensagemTransacao = $"Valor solicitado para saque , seu saldo atual é de: {Saldo}";
                return false;
            }

            Saldo -= valorSaque + 0.1m;
            return true;
        }
    }
}
