using YaksRPG.Models;

namespace YaksRPG.CharacterClasses;

public sealed class Berserker : ICharacterClass
{
  public string Name => "Berserker";

  public string Flavour => """
                           Ruthless, unrelenting, and unstoppable - these traits define the Berserker's approach to violence. Possessed of inhuman strength, these paragons of danger cut swathes through the battlefield like knives through butter, raging against the rational restraints that limit other warriors in favour of pure instinct honed through years of struggle.
                           
                             Berserkers rely on their raw strength, resilience, and instinct even outside of combat. The most headstrong among them can burst their way through any physical obstacle, while others can disregard the effects of even the most extreme weather conditions simply by gritting their teeth hard enough.
                           """;

  public DiceRoll HitDicePerLevel { get; } = new()
  {
    NumberOfDice = 1,
    NumberOfSides = 6,
    Modifier = 2
  };

  public int AttackBonusPerLevel => 1;
}