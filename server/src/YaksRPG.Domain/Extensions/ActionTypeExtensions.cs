using YaksRPG.Models;

namespace YaksRPG.Extensions;

public static class ActionTypeExtensions
{
  public static string GetName(this ActionType actionType)
  {
    return actionType switch
    {
      ActionType.Main => "Main Action",
      ActionType.Side => "Side Action",
      ActionType.Reaction => "Reaction",
      _ => throw new ArgumentOutOfRangeException(nameof(actionType), actionType, null)
    };
  }
}