namespace Task2.Contract;

public class Product
{
    public int Id { get; init; }
    public required int ProviderId { get; set; }
    public required string? Description { get; set; }
    public required string? Photo { get; set; }
    public required string? Name { get; set; }
    public required string? Variant { get; set; }
    public State State { get; set; }
}

public enum State
{
    Correct,
    Incorrect
}
