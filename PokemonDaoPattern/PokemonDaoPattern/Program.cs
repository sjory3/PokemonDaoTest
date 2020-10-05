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
            //instansiating pokemonDao to call the methods
            PokemonDao pokemonDao = new PokemonDaoimpl();

            //making a test pokemon for adding to the database
            Pokemon ven = new Pokemon("Venusaur", 3, "Grass", "Poison");
            pokemonDao.AddPokemon(ven);

            //making a test on the get pokemon method from database
            Pokemon pokemon = pokemonDao.GetPokemonOnId(3);
            Console.WriteLine(pokemon.GetName());
            Console.WriteLine(pokemon.GetNumber());
            Console.WriteLine(pokemon.GetType1());
            Console.WriteLine(pokemon.GetType2());

            //making a test to delete from database
            pokemonDao.DeletePokemonOnId(3);

            Console.ReadLine();

        }
    }
}
