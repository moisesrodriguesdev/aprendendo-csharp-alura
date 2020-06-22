using _01_ByteBank.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ByteBank
{
    public class ContaCorrente
    {
        public  Cliente Titular { get; set; }

        private int Agencia { get; } 

        private int Numero { get; }    
        private double _saldo;

        public static double TaxaOperacao;

        // Propriedade que pertence somente a classe, todos os objetos compartilham dessa informação
        public static int TotalDeContasCriadas {  get; private set; }

        public int CountWithdrawalsNotAllowed { get; private set; }
        public int CountTransferNotAllowed { get; private set; }

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }
        public ContaCorrente(int NumeroAgencia, int NumeroConta)
        {

            if (NumeroAgencia <= 0)
            {
                throw new ArgumentException("Agencia deve ser maior que 0", nameof(NumeroAgencia));
            }


            if (NumeroConta <= 0)
            {
                throw new ArgumentException("Numero deve ser maior que 0", nameof(NumeroConta));
            }

            Agencia = NumeroAgencia;
            Numero = NumeroConta;

            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;

        }

        public static int GetTotalDeContasCriadas()
        {
            return TotalDeContasCriadas;
        }


        public void Withdraw(Double value) 
        {
            if (value < 0)
            {
                throw new ArgumentException("Valor inválido para o saque", nameof(value));
            }

            if (_saldo < value)
            {
                CountWithdrawalsNotAllowed++;
                throw new InsufficientFundsException(Saldo, value);
            }

            _saldo -= value;
            
        }

        public void Deposit(Double value)
        {
            _saldo += value;
        }

        public void Transfer(double value, ContaCorrente destinyAccount)
        {
            if (value < 0)
            {
                throw new ArgumentException("Valor inválido para transferir", nameof(value));
            }

            try
            {
                Withdraw(value);
            }
            catch(InsufficientFundsException ex)
            {
                CountTransferNotAllowed++;
                throw new FinancialOperationException("Operação não realizada", ex);
            }
            
            destinyAccount.Deposit(value);
            
        }
    }
}
