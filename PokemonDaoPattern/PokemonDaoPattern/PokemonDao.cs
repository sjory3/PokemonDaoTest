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
        Pokemon GetPokemonOnId(int number);
        void AddPokemon(Pokemon pokemon);
        void DeletePokemon(Pokemon pokemon);
    }
}
