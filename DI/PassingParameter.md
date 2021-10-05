# Passing string Parameters using DI

This import is important for connection strings that may need to be passed to a libary.

## There are 3 ways of passing strings to injected services

### Method 1 : Options Pattern
- Always use this if suitable.
- [Link](https://docs.microsoft.com/en-gb/aspnet/core/fundamentals/configuration/options?view=aspnetcore-5.0)

### Method 2 : Named Service Parameters
- Use when there is need to dynamically charge a DI.
- Use when parameters are only known at runtime not compile time.
- Dependany resolution :
  * Individual resolution
  * Use of ActivatorUtilities
- [Link](https://newbedev.com/net-core-di-ways-of-passing-parameters-to-constructor)

### Method 3 : Parameter Pattern
- Use when there is need for parameter reuse.
- [Link](https://stackoverflow.com/a/53884865/8228598)