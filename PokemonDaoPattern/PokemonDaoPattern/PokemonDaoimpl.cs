using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonDaoPattern
{
    class PokemonDaoimpl : PokemonDao
    {
        List<Pokemon> pokemons;

        public PokemonDaoimpl()
        {
            pokemons = new List<Pokemon>();
            Pokemon pokemon1 = new Pokemon("Bulbasaur", 1, "Grass", "Poison");
            Pokemon pokemon2 = new Pokemon("Ivysaur", 2, "Grass", "Poison");
            pokemons.Add(pokemon1);
            pokemons.Add(pokemon2);
        }
        
        public void DeletePokemon(Pokemon pokemon)
        {
            pokemons.RemoveAt(pokemon.GetNumber());
            Debug.WriteLine("Pokemon : #" + pokemon.GetNumber() + " deleted from database");
        }

        public List<Pokemon> GetAllPokemons()
        {
            return pokemons;
        }

        public Pokemon GetPokemon(int number)
        {
            return pokemons[number];
        }

        public void UpdatePokemon(Pokemon pokemon)
        {
            pokemons[pokemon.GetNumber()].SetName(pokemon.GetName());
            Debug.WriteLine("Pokemon : #" + pokemon.GetNumber() + ", Updated in the database");
        }
    }
}
