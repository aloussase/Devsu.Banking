# Devsu Banking

Banking system that allows users to create accounts and perform transactions on them.

## Running the project

## Features

- The project can be easily deployed using the provided Docker configuration.

## Missing Features

I've skipped implementing some features because I had limited time to complete the project. Some of this include:
patching and updating entities other than clients and client authentication.

## Technical Considerations

- Passwords are stored in plain text. Obviously in a real application they would be hashed.
- I am using CQRS with [MediatR](https://github.com/jbogard/MediatR). Commands and queries are where I'd normally
  perform validation, but I've skipped that for the sake of time.
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

## License

MIT