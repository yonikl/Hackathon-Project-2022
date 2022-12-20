

using System.Diagnostics;

namespace Models;

public class Address
{
    string? City { get; set; }
    string? Street { get; set; }
    string? HouseNumber { get; set; }

    public Address (string? c , string? s, string? h)
    {
        City = c;
        Street = s;
        HouseNumber = h;
    }

    public override string ToString() => $@"
          City - {City}
          Street - {Street}
          HouseNumber - {HouseNumber}";
}
