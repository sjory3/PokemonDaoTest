using System;
using System.Collections.Generic;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PokemonDaoPattern
{
    //implements pokemon dao interface
    class PokemonDaoimpl : PokemonDao
    {
        //setting the connection credentials
        static string connString = "Server=localhost;Database=pokemons;Uid=root;Pwd=root;";
        //making a connection to the MySql database with the connection string
        MySqlConnection conn = new MySqlConnection(connString);

        /*
         * delete method
         * right now im useing a int to delete from and that corresponds to the pokemon number
         * i can change it to a pokemon obj but i felt it was easier to use a int for testing purposes
         */
        public void DeletePokemonOnId(int number)
        {
            //open the connection to the database
            conn.Open();
            //command string for sending commands
            Hvorfor bruger du ikke parametre?
            string cmdStringToPokemon = "delete from pokemons.pokemonelements where pokemons.pokemonelements.pokemonId = " + number + ";";
            //instanse of mysql command
            MySqlCommand cmd = new MySqlCommand(cmdStringToPokemon, conn);
            //executing the command string
            cmd.ExecuteNonQuery();

            //changing the command string to delete from another table
            cmd.CommandText = "delete from pokemons.pokemon where pokemons.pokemon.id = " + number + ";";
            //executing the query
            cmd.ExecuteNonQuery();

            Debug.WriteLine("[DELETED] #" + number);

            //closing the connection
            conn.Close();
        }


        public List<Pokemon> GetAllPokemons()
        {
            List<int> pokemonsNumbers = new List<int>();
            List<Pokemon> pokemons = new List<Pokemon>();

            conn.Open();
            string cmdString = "select pokemons.pokemon.id from pokemons.pokemon";
            MySqlCommand cmd = new MySqlCommand(cmdString, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            foreach (DataRow dr in dt.Rows)
            {
            //Dette er noget sjusk, du kan sagtens læse det hele ind på en gang, hvorfor så mange databasekald?
                pokemonsNumbers.Add(int.Parse(dr["id"].ToString()));
            }
            conn.Close();
            foreach (int number in pokemonsNumbers)
            {
                pokemons.Add(GetPokemonOnId(number));
            }

            return pokemons;

        }

        //getting the pokemon from diffrent tables then returning a pokemon object with the information
        public Pokemon GetPokemonOnId(int number)
        {
            //making the pokemon types string
            string element1 = "";
            string element2 = "";

            //open the connection to the database
            conn.Open();
            //making the command string
            string cmdStringToPokemon = "Select pokemons.pokemon.pokemonName from pokemons.pokemon where pokemons.pokemon.id = " + number + ";";
            //making the command
            MySqlCommand cmd = new MySqlCommand(cmdStringToPokemon, conn);
            //executing the command and getting the result 
            string pokemonName = cmd.ExecuteScalar().ToString();

            //changing the command string to getting the elements id from the pokemons id
            cmd.CommandText = "select pokemons.pokemonelements.elementId from pokemons.pokemonelements where pokemons.pokemonelements.pokemonId = " + number + ";";
            //making a data reader for getting data
            MySqlDataReader reader = cmd.ExecuteReader();
            //making a data table
            DataTable dt = new DataTable();
            //loading the result of the data reader into the datatable
            dt.Load(reader);
            /*
             *i was unsure how to approch this
             *but here is my solution and im sure that i could come up with a better one
             *but i have been working on this assignment for about 11 hours and im out of time
             *the count is just to sepereate the result into 2 diffrent strings
             */
            int count = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (count == 0)
                {
                    element1 = dr[0].ToString();
                    count++;
                }
                else
                {
                    element2 = dr[0].ToString();
                }

            }

            //closing the reader
            reader.Close();

            //changing the command string to get the first type from the database
            cmd.CommandText = "select pokemons.elements.element from pokemons.elements where pokemons.elements.id = " + element1 + ";";

            //saving the type to element1
            element1 = cmd.ExecuteScalar().ToString();

            if (element2 != "")
            {
                //changing the commands string to get the second type from the database
                cmd.CommandText = "select pokemons.elements.element from pokemons.elements where pokemons.elements.id = " + element2 + ";";

                //saving the type to element2
                element2 = cmd.ExecuteScalar().ToString();
            }
            else
            {
                element2 = "[No Second Type]";
            }

            //closing the connection
            conn.Close();
            //making a pokemon object from the data we got from the diffrent tables
            Pokemon pokemon = new Pokemon(pokemonName, number, element1, element2);

            //returning the pokemon obj
            return pokemon;
        }

        public void AddPokemon(Pokemon pokemon)
        {
            //opens connection
            //Det er pænere at gøre brug af using statements istedet for her
            conn.Open();
            //saving the name and number into the pokemon table
            string cmdStringToPokemon = "insert into pokemons.pokemon Values(" + pokemon.GetNumber() + ", '" + pokemon.GetName() + "');";
            MySqlCommand cmd = new MySqlCommand(cmdStringToPokemon, conn);
            cmd.ExecuteNonQuery();

            //changing the command string to get the elements id of the elements
            cmd.CommandText = "SELECT pokemons.elements.id from pokemons.elements where elements.element = '" + pokemon.GetType1() + "';";
            int type1 = int.Parse(cmd.ExecuteScalar().ToString());

            //saving the pokemon type and id to the binding table between pokemon and elements
            cmd.CommandText = "insert into pokemons.pokemonelements values(" + pokemon.GetNumber() + "," + type1 + ");";
            cmd.ExecuteNonQuery();

            //statement to check if the second type exsist
            if (pokemon.GetType2() != "")
            {
                //changing the command string to get the elements id of the elements
                cmd.CommandText = "SELECT pokemons.elements.id from pokemons.elements where elements.element = '" + pokemon.GetType2() + "';";
                int type2 = int.Parse(cmd.ExecuteScalar().ToString());

                //saving the pokemon type and id to the binding table between pokemon and elements
                cmd.CommandText = "insert into pokemons.pokemonelements values(" + pokemon.GetNumber() + "," + type2 + ");";
                cmd.ExecuteNonQuery();
            }

            Debug.WriteLine("----------[ADDED]--------" +
                            "\nName   : " + pokemon.GetName() +
                            "\nid     : " + pokemon.GetNumber() +
                            "\nType 1 : " + pokemon.GetType1() +
                            "\nType 2 : " + pokemon.GetType2() + 
                            "\n-------------------------");


            //closing the connection
            conn.Close();
        }
    }
}
