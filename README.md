# Student Management System - ASP.NET Core Web API

## Overview

Student Management System built using ASP.NET Core Web API with Layered
Architecture, JWT Authentication, ADO.NET, and SQL Server.

## Tech Stack

-   ASP.NET Core Web API
-   ADO.NET
-   SQL Server
-   JWT Authentication
-   Swagger
-   Global Exception Middleware
-   ILogger Logging

## Features

-   Get all students
-   Add student
-   Update student
-   Delete student
-   JWT Authentication
-   Swagger UI
-   Global Exception Handling
-   Layered Architecture

## Database Table

Students: Id, Name, Email, Age, Course, CreatedDate, ModifiedDate, CreatedBy, ModifiedBy

## Stored Procedures

GetAllStudents\
InsertNewStudent\
UpdateStudent\
DeleteStudent

## Setup Steps

1.  Clone repository
2.  Update connection string
3.  Run SQL scripts
4.  Run project
5.  Open Swagger

## JWT Header

Authorization: Bearer `<token>`{=html}

## Architecture

Controller -\> Service -\> Repository -\> Database

## Logging

Implemented using ILogger

## Exception Handling

Global Exception Middleware
