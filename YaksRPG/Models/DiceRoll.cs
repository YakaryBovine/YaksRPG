namespace YaksRPG.Models;

public sealed class DiceRoll
{
  public int NumberOfDice { get; init; } = 1;
  
  public int NumberOfSides { get; init; } = 1;
  
  public int Modifier { get; init; }
}