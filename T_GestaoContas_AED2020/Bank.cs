using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_GestaoContas_AED2020
{
    class Bank : Owner
    {
        // ATRIBUTOS
        private List<Owner> owners;
        private List<Account> accounts;
        private Company company;

        public Bank()
        {
            owners = new List<Owner>();
            accounts = new List<Account>();
            company = new Company();
        }

        // ABRIR UMA NOVA CONTA NO BANCO
        public bool OpenNewAccount(long nib, double inicialBalance, Owner[] owners)
        {
            var account = new Account();
            foreach (var owner in owners)
            {                                                               // CASO NAO EXISTA NENHUM TITULAR
                if (!this.owners.Contains(owner)) this.owners.Add(owner);   // ADICIONA ESSE TITULAR
                account.AddOwner(owner);
            }                                                               // UPDATE DE DADOS
            account.Balance = inicialBalance;
            account.Nib = nib;
            this.accounts.Add(account);
            return false;
        }

        // LEVANTAMENTOS
        public void Withdraw(long nib, double amount)
        {
            for (int i = 0; i < accounts.Count; i++)        // PERCORRE LISTA DE CONTAS
            {
                if (accounts[i].Nib.Equals(nib))            // ENCONTRA O NIB
                    if (accounts[i].Owners.Length != 0)     // TEM TITULAR VALIDO
                        if (accounts[i].Balance > amount)
                            accounts[i].Balance -= amount;  // LEVANTA
                        else accounts[i].Balance = 0;
            }
        }

        // DEPOSITOS
        public void Deposit(long nib, double amount)
        {
            for (int i = 0; i < accounts.Count; i++)        // PERCORRE LISTA DE CONTAS
            {
                if (accounts[i].Nib.Equals(nib))            // ENCONTRA O NIB
                    if (accounts[i].Owners.Length != 0)     // TEM TITULAR VALIDO
                        accounts[i].Balance += amount;      // DEPOSITA
            }
        }

        // VERIFICA SE EXISTEM CONTAS COM SALDO NEGATIVO
        public string NegativeBalanceAccounts()
        {
            Console.WriteLine();
            foreach (var account in accounts)                                           // PERCORRE TODAS AS CONTAS DO BANCO
            {
                if(account.Balance < 0)                                                 // CASO EXISTA ALGUMA COM SALDO NEGATIVO
                    Console.WriteLine(" NIB: {0}\n Type: {2}\n Balance: {1} euros\n", account.Nib, account.Balance, account.Type);
                else
                    Console.WriteLine(" Searching for accounts with negative balance...\n");     // CASO TODAS AS CONTAS TENHAM SALDO POSITIVO
            }
            Console.WriteLine();
            return string.Format("");
        }

        // LISTAR TODAS AS CONTAS DO BANCO
        public string ListAllAccounts()
        {
            foreach (var account in accounts)
            {
                Console.WriteLine(account);
            }
            return string.Format("");
        }

        // TRANFERENCIAS ENTRE CONTAS 
        public void TransferBetweenAccounts(long nib1, long nib2, double amount)
        {
            for (int i = 0; i < accounts.Count; i++) {
                if (accounts[i].Nib.Equals(nib1) && accounts[i].Owners.Length != 0) {    // ENCONTRA UMA CONTA VALIDA COMPARADA COM O NIB1
                    foreach (var item in accounts) {                                     
                        if (item.Nib.Equals(nib2) && item.Owners.Length != 0) {         // ENCONTRA UMA CONTA VALIDA COMPARADA COM O NIB2
                            item.Balance += amount;
                        }
                    }
                    accounts[i].Balance -= amount;
                }
            }
        }

        // PAGAMENTOS DE SERVIÇO
        public void ServicePayments(long nib, long entity, long reference, double amount, Company company)
        {
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].Nib.Equals(nib) && accounts[i].Owners.Length != 0)
                {
                    accounts[i].Balance -= amount;
                    company.CompanyBalance += amount;
                }
            }
        }

        ////public override string ToString()
        ////{
        ////    StringBuilder res = new StringBuilder();
        ////    foreach (var account in accounts)
        ////    {
        ////        res.Append(account);
        ////    }
        ////    return res.ToString();
        ////}


        // PAGAMENTOS AUTOMATICOS

    } // END CLASS
} 
