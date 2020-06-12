using System;
using System.Text;

namespace T_GestaoContas_AED2020
{
    // TIPOLOGIAS DE CONTAS - ORDEM, PRAZO E POUPANÇA
    public enum Type { Order, LongTerm, Saving }
    class Account 
    {
        // ATRIBUTOS
        private Owner[] owners;
        private short maxOwners = 3;
        private double balance;
        private long nib;
        private Type type;

        // GETS & SETS
        public double Balance { get => balance; set => balance = value; }
        public long Nib { get => nib; set => nib = value; }
        internal Owner[] Owners { get => owners; set => owners = value; }
        public Type Type { get => type; set => type = value; }

        // CONSTRUTOR DEFAULT
        public Account()
        {
            owners = new Owner[maxOwners];
            balance = 0;
        }
        
        // ADICIONA UM TITULAR A CONTA 
        public bool AddOwner(Owner t)
        {
            if (owners[0] == null)                                                          // CASO NÃO EXISTA O TITULAR #1 
                owners[0] = t;
            else if (owners[1] == null && !owners[0].Equals(t))                             // CASO NÃO EXISTA TITULAR #2 E NÃO FOR O MESMO QUE O #1
                owners[1] = t;
            else if (owners[2] == null && (!owners[0].Equals(t) || !owners[1].Equals(t)))   // CASO NÃO EXISTA O TITULAR #3 E SEJA DIFERENTE DO #1 E DO #2
                owners[2] = t;
            return false;
        }

        // REMOVER UM TITULAR
        public bool RemoveOwner(Owner t)
        {
            if (owners[0] == t)         // REMOVE O #1 TITULAR
            {
                owners[0] = owners[1];  // O TITULAR #2 PASSA PARA #1 TITULAR
                owners[1] = owners[2];  // O TITULAR #3 PASSA PARA #2 TITULAR
                owners[2] = null;       // O TITULAR #3 VAI FICAR VAZIO    
            }
            else if (owners[1] == t)    // REMOVE O #2 TITULAR
            {
                owners[1] = owners[2];  // O TITULAR #3 PASSA PARA #2 TITULAR
                owners[2] = null;       // O TITULAR #3 VAI FICAR VAZIO
            }
            else if (owners[2] == t)    // REMOVE O #3 TITULAR
            {
                owners[2] = null;       // O TITULAR #3 VAI FICAR VAZIO
            }
            return false;
        }

        //DETALHES DE UMA DETERMINADA CONTA INVOCADA PELA CLASSE BANCO
        public string AccountDetails()
        {
            Console.WriteLine("\n#############  ACCOUNT DETAILS  #############\n");
            for (int i = 0; i < maxOwners; i++)                                                    // PERCORRE TODOS OS TITULARES DE UMA CONTA
            {
                if (i >= 0 && owners[i] != null)
                    Console.WriteLine(" > OWNER DATA #" + (i + 1) + "\n" + owners[i].ListOwners()); // IMPRIME OS DADOS DOS TITULARES
                Console.WriteLine();
            }
            return string.Format("");                           
        }


        // IMPRIMIR RESULTADOS
        public override string ToString() 
        {
            StringBuilder res = new StringBuilder();
            res.AppendLine(string.Format("\n############# ACCOUNT #############  \n"));
            res.AppendLine(string.Format(" NIB: {0}\n Balance: {1} euros\n Type: {2}\n", Nib, Balance, type));
            for (int i = 0; i < maxOwners; i++)
            {
                if (owners[i] != null)
                    res.AppendLine(string.Format("--------[OWNER DATA #" + (i + 1) + "]---------\n{0}", owners[i].ListOwners()));
            }
            res.AppendLine(string.Format("___________________________________\n"));
            return res.ToString();
        }

    } // END CLASS

} 
