using System;
using System.Collections.Generic;
using Domain.SeedWork;

namespace Domain.Common;

public class Price : ValueObject
{
    protected Price()
    {
    }

    public Price(decimal value, Currency currency)
    {
        Value = Math.Round(value, 2, MidpointRounding.AwayFromZero);
        Currency = currency;
    }

    public decimal Value { get; }
    public Currency Currency { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return Currency;
    }
}