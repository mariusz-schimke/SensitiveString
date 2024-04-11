namespace SensitiveString.Examples;

internal record PersonDto(string Name, SensitiveString PhoneNumber, SensitiveEmail Email);