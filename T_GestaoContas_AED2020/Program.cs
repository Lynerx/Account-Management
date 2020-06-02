using System;

namespace T_GestaoContas_AED2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n ==============  BANK DETAILS  ============== ");
            
                // INSTANCIAR O BANCO
            Bank bank = new Bank();

                // INSTANCIAR INFORMAÇÕES DE FUTUROS TITULARES
            Owner tiagoLino = new Owner { Name = "Tiago Lino", Nif = 357326562, BirthDate = new DateTime(1997, 02, 03), Gender = Gender.Male };
            Owner vascoQuelhas = new Owner { Name = "Vasco Quelhas", Nif = 654234554, BirthDate = new DateTime(1996, 10, 15), Gender = Gender.Male };
            Owner nelsonRodr = new Owner { Name = "Nelson Rodrigues", Nif = 235842352, BirthDate = new DateTime(2000, 01, 01), Gender = Gender.Male };
            Owner marioSilva = new Owner { Name = "Mario Silva", Nif = 455981002, BirthDate = new DateTime(1990, 01, 11), Gender = Gender.Male };
            Owner andrePinto = new Owner { Name = "André Pinto", Nif = 846021846, BirthDate = new DateTime(1995, 06, 17), Gender = Gender.Male };
            Owner mariaPonte = new Owner { Name = "Maria Ponte", Nif = 842014557, BirthDate = new DateTime(1997, 07, 28), Gender = Gender.Female };
            Owner pedroSilv = new Owner { Name = "Pedro Silveira", Nif = 574002941, BirthDate = new DateTime(1994, 03, 14), Gender = Gender.Male };
            Owner diogoZe = new Owner { Name = "Diogo Jose", Nif = 5846884004, BirthDate = new DateTime(1998, 05, 21), Gender = Gender.Male };
            Owner telmaMont = new Owner { Name = "Telma Monteiro", Nif = 889741506, BirthDate = new DateTime(2000, 08, 18), Gender = Gender.Female };
            Owner tiagoRodr = new Owner { Name = "Tiago Rodrigues", Nif = 012458497, BirthDate = new DateTime(1990, 11, 13), Gender = Gender.Male };

                // INSTANCIAR INFORMAÇÕES DE NOVAS CONTAS
            Account account01 = new Account { Nib = 003600000000000000001, Type = Type.Order,  Owners = new Owner[] { tiagoLino, vascoQuelhas, nelsonRodr } };
            Account account02 = new Account { Nib = 003600000000000000002, Type = Type.LongTerm,  Owners = new Owner[] { marioSilva, andrePinto, mariaPonte } };
            Account account03 = new Account { Nib = 003600000000000000003, Type = Type.Saving,  Owners = new Owner[] { pedroSilv} };
            Account account04 = new Account { Nib = 003600000000000000004, Type = Type.Order,  Owners = new Owner[] { diogoZe, telmaMont} };

                // ADICIONAR AS CONTAS NO BANCO  
            bank.OpenNewAccount(account01.Nib, 16821.36, account01.Owners);
            bank.OpenNewAccount(account02.Nib, -4822.21, account02.Owners);
            bank.OpenNewAccount(account03.Nib, 981.48, account03.Owners);
            bank.OpenNewAccount(account04.Nib, -5004.32, account04.Owners);


            // LISTAR TODAS AS CONTAS DO BANCO
            bank.ListAllAccounts();

            Console.WriteLine("..........................................................");

            // DETALHES DA UMA CONTA ESPECIFICA
            bank.AccountDetails(account01.Nib);
            bank.AccountDetails(account02.Nib);

            Console.WriteLine("..........................................................");

            // LISTAR TODAS AS CONTAS COM SALDO NEGATIVO
            bank.NegativeBalanceAccounts();

            Console.WriteLine("..........................................................");

            // TRANSFERENCIA ENTRE CONTAS (NIB1, NIB2, QUANTIA) 
            bank.TransferBetweenAccounts(account01.Nib, account02.Nib, 4822.21);
            bank.AccountDetails(account01.Nib);
            bank.AccountDetails(account02.Nib);

            Console.WriteLine("..........................................................");
            // INSTANCIAR COMPANHIA QUE TEM ENTIDADE E REFERENCIA
            Company companyNOS = new Company();
            long entity = companyNOS.GenerateEntity();
            long reference = companyNOS.GenerateReference();
            Console.WriteLine("Company balance: " + companyNOS.CompanyBalance + " euros.");
            Console.WriteLine("Entity: " + entity);
            Console.WriteLine("Referece: " + reference);
            // FAZER UM PAGAMENTO DE SERVIÇOS 
            bank.ServicePayments(account01.Nib, entity, reference, 3000, companyNOS);
            Console.WriteLine("Company balance: " + companyNOS.CompanyBalance + " euros.");
            Console.WriteLine("..........................................................");

           


        } // END PROGRAM
    }
}
