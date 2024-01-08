namespace JeBalance.Domain.Contracts;

public abstract class Entity
{
    public string Id { get; }

    public Entity(string id) => Id = id;
}