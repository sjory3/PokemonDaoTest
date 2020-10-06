# PokemonDaoTest
 Using the DAO pattern to save, change and remove data from a database

# How to Use
 - To use this the first thing is to open MySql Workbench and run the database script that is in the folder DatabaseScripts, that will make the tables and the connections between them.

 - then open the elements table and run the element sql text file from the same folder, that will insert all the elements in pokemon

 - after that the application is ready to run 
 - beaware that the test code in main "PokemonDao.DeletePokemonOnId(1)" and "(2)" is not going to work because the pokemons arent in the database from the start, so outcomment them or make the pokemons with the "PokemonDao.AddPokemon()" before you try to delete them (The application will crash! if not done)
