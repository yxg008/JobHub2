# JobHub

## Table of Contents

1. Overview
2. Features
3. Technology Stack
4. Installation
    - Installation Using Visual Studio
5. Testing
6. Deployment
7. Contributing
8. License

## Overview

This project is a job search platform built to streamline the process of connecting job seekers with tailored employment opportunities. The platform features secure user authentication, robust data validation, dynamic client-side interactions, and efficient job search algorithms.

## Features

- **CRUD Operations:** Utilizes ASP.NET Core MVC and Entity Framework Core for Create, Read, Update, and Delete operations.
- **User Authentication:** Incorporates ASP.NET Core Identity for secure login, logout, and password management.
- **Data Validation:** Employs Data Annotations for robust data validation and model relationships.
- **Client-side Interactivity:** Uses JavaScript for dynamic client-side features and user engagement.
- **Efficient Job Search Algorithm:** Developed in .NET for efficient job searching.

## Technology Stack

- C#
- ASP.NET Core MVC
- Entity Framework Core
- ASP.NET Core Identity
- JavaScript
- HTML5
- Bootstrap 5
- Azure
- Postman
- xUnit

## Installation

### Installation Using Visual Studio

#### Prerequisites

- Visual Studio (latest version recommended).
- .NET SDK.
- SQL Server or compatible database engine for Entity Framework.

#### Steps

1. **Clone the Repository**
or download the ZIP file.

2. **Open the Project**
- Open Visual Studio.
- Go to File -> Open -> Project/Solution.
- Open the .sln file from the cloned repository.

3. **Restore NuGet Packages**
- Right-click on the solution in Solution Explorer.
- Select Restore NuGet Packages.

4. **Update Database**
- Open Package Manager Console.
- Run `Update-Database`.

5. **Build and Run**
- Build the solution in Solution Explorer.
- Start the application (F5 or Start Debugging button).

## Testing

### API Testing with Postman

- Used to test the RESTful services and backend processes.

### Unit Testing with xUnit

- Employed for writing and executing unit tests on individual methods and components.

## Deployment

- Hosted on Azure with continuous deployment via Azure DevOps.
