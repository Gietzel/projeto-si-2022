using ProjetoBanco.Classes;
using System;
using System.Globalization;

namespace ProjetoBanco
{
    class Program
    {
        static void Main()
        {

            try
            {
                Console.WriteLine("Digite seu nome:\n");
                var nome = Console.ReadLine();
                Console.WriteLine("Digite sua idade:\n");
                var _idade = Console.ReadLine();
                Console.WriteLine("Digite seu endereço:\n");
                var endereco = Console.ReadLine();
                Console.WriteLine("Digite seu número de telefone:\n");
                var _telefone = Console.ReadLine();
                Console.WriteLine("Digite seu CPF (apenas digitos):\n");
                var cpf = Console.ReadLine();
                Console.WriteLine("Digite sua data de nascimento (DD/MM/AAAA):\n");
                var _dataNascimento = Console.ReadLine();

                // conversões
                int idade = Int32.Parse(_idade);
                long telefone = long.Parse(_telefone);
                DateTime dataNascimento = DateTime.ParseExact(_dataNascimento, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                var cliente = Cliente.CreateCliente(nome, idade, endereco, telefone, cpf, dataNascimento);
                Console.WriteLine(cliente.ToString());

                var conta = new Conta(cliente, 10000); // instanciar cliente e n conta pois conta n pode ser instanciada por ser abstrata
                conta.GerarNumConta();

                Console.WriteLine(conta.NumConta);


                contaPoupanca.Transferir(500, contaCorrente);

                List<Conta> contas = new List<Conta>() { contaPoupanca, contaCorrente };

                var contaPoupanca = new Poupanca(cliente, numConta, 10000);
                Console.WriteLine(contaPoupanca.Saldo);

                contaPoupanca.Depositar(1000);
                Console.WriteLine(contaPoupanca.Saldo);

                contaPoupanca.Sacar(500);
                Console.WriteLine(contaPoupanca.Saldo);

                var contaCorrente = new ContaCorrente(cliente, numConta, 10000);
                Console.WriteLine(contaCorrente.Saldo);

                contaCorrente.Depositar(1400);
                Console.WriteLine(contaCorrente.Saldo);

                contaCorrente.Sacar(200);
                Console.WriteLine(contaCorrente.Saldo);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}