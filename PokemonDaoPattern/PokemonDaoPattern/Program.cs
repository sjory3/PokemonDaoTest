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

            foreach(Pokemon pokemon in pokemonDao.GetAllPokemons())
            {
                Debug.WriteLine("Pokemon : #" + pokemon.GetNumber() + ", Name : " + pokemon.GetName());
            }

            Pokemon pokemon1 = pokemonDao.GetAllPokemons().ElementAt(0);
            pokemon1.SetName("not bulabusaure");
            pokemonDao.UpdatePokemon(pokemon1);

            pokemonDao.GetPokemon(0);
            Debug.WriteLine("Pokemon : #" + pokemon1.GetNumber() + ", Name : " + pokemon1.GetName());
        }
    }
}
