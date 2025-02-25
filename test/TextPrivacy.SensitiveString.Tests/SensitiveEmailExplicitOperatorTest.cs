using System.Linq.Expressions;

namespace TextPrivacy.SensitiveString.Tests;

public class SensitiveEmailExplicitOperatorTest
{
    [Fact]
    public void sensitive_email_can_be_converted_to_string()
    {
        var email = "john.doe@example.com";
        var customer = new Customer(email.AsSensitiveEmail());
        var getSensitiveEmail = ConvertToString(c => c.Email);

        var actualEmail = getSensitiveEmail(customer);
        Assert.Equal(email, actualEmail);
    }

    private Func<Customer, string> ConvertToString(Expression<Func<Customer, SensitiveEmail>> expression)
    {
        var convertedExpression = Expression.Lambda<Func<Customer, string>>(
            Expression.Convert(expression.Body, typeof(string)),
            expression.Parameters
        );

        return convertedExpression.Compile();
    }

    private record Customer(SensitiveEmail Email);
}