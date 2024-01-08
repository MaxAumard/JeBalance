using JeBalance.Domain.Contracts;

namespace JeBalance.Domain.ValueObjects;

public class PostalCode : SimpleValueObject<int>
{
    public const int LENGHT = 5;

    public PostalCode(int value) : base(value)
    {
    }

    public override bool Equals(object? obj)
    {
        return obj is PostalCode code &&
               Value == code.Value;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value);
    }

    public override int Validate(int value)
    {
        if (value < 0) throw new ApplicationException("PostalCode cannot be negative");
        if (value.ToString().Length != LENGHT) new ApplicationException($"PostalCode should have a lenght of {LENGHT}");
        return value;
    }
}