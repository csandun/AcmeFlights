# AcmeFlights DDD POC Project

## "requirements"

- Implement the following features:
    - **Feature 1**: Search the available flights for a destination
        - You can search available flights to a specific destination
        - Does not include flights that are not available (has no rates)
        - For each found flight show:
            - Departure airport code
            - Arrival airport code
            - Departure datetime
            - Arrival datetime
            - Lowest Price
    - **Feature 2**: Placing an order
        - Must have endpoints to create an order
        - Must use the Ordering domain (`Domain/Aggregates/OrderAggregate/`)
        - Must be able to fill the order with the (just the necessary) details, while still in draft state
        - Respects the business logic
    - **Feature 3**: Confirming an order
        - Must be able to confirm the order
        - When an order is confirmed, the any ordered rates should lower their availability by the quantity ordered
        - Notifies the customer about the confirmed order (fake the notification with a `Console.WriteLine`)
        - Its not possible to make changes to a confirmed order (guarded by domain)

- **Architecture requirements**:
    - Domain Driven Design
    - CQRS
    - Mediator pattern (Using [MediatR](https://github.com/jbogard/MediatR))
    - Persistence ignorance
    - SOLID
    -

## Prerequisities

- Docker Desktop
- .NET 6 SDK

## Getting started

- Start the Postgres database with `docker-compose up -d` (the application is already configured properly, but if you
  want to connect to the db directly you can see the credentials in the `docker-compose.yml` file)
- You can now run the API project and everything should work. Upon start the application will run the migrations and
  seed data to the database.

## Migrations
- dotnet ef migrations add xxxxx
-  dotnet ef database update  

## **Main project changes**:
- Upgraded project nugets up to .Net6
- I am preferred to move  Application folder to separate class library,  according to Clean Architecture. But I haven't much time to do this.
- According to Clean architecture I separated command and queries with usecase wise.
- Tried to cover all points

*Thanks*