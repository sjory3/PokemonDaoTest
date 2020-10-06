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

            
            //testing the delete option
            pokemonDao.DeletePokemonOnId(1);
            pokemonDao.DeletePokemonOnId(2);

            //making a test pokemon for adding to the database
            Pokemon poke1 = new Pokemon("Bulbasaur", 1, "Grass", "Poison");
            pokemonDao.AddPokemon(poke1);

            Pokemon poke2 = new Pokemon("Ivysaur", 2, "Grass", "Poison");
            pokemonDao.AddPokemon(poke2);

            

            //making a test on the get pokemon method from database
            Pokemon pokemon = pokemonDao.GetPokemonOnId(2);
            Debug.WriteLine("----------GET ONE--------------");
            Debug.WriteLine("Name   : " + pokemon.GetName());
            Debug.WriteLine("ID     : " + pokemon.GetNumber());
            Debug.WriteLine("Type 1 : " + pokemon.GetType1());
            Debug.WriteLine("Type 2 : " + pokemon.GetType2());
            Debug.WriteLine("------------------------------");

            //testing the get all pokemons
            List<Pokemon> pokemons = new List<Pokemon>();
            pokemons = pokemonDao.GetAllPokemons();

            Debug.WriteLine("---------------------------------------------\n" +
                            "--------------------GET ALL------------------\n" +
                            "---------------------------------------------");

            foreach (Pokemon pok in pokemons)
            {
                Debug.WriteLine("------------------------------");
                Debug.WriteLine("Name   : " + pok.GetName());
                Debug.WriteLine("ID     : " + pok.GetNumber());
                Debug.WriteLine("Type 1 : " + pok.GetType1());
                Debug.WriteLine("Type 2 : " + pok.GetType2());
                Debug.WriteLine("------------------------------");
            }
        }
    }
}
