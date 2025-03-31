public record Quantity(int Value)
{
    public Quantity Add(int amount) => new(Value + amount);
}