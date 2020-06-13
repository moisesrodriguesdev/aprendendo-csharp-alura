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
        private int Agencia { get; set; } 
        private int Numero { get; set; }    
        private double _saldo;

        // Propriedade que pertence somente a classe, todos os objetos compartilham dessa informação
        public static int TotalDeContasCriadas {  get; private set; }

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

        public static int GetTotalDeContasCriadas()
        {
            return TotalDeContasCriadas;
        }

        public ContaCorrente(int agencia, int numero)
        {
            Agencia = agencia;
            Numero = numero;
            TotalDeContasCriadas++;
        }

        public bool Withdraw(Double value) 
        {
            if (_saldo < value)
            {
                return false;
            }

            _saldo -= value;
            return true;
        }

        public void Deposit(Double value)
        {
            _saldo += value;
        }

        public bool Transfer(double value, ContaCorrente destinyAccount)
        {
            if (_saldo < value)
            {
                return false;
            }

            _saldo -= value;
            destinyAccount.Deposit(value);
            return true;
        }
    }
}
