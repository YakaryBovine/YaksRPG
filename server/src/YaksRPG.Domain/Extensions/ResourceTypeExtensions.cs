using YaksRPG.Models;

namespace YaksRPG.Extensions;

public static class ResourceTypeExtensions
{
  public static string GetName(this ResourceType resourceType)
  {
    return resourceType switch
    {
      ResourceType.Mana => "Mana",
      _ => throw new ArgumentOutOfRangeException(nameof(resourceType), resourceType, null)
    };
  }
}