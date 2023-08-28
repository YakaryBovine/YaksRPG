using System.Text;
using YaksRPG.Models;

namespace YaksRPG.Extensions;

public static class StringBuilderExtensions
{
  /// <summary>Appends an <see cref="ICharacterClass"/> to the <see cref="StringBuilder"/>.</summary>
  public static void AppendCharacterClass(this StringBuilder stringBuilder, ICharacterClass characterClass)
  {
    stringBuilder.Append($$$"""
                            {{wide
                            ## {{{characterClass.Name}}}
                            }}

                            {{{characterClass.Flavour}}}
                            """);

    foreach (var feature in characterClass.Features)
      stringBuilder.AppendFeature(feature);
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
}