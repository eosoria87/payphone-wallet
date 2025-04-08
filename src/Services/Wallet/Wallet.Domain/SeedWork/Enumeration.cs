
namespace Wallet.Domain.SeedWork;

public abstract class Enumeration : IComparable
{
    public int CompareTo(object? other)
    {
        return Id.CompareTo(((Enumeration) other!).Id);
    }

    public override string ToString()
    {
        return Name;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Enumeration otherValue)
        {
            return false;
        }

        var typeMatches = GetType() == obj?.GetType();
        var valueMatches = Id.Equals(otherValue.Id);

        return typeMatches && valueMatches;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }


    #region Constructor & properties

    public string Name { get; }

    public int Id { get; }

    protected Enumeration(int id, string name)
    {
        Id = id;
        Name = name;
    }

    #endregion
}