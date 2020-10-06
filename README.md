# PokemonDaoTest
 Using the DAO pattern to save, change and remove data from a database

# How to Use
 - To use this the first thing is to open MySql Workbench and run the database script that is in the folder DatabaseScripts, that will make the tables and the connections between them.

 - then open the elements table and run the element sql text file from the same folder, that will insert all the elements in pokemon

 - after that the application is ready to run 
 - beaware that the test code in main *"PokemonDao.DeletePokemonOnId(1)"* and *"(2)"* is not going to work because the pokemons arent in the database from the start, so outcomment them or make the pokemons with the *"PokemonDao.AddPokemon()"* before you try to delete them **(The application will crash! if not done)**
 
 # Class Diagram

![Class Diagram](/pokemonKD.png)
Format: ![Alt Text](url)

# Entity Relation Diagram

 ![ER Diagram](/pokemonER.png)
Format: ![Alt Text](url)

# Finish
the assignment was a mean to learn about the **DAO** (*Data Access Object*) Pattern, i have a felling that i have completed the assignment, *im still not completely sure how to use it but im sure i will learn more about it the more i use it* and i now know how to use it and i will use it more in future projects and i hope i will learn more about this and other patterns
