# CustomerSubscriptionWebApp
Web Application for managing customers subscription, customers and products developed on ASP.Net Core 3.1


## Web MVC application
This code sample presents a Web application based on Net Core 3.1 and MVC 5 as a presentation project for managin Customers and Products Master data as well as Subscriptions (Customers being register with multiples Products).

The applications contains MVC Razor pages and a custom Nuget Package as a simple class library for consuming data from an existing API application.

The single nuget package can be found on Nuget.org (https://www.nuget.org/packages/Challenge.Util.CustomerSubscriptionAPIClient) 
as well as Github (https://github.com/dalbarracin/CustomerSubscriptionAPIClient).

The Web API application can be downloaded as a single container on Docker hub (https://hub.docker.com/repository/docker/dalbarracin/customersubscriptionapi) 
as well as Github (https://github.com/dalbarracin/CustomerSubscriptionAPI)


## Requirements

- Docker installed
- Docker compose configured

## Running the Application

1. Download source code from Github

2. Open command prompt and locate to root source code folder where "docker-compose.yml" is located to.

3. Execute `docker-compose up --build`

4. Open the web application "http://localhost:62231/"

