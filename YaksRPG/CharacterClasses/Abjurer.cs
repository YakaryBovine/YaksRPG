using YaksRPG.Models;

namespace YaksRPG.CharacterClasses;

public sealed class Abjurer : ICharacterClass
{
  public string Name => "Abjurer";

  public string Flavour => """
                           The School of Abjuration emphasizes magic that blocks, banishes, or protects. Detractors of this school say that its tradition is about denial, negation rather than positive assertion. You understand, however, that ending harmful effects, protecting the weak, and banishing evil influences is anything but a philosophical void. It is a proud and respected vocation.
                             
                           Called abjurers, members of this school are sought when baleful spirits require exorcism, when important locations must be guarded against magical spying, and when portals to other planes of existence must be closed.
                           """;

  public DiceRoll HitDicePerLevel { get; } = new()
  {
    NumberOfDice = 1,
    NumberOfSides = 8,
    Modifier = -2
  };

  public float AttackBonusPerLevel => 0.7f;

  public IEnumerable<Feature> Features { get; } = new[]
  {
    new Feature
    {
      Name = "Shield",
      Description = "When you or an ally within 30 feet would be hit by an attack, you can spend your Reaction to increase the attack target's AC by 5 until the start of your next turn. This bonus also affects the attack that triggered it, potentially causing it to miss.",
      Type = FeatureType.Major
    },
    
    new Feature
    {
      Name = "Absorb Elements",
      Description = "When you or an ally within 30 feet would take elemental damage, you can spend your Reaction to grant that character Resistance to the incoming damage type until the start of your next turn.",
      Type = FeatureType.Major
    },
    
    new Feature
    {
      Name = "Mage Armor",
      Description = "Your base AC becomes 13 + your Dexterity modifier.",
      Type = FeatureType.Minor
    },
    
    new Feature
    {
      Name = "Counterspell",
      Description = "When you see a creature within 60 feet of you attempt to cast a spell, you can use your Reaction to cause it to fail. If the creature is higher level than you, you must succeed an Arcana (Intelligence) skill check at a DC equal to 10 plus the caster's level.",
      Type = FeatureType.Major
    },
    
    new Feature
    {
      Name = "Remove Curse",
      Description = "As a Main Action, touch a cursed creature to remove all curses affecting it, or a cursed item to unbind it from its holder.",
      Type = FeatureType.Minor
    },
    
    new Feature
    {
      Name = "Nondetection",
      Description = "As a Main Action, touch a creature to render it immune to magical effects which remotely identify its location, such as scrying or magical sensors. This lasts until you are knocked unconscious or willingly end the effect.",
      Type = FeatureType.Minor
    },
    
    new Feature
    {
      Name = "Resist Magic",
      Description = "When a creature within 60 feet of you fails a Saving Throw against a spell, you can use your Reaction to allow it to reroll the throw once.",
      Type = FeatureType.Major
    },
    
    new Feature
    {
      Name = "Signature Spell",
      Description = $"When you acquire this Feature, choose another Feature that costs mana, and permanently half its {ResourceType.Mana.ToString()} cost.",
      Type = FeatureType.Major
    }
  };
}