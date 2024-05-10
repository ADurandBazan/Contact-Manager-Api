# Contact-Manager-Api

## Description

This is a .NET 7 Web API that provides a simple CRUD (Create, Read, Update, Delete) interface for managing contact data for users. The API uses Entity Framework Core (EF Core) for database operations and sql server with a database named UserManager.This api required authentication througt Bearer JWt, the jwt settings can be modifided in appsettings.json file.

## Key Features:

#### The API supports basic CRUD operations for managing conatct data, including creating new contact, retrieving existing contacts, updating contact information, and deleting contact.
#### The API generate a default user for testing, allowing you to test the api using the token wich the claim nameidentifier should be the username of the user storage.
#### The API has swagger documentation.

## API Endpoints:

#### POST /api/contacts: Allows to create a new contact.
#### PUT /api/contacts/{id}: Allows to update a existing student by the student id.
#### DELETE /api/contacts/{id}: Allows to delete a student by the student id.
#### GET /api/contacts: Provides all existing contacts, allow pagination and filtering. 
#### GET /api/contacts/{id}: Provides a existing contact by id,

## Technologies Used:

#### Programming Language: C#
#### Web Framework: .Net7
#### Database: sqlserver

