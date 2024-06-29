namespace YaksRPG.Models;

public sealed class Feature
{
  public required string Name { get; init; }
  
  public required string Description { get; init; }
  
  public required FeatureType Type { get; init; }
  
  public Theme? Theme { get; init; }
}