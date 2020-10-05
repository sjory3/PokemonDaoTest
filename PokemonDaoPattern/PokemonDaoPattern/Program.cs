using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonDaoPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            PokemonDao pokemonDao = new PokemonDaoimpl();


            Pokemon pokemon = pokemonDao.GetPokemonOnId(3);
            Console.WriteLine(pokemon.GetName());
            Console.WriteLine(pokemon.GetNumber());
            Console.WriteLine(pokemon.GetType1());
            Console.WriteLine(pokemon.GetType2());

            Console.ReadLine();

        }
    }
}
