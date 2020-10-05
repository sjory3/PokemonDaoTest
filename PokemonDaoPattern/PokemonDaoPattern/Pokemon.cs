using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonDaoPattern
{
    class Pokemon
    {
        private string name;
        private int number;
        private string type1;
        private string type2;

        public Pokemon(string name, int number, string type1, string type2)
        {
            this.name = name;
            this.number = number;
            this.type1 = type1;
            this.type2 = type2;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }
        public int GetNumber()
        {
            return number;
        }

        public void SetNumber(int number)
        {
            this.number = number;
        }
        public string GetType1()
        {
            return type1;
        }

        public void SetType1(string type1)
        {
            this.type1 = type1;
        }
        public string GetType2()
        {
            return type2;
        }

        public void SetType2(string type2)
        {
            this.type2 = type2;
        }
    }

    
}
