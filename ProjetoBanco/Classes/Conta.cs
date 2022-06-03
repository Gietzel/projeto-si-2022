using ProjetoBanco.Classes;
using System;

namespace ProjetoBanco.Classes
{
	public abstract class Conta // tem q ser abstract
	{
		public Conta(Cliente cliente, decimal saldo)
		{
			if (!cliente.EhMaiorIdade)
				throw new Exception("Você não tem idade sufciente para criar uma conta :/");

			Cliente = cliente;
			Saldo = saldo;
		}

		public decimal _saldo;

		public int Idade { get; private set; }

		public string NumConta { get; private set; }

		public Cliente Cliente { get; private set; }

		public string MensagemTransacao { get; set; }

		public decimal Saldo
		{
			get { return _saldo; }
			protected set
			{
				if (value >= 0)
					_saldo = value;
				else
					_saldo = 0;
			}
		}

        public abstract bool Sacar(decimal valorSaque);

        public abstract bool Depositar(decimal valorDeposito);

        public void Transferir(decimal valorTransferencia, Conta destino)
        {
            var sucessoTransacaoSaque = Sacar(valorTransferencia);
            var sucessoTransacaoDeposito = destino.Depositar(valorTransferencia);

            if (sucessoTransacaoSaque && sucessoTransacaoDeposito)
            {
                MensagemTransacao = $"Valor do depósito é inválido!";
            }

        }

        public void GerarNumConta()
		{
			Random generator = new Random();
			var x = generator.Next(0, 1000000);
			NumConta = x.ToString("00000-0");
		}
	}
}