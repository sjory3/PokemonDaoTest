using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonDaoPattern
{
    interface PokemonDao
    {
        //interface with the diffrent method the classes that inherrent this need to have
        List<Pokemon> GetAllPokemons();
        Pokemon GetPokemonOnId(int number);
        void AddPokemon(Pokemon pokemon);
        void DeletePokemonOnId(int number);
    }
}
