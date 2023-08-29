using YaksRPG.Models;

namespace YaksRPG.CharacterClasses;

public sealed class Berserker : CharacterClass
{
  public Berserker()
  {
    var brawlingTheme = new Theme
    {
      Name = "Brawling",
      Description = "Deal damage, throw around foes, and resist attacks, all without relying on weapons or armour."
    };
    var overexertionTheme = new Theme
    {
      Name = "Overexertion",
      Description = "Perform extraordinary feats by pushing your body past its natural limits."
    };
    var strongTheme = new Theme
    {
      Name = "Strong",
      Description = "Influence the world through raw physical power."
    };

    Themes = new[]
    {
      brawlingTheme,
      overexertionTheme,
      strongTheme
    };

    Features = InitializeFeatures(brawlingTheme, overexertionTheme, strongTheme);
  }

  public override string Name => "Berserker";

  public override string Flavour => """
                                    Ruthless, unrelenting, and unstoppable - these traits define the Berserker's approach to violence. Possessed of inhuman strength, these paragons of danger cut swathes through the battlefield like knives through butter, raging against the rational restraints that limit other warriors in favour of pure instinct honed through years of struggle.

                                    Berserkers rely on their raw strength, resilience, and instinct even outside of combat. The most headstrong among them can burst their way through any physical obstacle, while others can disregard the effects of even the most extreme weather conditions simply by gritting their teeth hard enough.
                                    """;

  public override DiceRoll HitDicePerLevel { get; } = new(1, 8, 2);

  public override float AttackBonusPerLevel => 1;

  public override IEnumerable<Feature> Features { get; }

  public override IEnumerable<Theme> Themes { get; }

  private static IEnumerable<Feature> InitializeFeatures(Theme brawlingTheme, Theme overexertionTheme,
    Theme strongTheme)
  {
    return new[]
    {
      new Feature
      {
        Name = "Bestial Charge",
        Description =
          "When you Charge, you gain +4 to hit instead of +2, and if you hit, the attack deals 4 additional damage.",
        Type = FeatureType.Major,
        Theme = brawlingTheme
      },

      new Feature
      {
        Name = "Blade Catch",
        Description =
          "When an opponent declares an attack against you, you can use your Reaction and skip their attack roll, guaranteeing that the attack deals damage, then make an attack against that opponent.",
        Type = FeatureType.Major,
        Theme = overexertionTheme
      },

      new Feature
      {
        Name = "Brutal Throw",
        Description =
          "As a Main Action, pick up an item or creature that you can lift and throw it at a target within 15 feet. If the tossed object is a creature and is not prone or unable to defend itself, it may make a Physical saving throw to avoid being tossed. The tossed object is treated as an improvised weapon dealing 1d8 Bludgeoning damage. On a hit, both the tossed object and the target take the same amount of damage.",
        Type = FeatureType.Major,
        Theme = strongTheme
      },

      new Feature
      {
        Name = "Domineering Presence",
        Description =
          "Any creature within 5 feet of you that's hostile to you has Disadvantage on attack rolls against targets other than you. An enemy is immune to this effect if it can't see or hear you or if it can't be Frightened.",
        Type = FeatureType.Major,
        Theme = strongTheme
      },

      new Feature
      {
        Name = "Force Through",
        Description =
          "When you would miss an attack, you can gain add 10 to the attack roll at the expense of gaining 1 System Strain.",
        Type = FeatureType.Major,
        Theme = overexertionTheme
      },

      new Feature
      {
        Name = "Frenzied Strike",
        Description =
          "As a Minor Action, make a melee attack. You take a stacking -1 penalty on Attack Rolls for the rest of the scene.",
        Type = FeatureType.Major,
        Theme = overexertionTheme
      },

      new Feature
      {
        Name = "Improved Critical",
        Description = "Your attacks score a critical hit on a roll of 18 or higher.",
        Type = FeatureType.Major,
        Theme = strongTheme
      },

      new Feature
      {
        Name = "Intimidate",
        Description =
          "Frighten a creature within 30 feet that can see or hear you until the end of your next turn. The creature can make a Wisdom saving throw to ignore the effect.",
        Type = FeatureType.Major,
        Theme = strongTheme
      },

      new Feature
      {
        Name = "Reckless Attack",
        Description =
          "When you attack, you can choose to gain advantage on the attack. If you do, attack rolls against you have advantage until your next turn.",
        Type = FeatureType.Major,
        Theme = overexertionTheme
      },

      new Feature
      {
        Name = "Shattering Leap",
        Description =
          "When you Jump at least 10 feet, deal 1d4 damage to creatures and objects within 5 feet and knock them prone. Creatures can make a Strength or Dexterity Saving Throw to take half damage and avoid being knocked prone.",
        Type = FeatureType.Major,
        Theme = brawlingTheme
      },


      new Feature
      {
        Name = "Thunderous Blows",
        Description =
          "When you hit a creature with a melee attack, you can push that creature up to 5 feet away from you in a direction of your choice. A creature that is Huge or larger makes a Strength Saving Throw with a DC equal to 8 + your proficiency bonus + your Strength modifier to avoid being pushed.",
        Type = FeatureType.Major,
        Theme = strongTheme
      },


      new Feature
      {
        Name = "Unrelenting",
        Description =
          "When you are reduced to 0 Hit Points, you can make a DC 10 Constitution Saving Throw to drop to 1 Hit Point instead. Each time you use this feature after the first, the DC increases by 5. The DC is reset to 10 when you rest.",
        Type = FeatureType.Major,
        Theme = overexertionTheme
      },


      new Feature
      {
        Name = "Unstoppable Force",
        Description = """
                      When you *Charge*, you gain the following benefits:
                      * Any inanimate object you pass through which is no sturdier than a brick wall is destroyed.
                      * Any creature you pass through which is no larger than Huge is tossed 5 feet to the side and suffers 1d6 Bludgeoning damage. Creatures may make a Strength saving throw to avoid this effect; on a success, they take no damage, are not tossed to the side, and your *Charge Attack* stops short.
                      """,
        Type = FeatureType.Major,
        Theme = overexertionTheme
      },

      new Feature
      {
        Name = "Vitality Surge",
        Description = "As a Minor Action, heal 1d12 Hit Points at the cost of gaining 1 System Strain.",
        Type = FeatureType.Major,
        Theme = strongTheme
      },

      new Feature
      {
        Name = "Brawler",
        Description = "Your unarmed and improvised attacks deal 1d8 damage instead of their normal damage.",
        Type = FeatureType.Minor,
        Theme = brawlingTheme
      },

      new Feature
      {
        Name = "Danger Sense",
        Description =
          "You have advantage on Dexterity saving throws against effects that you can see, such as traps and spells.",
        Type = FeatureType.Minor
      },

      new Feature
      {
        Name = "Fast Movement",
        Description = "Your speed increases by 10 feet.",
        Type = FeatureType.Minor,
        Theme = strongTheme
      },

      new Feature
      {
        Name = "Herculean",
        Description = "Your Carrying Capacity is doubled, and you have advantage on Athletics (Strength) skill checks.",
        Type = FeatureType.Minor,
        Theme = strongTheme
      },

      new Feature
      {
        Name = "Mindless Rage",
        Description = "You can't be Charmed or Frightened.",
        Type = FeatureType.Minor,
        Theme = strongTheme
      },

      new Feature
      {
        Name = "Pure Instinct",
        Description = "You can't be Surprised, and you have Advantage on Initiative checks.",
        Type = FeatureType.Minor
      },

      new Feature
      {
        Name = "Unarmored Defense",
        Description =
          "While you are not wearing any armor, your Armor Class equals 10 + your Dexterity modifier + your Constitution modifier.",
        Type = FeatureType.Minor,
        Theme = brawlingTheme
      },

      new Feature
      {
        Name = "Unmovable Object",
        Description =
          "You are unaffected by any attempts to push you, pull you, or otherwise displace you against your will.",
        Type = FeatureType.Minor,
        Theme = strongTheme
      },

      new Feature
      {
        Name = "Shocking Assault",
        Description =
          "You deal Shock damage regardless of the opponent's AC, and your Shock damage is increased by 2.",
        Type = FeatureType.Major,
        Theme = strongTheme
      }
    };
  }
}