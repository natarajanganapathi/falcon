namespace LightningArc.Contracts;

public interface IInclude
{
    public string Name { get; set; }
    public string[]? Select { get; set; }
    public Include[]? Includes { get; set; }
}