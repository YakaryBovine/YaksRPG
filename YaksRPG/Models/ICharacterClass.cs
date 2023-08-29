namespace YaksRPG.Models;

public interface ICharacterClass
{
  public string Name { get; }
  
  public string Flavour { get; }
  
  public DiceRoll HitDicePerLevel { get; }

  public float AttackBonusPerLevel { get; }
  
  public IEnumerable<Feature> Features { get; }
}