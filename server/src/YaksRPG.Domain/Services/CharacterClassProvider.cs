using YaksRPG.CharacterClasses;
using YaksRPG.Models;

namespace YaksRPG.Services;

public static class CharacterClassProvider
{
  public static IEnumerable<CharacterClass> GetAllCharacterClasses()
  {
    return new List<CharacterClass>
    {
      new Abjurer(),
      new Berserker()
    };
  }
}