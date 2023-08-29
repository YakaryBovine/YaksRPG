using FluentAssertions;
using Xunit;
using YaksRPG.Models;
using YaksRPG.Services;

namespace YaksRPG.Test;

public class CharacterClassTests
{
  [Theory]
  [MemberData(nameof(GetAllClasses))]
  public void AllCharacterClasses_SatisfyTheirThemes(CharacterClass characterClass, Theme theme)
  {
    characterClass.Features
      .Where(x => x.Theme == theme)
      .Should()
      .NotBeEmpty($"{characterClass.Name}s should have at least one feature that satisfies their {theme.Name} theme.");
  }

  public static IEnumerable<object[]> GetAllClasses()
  {
    foreach (var characterClass in CharacterClassProvider.GetAllCharacterClasses()) 
      foreach (var theme in characterClass.Themes)
        yield return new object[] { characterClass, theme };
  }
}