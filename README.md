﻿# Devsu Banking

Banking system that allows users to create accounts and perform transactions on them.

## Running the project

You can run the project using docker-compose.

```
docker-compose up

# Or if you want to run it in the background
docker-compose up -d
```

This will spin up the two services and their corresponding databases. Take a look at the compose
file to see on which ports each one is running and modify them if needed.

## Architecture

The project is composed of two services:

- A clients service, which allows CRUD operations over clients
- An accounts service, which allows CRUD operations over accounts

Each service can be independently deployed and each one has its own database. This means that we lose referential
integrity in the data. Patterns like sagas or eventual consistency could be used to solve this problem, but
it would have been way overkill for this project.

Communication between the services occurs through HTTP, since as explained in "Missing Features" section,
there was no need for asynchronous communication.

Lastly, all services are Dockerized and may be run using a single command, as explained in the "Running the
project" section.

## Features

- All basic features listed in the requirements, except for those listed in the "Missing Features" section.
- Good maintainability
- The project can be easily deployed using the provided Docker configuration.

## Missing Features

I've skipped implementing some features because I had limited time to complete the project. Some of this include:
patching and updating entities other than clients, and client authentication.

Also, the requirements specified that there should be asynchronous communication between the different services, but
I did not find the need to do so, as I only needed to make a couple HTTP calls between them when generating the reports.
If there really was the need, I would have used some sort of message queue like SQS or RabbitMQ, or a PubSub service
like Redis.

The only cross-service call I found was necessary was to check that a given client exists before creating an account for
them. For time reasons, I did not implement this, but it would have been trivial to do so. It is left as an exercise for
the reader :).

## Technical Considerations

- Passwords are stored in plain text. Obviously in a real application they would be hashed.
- I am using CQRS with [MediatR](https://github.com/jbogard/MediatR). Commands and queries are where I'd normally
  perform validation, but I've skipped that in most places for the sake of time.
- A vertical slice architecture was used, as I've found it to be the most efficient way to organize code.
  I personally prefer it over Clean Architecture, but either choice would have been fine.
- Inheritance was used on DTOs and entities in order to save time typing the same properties.
  In a real world scenario I would have just typed out the properties for the sake of clarity,
  probably using Copilot or something like that to speed up the process.
- Some fields from the request objects were skipped to save time, including only those listed as examples in the
  requirements.
- [FastEndpoints](https://github.com/FastEndpoints/FastEndpoints/) was used for HTTP requests, as it is the fastest
  library for this purpose.
- The [Mapperly](https://github.com/riok/mapperly) library is used for object mapping, as its one of the fastest ones.
- Error handling is done using the [ErrorOr](https://github.com/amantinband/error-or) library.
- Error handling is sparse, taking into account only scenarios that were explicitly mentioned in the requirements.
- In a real project I would have implemented logging with Serilog or something similar.
- I am treating the client name as if it were a primary key because that's what the examples show.

## License

MIT