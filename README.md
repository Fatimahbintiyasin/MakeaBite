# MakeaBite

## Overview
MakeaBite is a user-friendly web API that enables users to create healthy recipes using a diverse selection of ingredients, combining traditional cooking methods with modern technology for a seamless culinary experience.

## Technologies Used
- **IDE**: Visual Studio
- **Backend**: ASP.NET Core Web API
- **Frontend**: ASP.NET Core MVC
- **API**: RESTful API
- **Database**: AWS RDS
- **Cloud Deployment**: AWS ECS Fargate
- **Containerization**: Docker
- **API Documentation**: Swagger

##Instructions

1. Download the project, extract the zip file, and open it in Visual Studio
2. Set up your **AWS RDS** and Insert data for the Recipe and Ingredient table. You can get the code in the **MakeaBite_db_query.txt** file
3. In the **MakeaBite_WebAPI > aapsettings.json** file, change the ConnectionString to your RDS connection string.
4. Set the MakeaBite_WebAPI as a Startup project and run it (keep it running because we need it in the background to run the Client Web App).
5. It will open up Swagger in your browser, and use the interactive interface to test different API endpoints by sending requests and viewing responses.
6. Now, you can publish the **MakeaBite_WebAPI** to AWS ECS Fargate.
7. To run the Client, open another window of Visual Studio.
8. In one window run the **MakeaBite_WebAPI** and in another window run the **MakeaBite_WebAPP**
9. Then you will be able to do all the CRUD operations in a client same as you did in Swagger.
    






