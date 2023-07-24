
**Movies Website**
----------------------------------------------------------------------------------------------

This repository contains a Movies Website developed using .NET Core 5 MVC, Entity Framework Code First, and SQL Server. The website allows users to perform CRUD (Create, Read, Update, Delete) operations on movies and also provides identity login and signup functionalities.

**Introduction**
------------------------------------------------------------------------------------------------

The Movies Website is a web application that allows users to manage a collection of movies. 
Users can view a list of movies, add new movies, update existing movie details, and delete movies from the collection. Additionally, the website provides identity login and signup features to ensure secure access to the movie management functionalities.

**Technologies Used**
------------------------------------------------------------------------------------------
The following technologies have been used to develop this Movies Website:

.NET Core 5 MVC: The web application framework used for building the user interface and handling user requests.
Entity Framework Core (Code First): Used for defining the data models and managing database interactions.
SQL Server: The relational database system used to store movie and genre data.

**Database Schema**
-------------------------------------------------------------------------------------------------------------------
The Movies Website utilizes a relational database with two tables: Movies and Genres. Below is the schema for each table:

### Movies Table

| Column    | Type     | Description                                |
|-----------|----------|--------------------------------------------|
| id        | int      | Unique identifier for the movie.           |
| title     | varchar  | The title of the movie.                   |
| year      | int      | The release year of the movie.            |
| rate      | double   | The rating of the movie.                  |
| storyline | string   | The storyline or plot of the movie.       |
| poster    | byte     | file path to the movie poster image.      |
| genre_id  | int      | Foreign key referencing the Genres table to establish a one-to-many relationship. |

### Genres Table


| Column    | Type     | Description                           |
|-----------|----------|---------------------------------------|
| id        | int      | Unique identifier for the genre.      |
| Name      | varchar  | The name of the movie genre.          |

*Getting Started*
--------------------------------------------------------------------------
To get a local copy of the Movies Website up and running, follow these steps:

Clone the repository: git clone https://github.com/your-username/movies-website.git
Navigate to the project directory: cd movies-website
Make sure you have .NET Core 5 SDK installed on your machine.
Configure the connection string to your SQL Server database in the appsettings.json file.
Run database migrations to create the required tables: dotnet ef database update
Build the application: dotnet build
Run the application: dotnet run

*Usage*
---------------------------------------------------------------------------
Once the application is up and running, you can access it through your web browser. The website will present a user-friendly interface that allows you to:

View a list of movies with their details.
Add new movies to the collection.
Update existing movie details.
Delete movies from the collection.
Perform login and signup to access the movie management features.



