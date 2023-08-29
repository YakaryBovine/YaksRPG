namespace YaksRPG.Models;

public interface ICharacterClass
{
  public string Name { get; }
  
  public string Flavour { get; }
  
  public DiceRoll HitDicePerLevel { get; }

  public float AttackBonusPerLevel { get; }
  
  public IEnumerable<Feature> Features { get; }
  
  /// <summary>
  /// A set of <see cref="Themes"/> that this <see cref="ICharacterClass"/> embodies.
  /// </summary>
  public IEnumerable<Theme> Themes { get; }
}