using _01_ByteBank.Exceptions;
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

            try 
            {
                ContaCorrente conta = new ContaCorrente(74740,4545);
                ContaCorrente conta2 = new ContaCorrente(747421, 45);

                //conta.Transfer(10000, conta2);
                conta.Withdraw(1000);
    
                Console.ReadLine();
            }
            catch(FinancialOperationException ex) 
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            Console.ReadLine();
        }
    }
}
