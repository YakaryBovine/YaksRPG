using YaksRPG.Extensions;
using YaksRPG.Models;

namespace YaksRPG.CharacterClasses;

public sealed class Abjurer : CharacterClass
{
  public override string Name => "Abjurer";

  public override string Flavour => """
                                    The School of Abjuration emphasizes magic that blocks, banishes, or protects. Detractors of this school say that its tradition is about denial, negation rather than positive assertion. You understand, however, that ending harmful effects, protecting the weak, and banishing evil influences is anything but a philosophical void. It is a proud and respected vocation.
                                      
                                    Called abjurers, members of this school are sought when baleful spirits require exorcism, when important locations must be guarded against magical spying, and when portals to other planes of existence must be closed.
                                    """;

  public override DiceRoll HitDicePerLevel { get; } = new(1, 6, -2);

  public override float AttackBonusPerLevel => 0.5f;

  public override IEnumerable<Feature> Features { get; } = new[]
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
      Name = "Assert Magic",
      Description = "When a creature within 60 feet of you succeeds on a Saving Throw against a spell, you can use your Reaction to force it to reroll the throw once.",
      Type = FeatureType.Major
    },
    
    new Feature
    {
      Name = "Signature Spell",
      Description = $"When you acquire this Feature, choose another Feature that costs mana, and permanently half its {ResourceType.Mana.GetName()} cost.",
      Type = FeatureType.Major
    },
    
    new Feature
    {
      Name = "Mana",
      Description = $"You have a limited pool of {ResourceType.Mana.GetName()}, which is used to fuel your spells. Your {ResourceType.Mana.GetName()} is equal to 10 plus your Intelligence modifier. You regain half of your mana, rounded down, whenever you rest.",
      Type = FeatureType.Core
    },
    
    new Feature
    {
      Name = "Warp",
      Description = $"As a {ActionType.Side.GetName()}, choose yourself or a willing ally within 15 feet and teleport it to an occupied visible location within 30 feet.",
      Type = FeatureType.Major
    },
    
    new Feature
    {
      Name = "Glyphwork",
      Description = $"You can spend 10 minutes inscribing glyphs into the structure of a room no larger than 100 feet by 100 feet. While within that room, the inscribed glyphs collectively have 5 {ResourceType.Mana.GetName()}, and you can spend that {ResourceType.Mana.GetName()} as if it were your own.",
      Type = FeatureType.Minor
    },
          
    new Feature
    {
      Name = "Arcane Ward",
      Description = $"When you spend {ResourceType.Mana.GetName()}, you gain temporary hit points equal to the {ResourceType.Mana.GetName()} spent.",
      Type = FeatureType.Major
    },
    
    new Feature
    {
      Name = "Mind Fortress",
      Description = "As a Main Action, touch a creature to grant it resistance to psychic damage, as well as advantage on Intelligence, Wisdom, and Charisma saving throws for up to one hour.",
      Type = FeatureType.Major
    },
    
    new Feature
    {
      Name = "Redirect Spell",
      Description = "When a creature within 60 feet of you would be successfully affected by a spell that explicitly targets them, you can use your Reaction to choose another target for the spell. If the caster is unwilling, you must succeed an Arcana (Intelligence) skill check at a DC equal to 10 plus the caster's level, or the spell is not redirected.",
      Type = FeatureType.Major
    },
    
    new Feature
    {
      Name = "Circle of Power",
      Description = $"As a {ActionType.Main.GetName()}, inscribe a magical 10-foot radius circle on the floor underneath you. The circle has 5 {ResourceType.Mana}, which friendly casters standing on the circle may use to fuel their spells. The circle disappears once it runs out of mana.",
      Type = FeatureType.Major
    },
    
    new Feature
    {
      Name = "Reiterate",
      Description = $"When a creature within 60 feet of you successfully casts a spell, you can use your {ActionType.Reaction.GetName()} to cast that spell again. You may choose new targets for the spell, but may not change anything else. If the caster is unwilling, you must succeed an Arcana (Intelligence) skill check at a DC equal to 10 plus the caster's level, or the spell is not reiterated.",
      Type = FeatureType.Major
    },
    
    new Feature
    {
      Name = "Store Magic",
      Description = $"You can spend 10 minutes to store a spell you know in a mundane object, spending {ResourceType.Mana.GetName()} equal to its ordinary cost. The holder of the item may then cast the spell within without spending {ResourceType.Mana.GetName()}, destroying the object in the process. You may only store spells in three objects at a time, and any spells stored this way dissipate when you rest.",
      Type = FeatureType.Major
    },
    
    new Feature
    {
      Name = "Portal",
      Description = $"As a {ActionType.Main.GetName()}, create a portal between two points that you can see within 120 feet. Creatures can move through one portal to the other. The portals last until the end of the scene.",
      Type = FeatureType.Major
    },
    
    new Feature
    {
      Name = "Disrupt Portal",
      Description = $"As a {ActionType.Main.GetName()}, touch a portal and destroy it permanently. If the caster is unwilling, you must succeed an Arcana (Intelligence) skill check at a DC equal to 10 plus the caster's level. On a failure, the portal is not destroyed and you cannot try again until you rest.",
      Type = FeatureType.Minor
    },
    
    new Feature
    {
      Name = "Antimagic Zone",
      Description = $"As a {ActionType.Main.GetName()}, create a 10-foot radius Antimagic Zone around a visible point within 60 feet. Creatures and objects within the zone are unaffected by magic, magical effects cannot pass through it or function within it, and enchanted objects behave as if they are mundane. Deities and artifacts may ignore the effects of the zone.",
      Type = FeatureType.Major
    },
    
    new Feature
    {
      Name = "Transfer Mana",
      Description = $"As a {ActionType.Main.GetName()}, choose a target within 60 feet and either transfer 4 {ResourceType.Mana.GetName()} from you to them or transfer 4 {ResourceType.Mana.GetName()} from them to you. If you choose to take Mana, the target makes a Wisdom Saving Throw; on a success, you only take 2 {ResourceType.Mana.GetName()}.",
      Type = FeatureType.Major
    },
    
    new Feature
    {
      Name = "Banish",
      Description = $"As a {ActionType.Main.GetName()}, banish a visible creature within 60 feet to a harmless demiplane. At the end of each of its turns, the target may make a Charisma Saving Throw, and on a failure, it reappears in the space it left or in the nearest unoccupied space if that space is occupied.",
      Type = FeatureType.Major
    },
    
    new Feature
    {
      Name = "Pocket Demiplane",
      Description = "You can spend 6 hours touching a door, manhole, or other entrance to transform it into the entrance to a demiplane containing a single villa. The villa has four bedrooms, two bathrooms, an entertainment room, two offices, and a basement. The demiplane contains nothing but the villa, and has no outdoors. Creatures may enter the demiplane via the entrance you create, and may leave via the front door. You can destroy the entrance from any distance with one hour of focus, at which point the occupants are safely ejected. The contents of the demiplane are preserved, and if you make a new entrance, you return to the same villa.",
      Type = FeatureType.Minor
    },
    
    new Feature
    {
      Name = "Mark and Recall",
      Description = $"As a {ActionType.Main.GetName()}, either designate your current location as a Mark, or teleport to your Mark.",
      Type = FeatureType.Minor
    },
    
    new Feature
    {
      Name = "Barrier Bubble",
      Description = $"As a {ActionType.Main.GetName()}, conjure a 10-foot radius spherical bubble around yourself. The bubble has 10 AC and hit points equal to 10 + your level + your Intelligence modifier. Damage that would be dealt to friendly creatures within the bubble from sources outside the bubble instead damage the bubble. The bubble dissipates at the start of your turn unless you spend your {ActionType.Main.GetName()} to sustain it.",
      Type = FeatureType.Major
    }
  };

  public override IEnumerable<Theme> Themes { get; } = new[]
  {
    new Theme
    {
      Name = "Shields",
      Description = "Protect yourself and others from damage and unwanted effects using magical shields."
    },
    new Theme
    {
      Name = "Spell Manipulation",
      Description = "Enhance, diminish, redirect, reuse, or otherwise change other magical effects."
    },
    new Theme
    {
      Name = "Teleportation",
      Description = "Magically relocate yourself, allies, or enemies."
    }
  };
}