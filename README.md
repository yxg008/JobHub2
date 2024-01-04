# JobHub2.0

## Table of Contents

1. [Overview](#overview)
2. [Features](#features)
3. [Technology Stack](#technology-stack)
4. [Installation](#installation)
    - [Installation Using Visual Studio](#installation-using-visual-studio)
5. [Testing](#testing)
6. [Deployment](#deployment)

## Overview

This project is a job search platform built to streamline the process of connecting job seekers with tailored employment opportunities. The platform features secure user authentication, robust data validation, dynamic client-side interactions, and efficient job search algorithms.

## Features

### General Features

- **CRUD Operations:** Utilizes ASP.NET Core MVC and Entity Framework Core for Create, Read, Update, and Delete operations.
- **User Authentication:** Incorporates ASP.NET Core Identity for secure login, logout, and password management.
- **Data Validation:** Employs Data Annotations for robust data validation and model relationships.
- **Client-side Interactivity:** Uses JavaScript for dynamic client-side features and user engagement.
- **Efficient Job Search Algorithm:** Developed in .NET for efficient job searching.

### For Job Seekers

- **Registration Process:** Easily register using an email address and create a personalized account.
- **Login Procedure:** Secure login to access personalized dashboards, manage profiles, and explore opportunities.
- **Job Search:** Explore a wide range of opportunities with filters based on preferences and skill sets.
- **Application Management:** Apply for jobs, track applications, and manage profiles to showcase expertise.
- **Advanced Search Functionality:** Utilize advanced search options, including skill set filters, to find the perfect job.

### For Employers

- **Job Postings:** Create and manage job postings to reach a vast pool of talented individuals.
- **Listings Management:** Edit, update, and remove job postings for efficient hiring process management.
- **Intuitive Search Bars:** Discover information about hiring companies to facilitate informed career decisions.

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

1. **Clone the Repository** or download the ZIP file.
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

- **API Testing with Postman:** Used to test the RESTful services and backend processes.
- **Unit Testing with xUnit:** Employed for writing and executing unit tests on individual methods and components.

## Deployment

- Hosted on Azure with continuous deployment via Azure DevOps.
