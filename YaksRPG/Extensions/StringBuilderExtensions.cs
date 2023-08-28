using System.Text;
using YaksRPG.Models;

namespace YaksRPG.Extensions;

public static class StringBuilderExtensions
{
  /// <summary>Appends an <see cref="ICharacterClass"/> to the <see cref="StringBuilder"/>.</summary>
  public static void AppendCharacterClass(this StringBuilder stringBuilder, ICharacterClass characterClass)
  {
    stringBuilder.AppendFiller();
    
    stringBuilder.Append($$$"""
                            {{wide
                            ## {{{characterClass.Name}}}
                            }}

                            {{{characterClass.Flavour}}}
                            """);
    
    stringBuilder.AppendMajorFeaturesHeader();
    stringBuilder.AppendMinorFeaturesHeader();

    foreach (var feature in characterClass.Features)
      stringBuilder.AppendFeature(feature);
  }

  private static void AppendFiller(this StringBuilder stringBuilder)
  {
    stringBuilder.Append("""
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

  /// <summary>Appends a <see cref="Feature"/> to the <see cref="StringBuilder"/>.</summary>
  public static void AppendFeature(this StringBuilder stringBuilder, Feature feature)
  {
    stringBuilder.Append($$$"""
                         
                         {{feature
                         **{{{feature.Name}}}:** {{{feature.Description}}}
                         }}
                         """);
  }

  private static void AppendMajorFeaturesHeader(this StringBuilder stringBuilder)
  {
    stringBuilder.Append("""
                         
                         #### Major Features
                         """);
  }
  
  private static void AppendMinorFeaturesHeader(this StringBuilder stringBuilder)
  {
    stringBuilder.Append("""
                         
                         #### Minor Features
                         """);
  }
}