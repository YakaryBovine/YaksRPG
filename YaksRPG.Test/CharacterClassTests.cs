using FluentAssertions;
using Xunit;
using YaksRPG.Models;
using YaksRPG.Services;

namespace YaksRPG.Test;

public class CharacterClassTests
{
  [Theory]
  [MemberData(nameof(GetAllClasses))]
  public void AllCharacterClasses_SatisfyTheirThemes(ICharacterClass characterClass)
  {
    foreach (var theme in characterClass.Themes)
      characterClass.Features
        .Where(x => x.Theme == theme)
        .Should()
        .NotBeEmpty($"{characterClass.Name}s should have at least a few {nameof(Feature)} that satisfy their {theme.Name} {nameof(Theme)}.");
  }

  public static IEnumerable<object[]> GetAllClasses()
  {
    return CharacterClassProvider.GetAllCharacterClasses().Select(characterClass => new object[] { characterClass });
  }
}