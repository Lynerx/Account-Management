using System;
using System.Collections.Generic;
/**
 *  Tiago Lino - 32727
 *  Vasco Quelhas - 32362
 */
namespace T_GestaoContas_AED2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n ==============  BANCO  ============== ");

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
            Account account01 = new Account { Nib = 0036001, Owners = new Owner[] { tiagoLino, vascoQuelhas, nelsonRodr } };
            Account account02 = new Account { Nib = 0036002, Owners = new Owner[] { marioSilva, andrePinto, mariaPonte } };
            Account account03 = new Account { Nib = 0036003, Owners = new Owner[] { pedroSilv} };
            Account account04 = new Account { Nib = 0036004, Owners = new Owner[] { diogoZe, telmaMont} };

                // ADICIONAR AS CONTAS NO BANCO  
            bank.OpenNewAccount(account01.Nib, 16821.36, account01.Owners, Type.Order);
            bank.OpenNewAccount(account02.Nib, -4822.21, account02.Owners, Type.LongTerm);
            bank.OpenNewAccount(account03.Nib, 981.48, account03.Owners, Type.Saving);
            bank.OpenNewAccount(account04.Nib, -5004.32, account04.Owners, Type.Order);

                // QUEUE DAS ULTIMAS TRANSAÇÕES 
            Queue<string> lastTransactions = new Queue<string>(50);

            bool flag = true;

            while (flag)
            {
                Console.WriteLine(" > Escolha uma opção: ".ToUpper());
                Console.WriteLine(" 1 - Depositar".ToUpper());
                Console.WriteLine(" 2 - Levantar".ToUpper());
                Console.WriteLine(" 3 - Listar todas as contas do Banco".ToUpper());
                Console.WriteLine(" 4 - Detalhes de uma conta espefícica".ToUpper());
                Console.WriteLine(" 5 - Listar todas as contas com saldo negativo".ToUpper());
                Console.WriteLine(" 6 - Transferência entre contas".ToUpper());
                Console.WriteLine(" 7 - Pagamento de serviços".ToUpper());
                Console.WriteLine(" 8 - Ultimas transações".ToUpper());
                Console.WriteLine(" 9 - Listar todas as informações dos titulares".ToUpper());
                Console.WriteLine(" 10 - Sair".ToUpper());
                Console.Write(" -> ");

                int menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                            // DEPOSITAR
                        Console.Write("\n>> Introduza NIB da conta a depositar: ".ToUpper());
                        long nibDeposit = long.Parse(Console.ReadLine());

                        Console.Write(">> Montante a depositar: ".ToUpper());
                        double depositAmount = double.Parse(Console.ReadLine());

                        bank.Deposit(nibDeposit, depositAmount);
                        lastTransactions.Enqueue(">> Deposito | Montante: ".ToUpper() + depositAmount);

                        Console.WriteLine();
                        Console.WriteLine("..........................................................\n");
                        break;

                    case 2:
                            // LEVANTAR
                        Console.Write("\n>> Introduza NIB da conta a levantar: ".ToUpper());
                        long nibWithdraw = long.Parse(Console.ReadLine());

                        Console.Write(">> Montante a levantar: ".ToUpper());
                        double withdrawAmount = double.Parse(Console.ReadLine());

                        bank.Withdraw(nibWithdraw, withdrawAmount);

                        lastTransactions.Enqueue(">> Levantamento | Montante: ".ToUpper() + withdrawAmount);

                        Console.WriteLine();
                        Console.WriteLine("..........................................................\n");
                        break;

                    case 3:
                            // LISTAR TODAS AS CONTAS DO BANCO
                        bank.ListAllAccounts();
                        Console.WriteLine("..........................................................\n");
                        break;

                    case 4:
                            // DETALHES DA UMA CONTA ESPECIFICA
                        Console.Write(">> Introduza o NIB: ".ToUpper());
                        long nibInput = long.Parse(Console.ReadLine());

                        bank.SearchAccountDetails(nibInput);
                        Console.WriteLine("..........................................................\n");
                        break;

                    case 5:
                            // LISTAR TODAS AS CONTAS COM SALDO NEGATIVO
                        bank.NegativeBalanceAccounts();
                        Console.WriteLine("..........................................................\n");
                        break;

                    case 6:
                            // TRANSFERENCIA ENTRE CONTAS (NIB1, NIB2, QUANTIA) 
                        Console.Write("\n>> Introduza NIB conta origem: ".ToUpper());
                        long nibInputOrigem = long.Parse(Console.ReadLine());

                        Console.Write(">> Introduza NIB conta destino: ".ToUpper());
                        long nibInputDestino = long.Parse(Console.ReadLine());

                        Console.Write(">> Introduza montante: ".ToUpper());
                        long montante = long.Parse(Console.ReadLine());

                        bank.TransferBetweenAccounts(nibInputOrigem, nibInputDestino, montante);

                            // ADICIONAR A QUEUE
                        lastTransactions.Enqueue((">> NIB Origem: " + nibInputOrigem + " | NIB Destino: " + nibInputDestino + " | Montante: " + montante).ToUpper());
                        Console.WriteLine(" (Transfência com sucesso)".ToUpper());
                        Console.WriteLine("..........................................................\n");
                        break;

                    case 7:
                            // INSTANCIAR COMPANHIA QUE TEM ENTIDADE E REFERENCIA
                        Company companyNOS = new Company("NOS");
                        long entity = companyNOS.GenerateEntity();
                        long reference = companyNOS.GenerateReference();

                        Company companyVodafone = new Company("Vodafone".ToUpper());
                        long entity1 = companyNOS.GenerateEntity();
                        long reference1 = companyNOS.GenerateReference();

                        Console.WriteLine();
                        Console.WriteLine(" [ Pagar a ".ToUpper() + companyNOS.Name + " ]");
                        Console.WriteLine(">> Entidade: ".ToUpper() + entity);
                        Console.WriteLine(">> Referência: ".ToUpper() + reference);
                        Console.WriteLine();

                        Console.WriteLine(" [ Pagar a ".ToUpper() + companyVodafone.Name + " ]");
                        Console.WriteLine(">> Entidade: ".ToUpper() + entity1);
                        Console.WriteLine(">> Referência: ".ToUpper() + reference1);
                        Console.WriteLine();

                        Console.Write(">> Introduza NIB: ".ToUpper()); long nib2 = long.Parse(Console.ReadLine());
                        Console.Write(">> Introduza a entidade: ".ToUpper()); long ent = long.Parse(Console.ReadLine());
                        Console.Write(">> Introduza a referencia: ".ToUpper()); long refe = long.Parse(Console.ReadLine());
                        Console.Write(">> Montante: ".ToUpper()); double mont = double.Parse(Console.ReadLine());

                        bank.ServicePayments(nib2, ent, refe, mont);
                        lastTransactions.Enqueue(">> Pagamento de serviços | Montante: ".ToUpper() + mont);

                        Console.WriteLine("..........................................................\n");
                        break;

                    case 8:
                            // IMPRIMIR QUEUE DAS ULTIMAS TRANSAÇÕES
                        Console.WriteLine("\n [ Ultimas transações ]  [ QUEUE ] \n".ToUpper());
                        foreach (var item in lastTransactions) { Console.WriteLine(item); }
                        Console.WriteLine();
                        Console.WriteLine("..........................................................\n");
                        break;

                    case 9:
                            // IMPRIMIR STACK DE TODAS AS INFORMAÇÕES DOS TITULARES
                        Console.WriteLine("\n [ Informação dos titulares ] [ STACK ]".ToUpper());
                        bank.GetOwnersInfoInStack();
                        Console.WriteLine("..........................................................\n");
                        break;

                    case 10:
                        flag = false;
                        break;

                    default:
                        break;
                }
            }

        } // END PROGRAM
    }
}
