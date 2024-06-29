using System.Text;
using YaksRPG.Extensions;
using YaksRPG.Models;

namespace YaksRPG;

public sealed class HomebreweryDocumentBuilder
{
  private readonly StringBuilder _stringBuilder = new();

  public override string ToString() => _stringBuilder.ToString();

  public void AppendFiller()
  {
    _stringBuilder.AppendLine("""
                             ![bg main](https://images.squarespace-cdn.com/content/v1/548a736be4b04f6e8e823d49/1596045860203-OCM1RXRUY9KWLF2AB4Q2/Avartar-4-naomi-vandoren-web1080-crop.jpg?format=1000w) {position:absolute;top:-150px;left:-180px;height:1210px;}

                             {{margin-top:700px

                             }}

                             # {{font-size:158px Yak's}}<br />Fantasy RPG

                             \page
                             {{pageNumber,auto}}
                             {{footnote Table of Contents}}


                             {{toc,wide,column-count:1
                             # Table Of Contents
                             
                               - ## [{{ Introduction}}{{ 2}}](#p3)
                               - ## [{{ Berserker}}{{ 3}}](#p4)
                             }}
                             """);
  }

  public void AppendCharacterClasses(IEnumerable<CharacterClass> characterClasses)
  {
    foreach (var characterClass in characterClasses)
      AppendCharacterClass(characterClass);
  }

  private void AppendCharacterClass(CharacterClass characterClass)
  {
    AppendClassPageHeader(characterClass);
    AppendClassHeading(characterClass);
    AppendThemes(characterClass);
    AppendFlavour(characterClass);
    AppendProgressionTable(characterClass);
    AppendFeatures(characterClass, FeatureType.Core);
    AppendFeatures(characterClass, FeatureType.Major);
    AppendFeatures(characterClass, FeatureType.Minor);
  }

  private void AppendProgressionTable(CharacterClass characterClass)
  {
    _stringBuilder.AppendLine("""
                             | Level | Hit Dice | Attack Bonus | Major Techniques | Minor Techniques |
                             |:-:|:-:|:-:|:-:|:-:|
                             """);
    for (var level = 0; level < 10; level++)
      AppendClassProgressionTableLine(characterClass, level);
  }

  private void AppendClassProgressionTableLine(CharacterClass characterClass, int level)
  {
    var levelPlusOne = level + 1;
    _stringBuilder.AppendLine($"| {levelPlusOne} | {characterClass.HitDicePerLevel * levelPlusOne} | +{Math.Ceiling(characterClass.AttackBonusPerLevel*levelPlusOne)} | {levelPlusOne} | { 1+levelPlusOne/3 }");
  }

  private void AppendFeatures(CharacterClass characterClass, FeatureType featureType)
  {
    var matchingFeatures = characterClass.Features
      .Where(x => x.Type == featureType)
      .OrderBy(x => x.Theme?.Name)
      .ToList();
    
    if (!matchingFeatures.Any())
      return;
    
    _stringBuilder.AppendLine($"#### {featureType.GetName()} Features");
    foreach (var feature in matchingFeatures)
      AppendFeature(feature);
  }

  private void AppendClassHeading(CharacterClass characterClass)
  {
    _stringBuilder.AppendLine($$$"""
                                {{wide
                                ## {{{characterClass.Name}}}
                                }}
                                """);
  }

  private void AppendFlavour(CharacterClass characterClass) => _stringBuilder.AppendLine($"{characterClass.Flavour}");

  private void AppendClassPageHeader(CharacterClass characterClass)
  {
    _stringBuilder.AppendLine($$$"""
                                \page
                                {{pageNumber,auto}}
                                {{footnote {{{characterClass.Name}}}}}
                                """);
  }

  private void AppendFeature(Feature feature)
  {
    _stringBuilder.AppendLine($$$"""
                                {{feature
                                **{{{feature.Name}}}:** {{{feature.Description}}}
                                }}
                                """);
  }

  private void AppendThemes(CharacterClass characterClass)
  {
    _stringBuilder.AppendLine("""
                              | Themes |  |
                              |:------|---------:|
                              """);
    var orderedThemes = characterClass.Themes.OrderBy(x => x.Name);
    foreach (var theme in orderedThemes)
      AppendThemeTableLine(theme);
    
    _stringBuilder.AppendLine();
  }

  private void AppendThemeTableLine(Theme theme) => _stringBuilder.AppendLine($"| {theme.Name} | {theme.Description} |");
}