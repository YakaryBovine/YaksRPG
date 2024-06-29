namespace YaksRPG.Models;

public abstract class CharacterClass
{
  public abstract string Name { get; }
  public abstract string Flavour { get; }
  public abstract DiceRoll HitDicePerLevel { get; }
  public abstract float AttackBonusPerLevel { get; }
  public abstract IEnumerable<Feature> Features { get; }

  /// <summary>
  /// A set of <see cref="Themes" /> that this <see cref="CharacterClass" /> embodies.
  /// </summary>
  public abstract IEnumerable<Theme> Themes { get; }

  public override string ToString() => Name;
}