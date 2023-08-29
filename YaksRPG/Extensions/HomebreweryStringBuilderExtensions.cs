using System.Text;
using YaksRPG.Models;

namespace YaksRPG.Extensions;

public static class HomebreweryStringBuilderExtensions
{
  /// <summary>Appends an <see cref="ICharacterClass"/> to the <see cref="StringBuilder"/>.</summary>
  public static void AppendCharacterClass(this StringBuilder stringBuilder, ICharacterClass characterClass)
  {
    stringBuilder.AppendClassPageHeader(characterClass);
    stringBuilder.AppendClassHeading(characterClass);
    
    stringBuilder.AppendFeaturesHeading(FeatureType.Core);
    foreach (var feature in characterClass.Features.Where(x => x.Type == FeatureType.Core))
      stringBuilder.AppendFeature(feature);
    
    stringBuilder.AppendFeaturesHeading(FeatureType.Major);
    foreach (var feature in characterClass.Features.Where(x => x.Type == FeatureType.Major))
      stringBuilder.AppendFeature(feature);
    
    stringBuilder.AppendFeaturesHeading(FeatureType.Minor);
    foreach (var feature in characterClass.Features.Where(x => x.Type == FeatureType.Minor))
      stringBuilder.AppendFeature(feature);
  }

  public static void AppendFiller(this StringBuilder stringBuilder)
  {
    stringBuilder.Append("""
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

  private static void AppendClassHeading(this StringBuilder stringBuilder, ICharacterClass characterClass)
  {
    stringBuilder.Append($$$"""

                            {{wide
                            ## {{{characterClass.Name}}}
                            }}

                            {{{characterClass.Flavour}}}
                            """);
  }
  
  private static void AppendClassPageHeader(this StringBuilder stringBuilder, ICharacterClass characterClass)
  {
    stringBuilder.Append($$$"""
                         
                         \page
                         {{pageNumber,auto}}
                         {{footnote {{{characterClass.Name}}}}}
                         """);
  }
  
  private static void AppendFeature(this StringBuilder stringBuilder, Feature feature)
  {
    stringBuilder.Append($$$"""
                         
                         {{feature
                         **{{{feature.Name}}}:** {{{feature.Description}}}
                         }}
                         """);
  }

  private static void AppendFeaturesHeading(this StringBuilder stringBuilder, FeatureType featureType)
  {
    stringBuilder.Append($"""
                         
                         #### {featureType.GetName()} Features
                         """);
  }
}