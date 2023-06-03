# Pierre's Bakery With Identity

### Sarah Reimann


## Description

If you are logged in, you can add, edit, and delete treats and flavors. If you are not logged in, you can view the list of treats and flavors. 

## Technologies Used

* C#
* .NET
* ASP.NET Core
* MVC
* Entity Framework Core
* Pomelo Entity Framework Core
* EF Core Migrations
* Html Helpers
* MySQL
* ASP.NET Identity

## Database Structure

![image of schema connections](./Library/wwwroot/img/schema.png)

## Setup Instructions

1. Clone this repo.
2. Open your terminal (e.g. Terminal or GitBash) and navigate to this project's directory called "Library".
3. Set up the project:
  * Create a file called 'appsettings.json' in Factory.Solution/Factory directory
  * Add the following code to the appsettings.json file:
  ```
  {
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=Bakery;uid=[YOUR_SQL_USER_ID];pwd=[YOUR_SQL_PASSWORD];"
    }
  }
  ```
  * Make sure to plug in your SQL user id and password at ```[YOUR_SQL_USER_ID]``` and ```[YOUR_SQL_PASSWORD]```
4. Set up the database:
  * Make sure EF Core Migrations is installed on your computer by running ```dotnet tool install --global dotnet-ef --version 6.0.0```
  * In the production folder of the project (Library.Solution/Library) run:
  ```
  dotnet ef database update
  ```
  * You should see the new schema in your _Navigator > Schemas_ tab of your MySql Workbench on refresh called ```library```
5. Running the project in your browser:
  * Navigate to the production directory "Library" from your terminal.
  * Run the command from Library ```dotnet watch run```
  * Your browser should automatically open ```https://localhost:5001/```. You may need to enter your computers password when prompted to allow ASP.NET Core to run in your browser.


## Known Bugs

* _Roles are more of an easter egg feature_
* _WIP: Authorization features_

## License
[MIT](https://opensource.org/licenses/MIT)  
Copyright © Sarah Reimann