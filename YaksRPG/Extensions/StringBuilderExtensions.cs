using System.Text;
using YaksRPG.Models;

namespace YaksRPG.Extensions;

public static class StringBuilderExtensions
{
  public static void Append(this StringBuilder stringBuilder, ICharacterClass characterClass)
  {
    stringBuilder.Append($$$"""
                            {{wide
                            ## {{{characterClass.Name}}}
                            }}
                            """);
  }
}