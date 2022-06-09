using FluentNHibernate.Mapping;

namespace ConsoleApp1;

public sealed class People
{
    public People(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    private People()
    {
    }
    public int Id { get; protected set; }
    public string FirstName { get; } = null!;
    public string LastName { get; } = null!;
}

public class PeopleMapping : ClassMap<People>
{
    public PeopleMapping()
    {
        Id(p => p.Id);
        Map(p => p.FirstName);
        Map(p => p.LastName);
    }
}