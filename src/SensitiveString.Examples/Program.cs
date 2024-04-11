using System.Text.Json;
using SensitiveString;
using SensitiveString.Examples;
using SensitiveString.Json;

var person = new PersonDto(
    "John Doe",
    "(800) 555‑0123".AsSensitive(),
    "john.doe@example.com".AsSensitiveEmail()
);


// --- stringification ---
Console.WriteLine($"Person info: {person}");
Console.WriteLine($"Phone number: {person.PhoneNumber.Reveal()}");
Console.WriteLine($"Email: {person.Email.Reveal()}");


// --- JSON serialization ---
var serializerOptions = new JsonSerializerOptions();
serializerOptions.AddSensitiveStringSupport();

var serialized = JsonSerializer.Serialize(person, serializerOptions);
Console.WriteLine($"Serialized: {serialized}");