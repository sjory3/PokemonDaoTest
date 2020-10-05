using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PokemonDaoPattern
{
    class Database
    {

        //getting the connection credentials from a file
        static string connString = "Server=localhost;Database=pokemons;Uid=root;Pwd=root;";
        //making a connection to the MySql database with the connection string
        MySqlConnection conn = new MySqlConnection(connString);

        public void OpenConnectionToMySqlDatabase()
        {
            //opens a connection
            conn.Open();
            //making sure the connection is open
            if (conn.State == System.Data.ConnectionState.Open)
            {
                Debug.WriteLine("Connection Open");
                return;
            }
            else
            {
                Debug.WriteLine("FAILED TO OPEN PORT");

            }
        }

        public void CloseConnectionToMySqlDatabase()
        {
            conn.Close();
            Debug.WriteLine("Connection Closed");
        }

        public void PostDataToDatabase(Pokemon pokemon)
        {
            //Command String for saving the name and id of the pokemon to the pokemon table
            string cmdStringToPokemon = "insert into pokemons.pokemon Values(" + pokemon.GetNumber() + ", '" + pokemon.GetName() + "');";
            //command for executing the string 
            MySqlCommand cmd = new MySqlCommand(cmdStringToPokemon, conn);
            //executing the string
            cmd.ExecuteNonQuery();
            //outputing that the pokemon was saved
            Debug.WriteLine("Saved to pokemon to pokemons.pokemon [database]");


            //command string for getting the element id from the elements table to use in the pokemonelements table
            string cmdStringGet = "SELECT pokemons.elements.id from pokemons.elements where elements.element = '" + pokemon.GetType1() + "';";
            //command for executing
            MySqlCommand cmd1 = new MySqlCommand(cmdStringGet, conn);
            //saving the response from the database to a string
            string result = cmd1.ExecuteScalar().ToString();
            //outputting that we got the data
            Debug.WriteLine("Gotten the ID for the pokemon type from the element table");

            //command string for getting the element id from the elements table to use in the pokemonelements table
            string cmdStringGet2 = "SELECT pokemons.elements.id from pokemons.elements where elements.element = '" + pokemon.GetType2() + "';";
            //command for executing
            MySqlCommand cmd3 = new MySqlCommand(cmdStringGet2, conn);
            //saving the response from the database to a string
            string result2 = cmd3.ExecuteScalar().ToString();
            //outputting that we got the data
            Debug.WriteLine("Gotten the ID for the pokemon type from the element table");



            //command string for saving the pokemonelements we save the pokemon id and the element id
            string cmdStringToPokemonElements = "insert into pokemons.pokemonelements values(" + pokemon.GetNumber() + "," + int.Parse(result) + ");";
            //command for execution
            MySqlCommand cmd2 = new MySqlCommand(cmdStringToPokemonElements, conn);
            //executing
            cmd2.ExecuteNonQuery();

            //command string for saving the pokemonelements we save the pokemon id and the element id
            string cmdStringToPokemonElements2 = "insert into pokemons.pokemonelements values(" + pokemon.GetNumber() + "," + int.Parse(result2) + ");";
            //command for execution
            MySqlCommand cmd4 = new MySqlCommand(cmdStringToPokemonElements2, conn);
            //executing
            cmd4.ExecuteNonQuery();
        }

        public void DeleteFromDatabase (int id)
        {
            //Command String for saving the name and id of the pokemon to the pokemon table
            string cmdStringToPokemon = "delete from pokemons.pokemonelements where pokemons.pokemonelements.pokemonId = "+id+";";
            //command for executing the string 
            MySqlCommand cmd = new MySqlCommand(cmdStringToPokemon, conn);
            //executing the string
            cmd.ExecuteNonQuery();
            //outputing that the pokemon was saved
            Debug.WriteLine("deleted pokemon from pokemons.pokemon [database]");


            //Command String for saving the name and id of the pokemon to the pokemon table
            string cmdStringToPokemon2 = "delete from pokemons.pokemon where pokemons.pokemon.id = " + id + ";";
            //command for executing the string 
            MySqlCommand cmd2 = new MySqlCommand(cmdStringToPokemon2, conn);
            //executing the string
            cmd2.ExecuteNonQuery();
            //outputing that the pokemon was saved
            Debug.WriteLine("deleted pokemon from pokemons.pokemon [database]");
        }










        /*
        public List<Pokemon> GetAllPokemons()
        {
            List<Pokemon> pokemons = new List<Pokemon>();
            int result;
            int pokemonNumber = 0;
            string pokemonName = "";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM pokemons.pokemon";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (IsPowerOfTwo(i))
                    {
                        Pokemon pokemon = new Pokemon(pokemonName, pokemonNumber, "", "");
                        pokemons.Add(pokemon);
                    }
                    if (int.TryParse(reader.GetString(i), out result))
                    {
                        pokemonNumber = int.Parse(reader.GetString(i));
                    }
                    else
                    {
                        pokemonName = reader.GetString(i);
                    }

                    Debug.WriteLine(reader.GetValue(i));

                }
            }
            Pokemon pokemon1 = new Pokemon(pokemonName, pokemonNumber, "", "");
            pokemons.Add(pokemon1);

            for (int i = 0; i < pokemons.Count; i++)
            {
                cmd.CommandText = "select pokemons.pokemonelements.elementId from pokemons.pokemonelements where pokemons.pokemonelements.pokemonId = "+pokemons[i].GetNumber()+";";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {

                    }
                }

            }

            return pokemons;

        }
        bool IsPowerOfTwo(int x)
        {
            return (x != 0) && ((x & (x - 1)) == 0);
        }
        */
    }
}
