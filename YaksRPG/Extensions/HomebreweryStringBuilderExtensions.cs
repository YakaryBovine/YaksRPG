using System.Text;
using YaksRPG.Models;

namespace YaksRPG.Extensions;

public static class HomebreweryStringBuilderExtensions
{
  public static void AppendFiller(this StringBuilder stringBuilder)
  {
    stringBuilder.AppendLine("""
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

                         \page
                         {{pageNumber,auto}}
                         {{footnote Summary}}

                         {{wide
                         ## Introduction
                         }}
                         Introduction goes here.

                         ### Foreword
                         Foreword goes here.
                         {{wide,padding-top:350px,padding-bottom:100px

                         #### Credits

                         Credit goes here.
                         }}
                         """);
  }
  
  /// <summary>Appends an <see cref="ICharacterClass"/> to the <see cref="StringBuilder"/>.</summary>
  public static void AppendCharacterClass(this StringBuilder stringBuilder, ICharacterClass characterClass)
  {
    stringBuilder.AppendClassPageHeader(characterClass);
    stringBuilder.AppendClassHeading(characterClass);
    stringBuilder.AppendClassProgressionTable(characterClass);
    stringBuilder.AppendFeatures(characterClass, FeatureType.Core);
    stringBuilder.AppendFeatures(characterClass, FeatureType.Major);
    stringBuilder.AppendFeatures(characterClass, FeatureType.Minor);
  }

  private static void AppendClassProgressionTable(this StringBuilder stringBuilder, ICharacterClass characterClass)
  {
    stringBuilder.AppendLine("""
                         | Level | Hit Dice | Attack Bonus | Major Techniques | Minor Techniques |
                         |:-:|:-:|:-:|:--|:--|
                         """);
    for (var level = 0; level < 10; level++)
      stringBuilder.AppendClassProgressionTableLine(characterClass, level);
  }

  private static void AppendClassProgressionTableLine(this StringBuilder stringBuilder, ICharacterClass characterClass, int level)
  {
    stringBuilder.AppendLine($"| {level} | {characterClass.HitDicePerLevel * (level+1)} | +{Math.Ceiling(characterClass.AttackBonusPerLevel*(level+1))} | {level} | { 1+(level+1)/3 }");
  }
  
  private static void AppendFeatures(this StringBuilder stringBuilder, ICharacterClass characterClass, FeatureType featureType)
  {
    var matchingFeatures = characterClass.Features.Where(x => x.Type == featureType).ToList();
    if (!matchingFeatures.Any())
      return;
    
    stringBuilder.AppendLine($"#### {featureType.GetName()} Features");
    foreach (var feature in matchingFeatures)
      stringBuilder.AppendFeature(feature);
  }

  private static void AppendClassHeading(this StringBuilder stringBuilder, ICharacterClass characterClass)
  {
    stringBuilder.AppendLine($$$"""
                            {{wide
                            ## {{{characterClass.Name}}}
                            }}

                            {{{characterClass.Flavour}}}
                            """);
  }
  
  private static void AppendClassPageHeader(this StringBuilder stringBuilder, ICharacterClass characterClass)
  {
    stringBuilder.AppendLine($$$"""
                         \page
                         {{pageNumber,auto}}
                         {{footnote {{{characterClass.Name}}}}}
                         """);
  }
  
  private static void AppendFeature(this StringBuilder stringBuilder, Feature feature)
  {
    stringBuilder.AppendLine($$$"""
                         {{feature
                         **{{{feature.Name}}}:** {{{feature.Description}}}
                         }}
                         """);
  }
}