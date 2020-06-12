using System;

namespace T_GestaoContas_AED2020
{
        // ENTIDADE E REFERENCIA
    class Company
    {
        // ATRIBUTOS
        private string name;
        private long entity;
        private long reference;
        private long minEnt = 9999;
        private long maxEnt = 99999;
        private long minRef = 99999999;
        private long maxRef = 999999999;

        // GETTERS & SETTERS
        public long Entity { get => entity; set => entity = value; }
        public long Reference { get => reference; set => reference = value; }
        public string Name { get => name; set => name = value; }

        public Company(string name)
        {
            this.name = name;
        }

        // GERAR UM NUMERO RANDOM COM 5 DIGITOS 
        public long GenerateEntity()
        {
            Random rand = new Random();
            long result = rand.Next((Int32)(minEnt >> 32), (Int32)(maxEnt >> 32));
            result = (result << 32);
            result = result | (long)rand.Next((Int32) minEnt, (Int32)maxEnt);
            return result;
        }

        // GERAR UM NUMERO RANDOM COM 9 DIGITOS
        public long GenerateReference()
        {
            Random rand = new Random();
            long result = rand.Next((Int32)(minRef >> 32), (Int32)(maxRef >> 32));
            result = (result << 32);
            result = result | (long) rand.Next((Int32)minRef, (Int32)maxRef);
            return result;
        }

    } // END CLASS
} 
