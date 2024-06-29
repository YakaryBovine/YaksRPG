namespace YaksRPG.Models;

public readonly struct DiceRoll
{
  public int NumberOfDice { get; }
  
  public int NumberOfSides { get; }
  
  public int Modifier { get; }
  
  public DiceRoll(int numberOfDice, int numberOfSides, int modifier)
  {
    NumberOfDice = numberOfDice;
    NumberOfSides = numberOfSides;
    Modifier = modifier;
  }
  
  public static DiceRoll operator *(DiceRoll baseRoll, int multiplier)
  {
    return new DiceRoll(baseRoll.NumberOfDice*multiplier, baseRoll.NumberOfSides, baseRoll.Modifier * multiplier);
  }

  public override string ToString()
  {
    var parsedModifier = Modifier switch
    {
      0 => "",
      < 0 => Modifier.ToString(),
      > 0 => $"+{Modifier}"
    };
    return $"{NumberOfDice}d{NumberOfSides}{parsedModifier}";
  }
}