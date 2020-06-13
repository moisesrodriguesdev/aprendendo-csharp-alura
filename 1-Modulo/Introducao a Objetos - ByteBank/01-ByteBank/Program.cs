using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Cliente moises = new Cliente();
       
            ContaCorrente conta = new ContaCorrente(5445, 54518-4);
            conta.Titular = moises;
            conta.Saldo = 150;

            Console.WriteLine("Nome do titular" + conta.Titular.Nome);
            Console.WriteLine("Total de contas criada: " + ContaCorrente.GetTotalDeContasCriadas());
            Console.ReadLine();
        }
    }
}
