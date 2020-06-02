using System;

namespace T_GestaoContas_AED2020
{
    public enum Gender { Male, Female }
    class Owner 
    {
        // ATRIBUTOS 
        private string name;
        private long nif;
        private DateTime birthDate;
        private Gender gender;

        // GETS & SETS
        public string Name { get => name; set => name = value; }
        public long Nif { get => nif; set { if (value >= 0) nif = value; else throw new Exception("Invalid NIF "); } }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public Gender Gender { get => gender; set => gender = value; }

        // CONSTRUTOR DEFAULT
        public Owner()
        {
            this.name = Name;
            this.nif = Nif;
            this.birthDate = BirthDate;
            this.gender = Gender;
        }

        // CONSTRUTOR 
        public Owner(string name, long nif, DateTime birthDate, Gender gender) 
        {
            Name = name;
            Nif = nif;
            BirthDate = birthDate;
            Gender = gender;
        }

        // LISTAR TITULARES
        public string ListOwners()
        {
            return string.Format(" Name: {0} \n NIF: {1} \n Birth Date: {2} \n Gender: {3}", Name, Nif, BirthDate, Gender);
        }


    } // END CLASS
} 
