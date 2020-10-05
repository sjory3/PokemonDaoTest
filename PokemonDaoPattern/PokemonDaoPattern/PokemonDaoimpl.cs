using System;
using System.Collections.Generic;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonDaoPattern
{
    class PokemonDaoimpl : PokemonDao
    {
        //getting the connection credentials
        static string connString = "Server=localhost;Database=pokemons;Uid=root;Pwd=root;";
        //making a connection to the MySql database with the connection string
        MySqlConnection conn = new MySqlConnection(connString);

        public PokemonDaoimpl()
        {

        }
        
        public void DeletePokemon(Pokemon pokemon)
        {
            throw new NotImplementedException();
        }

        public List<Pokemon> GetAllPokemons()
        {
            throw new NotImplementedException();
        }

        public Pokemon GetPokemonOnId(int number)
        {
            string element1 = "";
            string element2 = "";

            conn.Open();
            string cmdStringToPokemon = "Select pokemons.pokemon.pokemonName from pokemons.pokemon where pokemons.pokemon.id = "+number+";";
            MySqlCommand cmd = new MySqlCommand(cmdStringToPokemon, conn);
            string pokemonName = cmd.ExecuteScalar().ToString();

            cmd.CommandText = "select pokemons.pokemonelements.elementId from pokemons.pokemonelements where pokemons.pokemonelements.pokemonId = "+number+";";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    cmd.CommandText = "select pokemons.elements.element from pokemons.elements where pokemons.elements.id = " + reader.GetValue(i).ToString() + ";";
                    if (i == 0)
                    {
                        element1 = cmd.ExecuteScalar().ToString();
                    }
                    else
                    {
                        element2 = cmd.ExecuteScalar().ToString();
                    }
                }
            }
            conn.Close();
            Pokemon pokemon = new Pokemon(pokemonName, number,element1,element2);

            return pokemon;
        }

        public void AddPokemon(Pokemon pokemon)
        {
            //opens connection
            conn.Open();
            //saving the name and number into the pokemon table
            string cmdStringToPokemon = "insert into pokemons.pokemon Values(" + pokemon.GetNumber() + ", '" + pokemon.GetName() + "');";
            MySqlCommand cmd = new MySqlCommand(cmdStringToPokemon, conn);
            cmd.ExecuteNonQuery();

            cmd.CommandText = "SELECT pokemons.elements.id from pokemons.elements where elements.element = '" + pokemon.GetType1() + "';";
            int type1 = int.Parse(cmd.ExecuteScalar().ToString());

            cmd.CommandText= "SELECT pokemons.elements.id from pokemons.elements where elements.element = '" + pokemon.GetType2() + "';";
            int type2 = int.Parse(cmd.ExecuteScalar().ToString());

            cmd.CommandText = "insert into pokemons.pokemonelements values(" + pokemon.GetNumber() + "," + type1 + ");";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "insert into pokemons.pokemonelements values(" + pokemon.GetNumber() + "," + type2 + ");";
            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}
