// See https://aka.ms/new-console-template for more information

using SensitiveString;
using SensitiveString.Examples;

var person = new PersonDto(
    "John Doe",
    "(800) 555‑0123".AsSensitive(),
    "john.doe@example.com".AsSensitiveEmail()
);


Console.WriteLine($"Person info: {person}");
Console.WriteLine($"Phone number: {person.PhoneNumber.Reveal()}");
Console.WriteLine($"Email: {person.Email.Reveal()}");