using YaksRPG.Models;

namespace YaksRPG.Extensions;

public static class FeatureTypeExtensions
{
  public static string GetName(this FeatureType featureType)
  {
    return featureType switch
    {
      FeatureType.Core => "Core",
      FeatureType.Major => "Major",
      FeatureType.Minor => "Minor",
      _ => throw new ArgumentOutOfRangeException(nameof(featureType), featureType, null)
    };
  }
}