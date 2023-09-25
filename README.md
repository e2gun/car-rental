# Car Rental Project

This project is an API project written using dotnet 7 that embraces Clean Architecture and follows the principles of Domain-Driven Design (DDD). Its primary aim is to illustrate the application of Clean Architecture, DDD, the CQRS (Command Query Responsibility Segregation) pattern, and the use of Dapper for queries and Entity Framework Core (EF Core) for commands in a .NET application. The project is designed for managing vehicle rentals and comprises three core classes: Vehicle, Booking, and Customer. Additionally, it allows tracking customer reviews.

## Clean Architecture, DDD, CQRS, and Data Access Principles

The project architecture and design are influenced by several key principles and patterns:

### Clean Architecture

Clean Architecture emphasizes separation of concerns and maintains a clear and modular project structure. In this project:

- **Entities:** Vehicle, Booking, and Customer classes represent the core business entities. They encapsulate the domain logic and are independent of external frameworks or libraries.

- **Use Cases (Application Core):** The application core contains business logic, including use cases like renting a vehicle, making a booking, and managing customer information.

- **Interfaces (Application Interfaces):** Interfaces define how the application core interacts with the outside world. They include API controllers, DTOs (Data Transfer Objects), and other interfaces for external communication.

- **Infrastructure:** This layer provides implementations for data access, external services, and other infrastructure concerns. It remains decoupled from the core domain.

### Domain-Driven Design (DDD)

Domain-Driven Design is a set of principles and patterns for designing complex systems with a strong focus on the domain. In this project:

- **Aggregate Roots:** The entities (Vehicle, Booking, and Customer) form aggregate roots that define transactional boundaries and enforce consistency within the domain.

- **Repositories:** Repositories are used to abstract the data access layer, providing a clean interface for accessing and persisting domain objects.

- **Value Objects:** Value objects are used to represent concepts like vehicle specifications and booking details, which have no distinct identity but are essential for the domain.

- **Bounded Contexts:** DDD's concept of bounded contexts is applied to clearly define the boundaries of different subdomains within the project.

### CQRS (Command Query Responsibility Segregation)

CQRS is a pattern that separates the handling of commands (write operations) from queries (read operations). In this project:

- **Commands:** Commands represent actions that change the system's state, such as creating a booking or updating customer information. These commands are executed using Entity Framework Core (EF Core).

- **Queries:** Queries represent read-only operations to retrieve data, such as fetching vehicle details or customer reviews. These queries are executed using Dapper, a lightweight and efficient micro ORM.

### Data Access with Dapper and EF Core

- **Dapper:** Dapper is used for handling queries efficiently. It allows for high-performance data retrieval while maintaining a simple and clean interface.

- **Entity Framework Core (EF Core):** EF Core is used for executing commands to update and persist data. It provides a rich set of features for data modeling and relational database interaction.

## Project Components

The project consists of the following key components:

1. **Vehicle:** This class represents the basic information and attributes of rental vehicles, such as brand, model, and fuel type.

2. **Booking:** Used to manage reservations, it tracks when customers rent vehicles and when they are scheduled to return them.

3. **Customer:** Represents customer information, including name, address, and phone number.

4. **Review:** Allows customers to leave reviews about the vehicles they rented. Reviews are essential for monitoring customer feedback.

## Installation and Running

To set up and run the project on your local development environment with Docker Compose, follow these steps:

Clone this repository to your local machine:

   ```shell
   git clone https://github.com/e2gun/car-rental.git

   cd car-rental

   docker-compose up --build
