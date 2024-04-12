# SensitiveString
[![NuGet Version](http://img.shields.io/nuget/v/SensitiveString.svg?style=for-the-badge&logo=nuget)](https://www.nuget.org/packages/SensitiveString/) [![NuGet Downloads](https://img.shields.io/nuget/dt/SensitiveString.svg?style=for-the-badge&logo=nuget)](https://www.nuget.org/packages/SensitiveString/)

Introducing SensitiveString, your shield against inadvertent exposure of sensitive information in application logs and beyond.

This lightweight NuGet package wraps strings in a protective layer, ensuring that sensitive data remains secure and inaccessible without explicit handling.

Safeguard your users' privacy and your application's integrity effortlessly with SensitiveString.

## Example

Let's try to initialize and print a simple record with personal information:

```c#
internal record PersonDto(string Name, SensitiveString PhoneNumber, SensitiveEmail Email);
```

```c#
using SensitiveString;

var person = new PersonDto(
    "John Doe",
    "(800) 555‑0123".AsSensitive(),
    "john.doe@example.com".AsSensitiveEmail()
);

Console.WriteLine($"Person info: {person}");
```

What we get in the console is:

```
Person info: PersonDto { Name = John Doe, PhoneNumber = ***, Email = ***@example.com }
```

Now let's try to access the original information:

```c#
Console.WriteLine($"Phone number: {person.PhoneNumber.Reveal()}");
Console.WriteLine($"Email: {person.Email.Reveal()}");
```

And what we now get in the console is:

```
Phone number: (800) 555‑0123
Email: john.doe@example.com
```

## How it works?

The `SensitiveString` and `SensitiveEmail` types are straightforward string wrappers. Without special handling, their content remains hidden from standard stringifiers and serializers. So if you're afraid some sensitive data may leak into application logs when stringified implicitly, use one of these two types to prevent that.

`SensitiveEmail` differs from `SensitiveString` only in how it masks the original value. If you prefer having emails fully masked rather than the login part before @, use the `SensitiveString` instead.



## Serialization/deserialization

In client-server communication we want the information in its original form present in the data being transmitted between the parties. Because, however, of how the types are designed, without explicit handling, serializers will output nothing but an empty object.

Therefore, to use the type in DTOs, you'll need to extend your serializers in use with special converters to handle these types. Converters for the `System.Text.Json.JsonSerializer` are available in this repository and are part of the associated NuGet package. See below how serialization behaves with and without them.

Let's use the same person object as in the example used earlier:

```c#
using System.Text.Json;
...

var serialized = JsonSerializer.Serialize(person);
Console.WriteLine($"Serialized: {serialized}");
```

This is what we will get as the output:

```
Serialized: {"Name":"John Doe","PhoneNumber":{},"Email":{}}
```

As you can see, the sensitive strings are just empty JSON objects `{}`.

Now let's add appropriate converters to serializer options:

```c#
using System.Text.Json;
using SensitiveString.Json;
...

var serializerOptions = new JsonSerializerOptions();
serializerOptions.AddSensitiveStringSupport();

var serialized = JsonSerializer.Serialize(person, serializerOptions);
Console.WriteLine($"Serialized: {serialized}");
```

Now the output is complete:

```
Serialized: {"Name":"John Doe","PhoneNumber":"(800) 555\u20110123","Email":"john.doe@example.com"}
```

The same options should be used for deserialization.

## REST API

To make sure your web API handles the types correctly, call this on startup:

```c#
builder.Services
   .AddControllers()
   .AddJsonOptions(
        o => o.JsonSerializerOptions.AddSensitiveStringSupport()
    );

builder.Services.ConfigureHttpJsonOptions(
    o => o.SerializerOptions.AddSensitiveStringSupport()
);
```



## EntityFrameworkCore

To use `SensitiveString` and `SensitiveEmail` in database entities, install a dedicated [NuGet package](https://www.nuget.org/packages/SensitiveString.EntityFrameworkCore/).



## HotChocolate (GraphQL)

To use `SensitiveString` and `SensitiveEmail` in GraphQL inputs and responses, install a dedicated [NuGet package](https://www.nuget.org/packages/SensitiveString.HotChocolate/).



## Disclaimer

This is a proof of concept. If you find any issues using the package or have any thoughts on it, your comments reported as issues are more than welcome!

