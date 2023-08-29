namespace YaksRPG.Models;

/// <summary>
/// An instance of thematic flavour which can be executed mechanically, such as resisting damage, healing, or summmoning.
/// </summary>
public sealed class Theme
{
  public required string Name { get; init; }
  
  public required string Description { get; init; }
}