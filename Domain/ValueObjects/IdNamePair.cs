namespace Domain.ValueObjects;

public class IdNamePair<TId>
{
    public TId Id { get; set; }
    public string Name { get; set; }
}