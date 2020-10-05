using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonDaoPattern
{
    interface PokemonDao
    {
        List<Pokemon> GetAllPokemons();
        Pokemon GetPokemon(int number);
        void UpdatePokemon(Pokemon pokemon);
        void DeletePokemon(Pokemon pokemon);
    }
}
