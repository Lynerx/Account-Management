using System;

namespace T_GestaoContas_AED2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n ==============  BANK  ============== ");
            
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
            Account account01 = new Account { Nib = 0036001, Type = Type.Order,  Owners = new Owner[] { tiagoLino, vascoQuelhas, nelsonRodr } };
            Account account02 = new Account { Nib = 0036002, Type = Type.LongTerm,  Owners = new Owner[] { marioSilva, andrePinto, mariaPonte } };
            Account account03 = new Account { Nib = 0036003, Type = Type.Saving,  Owners = new Owner[] { pedroSilv} };
            Account account04 = new Account { Nib = 0036004, Type = Type.Order,  Owners = new Owner[] { diogoZe, telmaMont} };

                // ADICIONAR AS CONTAS NO BANCO  
            bank.OpenNewAccount(account01.Nib, 16821.36, account01.Owners);
            bank.OpenNewAccount(account02.Nib, -4822.21, account02.Owners);
            bank.OpenNewAccount(account03.Nib, 981.48, account03.Owners);
            bank.OpenNewAccount(account04.Nib, -5004.32, account04.Owners);

            bool flag = true;

            while (flag)
            {
                Console.WriteLine(" > Escolha uma opção: ");
                Console.WriteLine(" 1 - Listar todas as contas do Banco");
                Console.WriteLine(" 2 - Detalhes de uma conta espefícica");
                Console.WriteLine(" 3 - Listar todas as contas com saldo negativo");
                Console.WriteLine(" 4 - Transferência entre contas");
                Console.WriteLine(" 5 - Pagamento de serviços");
                Console.WriteLine(" 6 - Sair");
                Console.Write(" -> ");

                int menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        // LISTAR TODAS AS CONTAS DO BANCO
                        bank.ListAllAccounts();
                        Console.WriteLine("..........................................................");
                        break;

                    case 2:
                        // DETALHES DA UMA CONTA ESPECIFICA
                        Console.Write("Introduza o NIB: ");
                        long nibInput = long.Parse(Console.ReadLine());
                        bank.AccountDetails(nibInput);
                        Console.WriteLine("..........................................................");
                        break;

                    case 3:
                        // LISTAR TODAS AS CONTAS COM SALDO NEGATIVO
                        bank.NegativeBalanceAccounts();
                        Console.WriteLine("..........................................................");
                        break;

                    case 4:
                        // TRANSFERENCIA ENTRE CONTAS (NIB1, NIB2, QUANTIA) 
                        Console.Write("Introduza NIB conta origem: ");
                        long nibInputOrigem = long.Parse(Console.ReadLine());
                        Console.Write("Introduza NIB conta destino: ");
                        long nibInputDestino = long.Parse(Console.ReadLine());
                        Console.Write("Introduza montante: ");
                        long montante = long.Parse(Console.ReadLine());
                        bank.TransferBetweenAccounts(nibInputOrigem, nibInputDestino, montante);
                        Console.WriteLine("..........................................................");
                        break;

                    case 5:
                        // INSTANCIAR COMPANHIA QUE TEM ENTIDADE E REFERENCIA
                        Company companyNOS = new Company("NOS");
                        long entity = companyNOS.GenerateEntity();
                        long reference = companyNOS.GenerateReference();

                        Company companyVodafone = new Company("Vodafone");
                        long entity1 = companyNOS.GenerateEntity();
                        long reference1 = companyNOS.GenerateReference();

                        Console.WriteLine();
                        Console.WriteLine("Pagar a " + companyNOS.Name + ": ");
                        Console.WriteLine("Entidade: " + entity);
                        Console.WriteLine("Referência: " + reference);
                        Console.WriteLine();

                        Console.WriteLine("Pagar a " + companyVodafone.Name + ": ");
                        Console.WriteLine("Entidade: " + entity1);
                        Console.WriteLine("Referência: " + reference1);
                        Console.WriteLine();

                        Console.Write("Introduza NIB: "); long nib2 = long.Parse(Console.ReadLine());
                        Console.Write("Introduza a entidade: "); long ent = long.Parse(Console.ReadLine());
                        Console.Write("Introduza a referencia: "); long refe = long.Parse(Console.ReadLine());
                        Console.Write("Montante: "); double mont = double.Parse(Console.ReadLine());
                        // FAZER UM PAGAMENTO DE SERVIÇOS 
                        bank.ServicePayments(nib2, ent, refe, mont);
                        Console.WriteLine("..........................................................");
                        break;

                    case 6:
                        flag = false;
                        break;
                    default:
                        break;
                }
            }

        } // END PROGRAM
    }
}
