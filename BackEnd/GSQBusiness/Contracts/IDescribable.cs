namespace GSQBusiness.Contracts;

public interface IDescribable
{
    public string Name { get; set; }
    public string? Description { get; set; }
}