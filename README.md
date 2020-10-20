# CQRSFestivals
CQRSFestivals is a sample application built using .NET Core 3.1 and Entity Framework Core 3.1.

## Getting Started
Use these instructions to get the project up and running.

### Prerequisites
You will need the following tools:

* [Visual Studio Code or Visual Studio 2019](https://visualstudio.microsoft.com/vs/) (version 16.3 or later)
* [.NET Core SDK 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)
* [Postman](https://www.postman.com/downloads/)(For integration testing the controller methods & testing the endpoints)
* [Docker](https://www.docker.com/products/docker-desktop)(If you want to run MySQL on a container instead of installing it on your machine)

### Setup
Follow these steps to get your development environment set up:

  1. Clone the repository
  2. Open the solution in Visual Studio 2019
  3. Start Run Docker Compose file Infrastructure: https://github.com/RotterAxel/CQRSFestivals/blob/main/Scripts/docker-compose.yml
  4. Start the project WebUI
  6. Open Postman -> Import -> File -> Import the file & the environment variables in https://github.com/RotterAxel/CQRSFestivals/tree/main/Postman
  7. In Postman you will have to run the Authorization endpoints first. This will automatically store the bearer token in the collection variables

## Additional Information
* The DB Migrates and Reseeds itself with every new start of the project
* The Postman collection includes example tests to better understand and test the endpoints
* The compose file will start, PostgreSQL, Keycloak and MySQL

## Technologies
* .NET Core 3.1
* Entity Framework Core 3.1

## License

This project is licensed under the GNU General Public License v3.0 License - see the [LICENSE.md](https://github.com/RotterAxel/RESTFestivals/blob/master/LICENSE) file for details.
