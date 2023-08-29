using YaksRPG.CharacterClasses;
using YaksRPG.Models;

namespace YaksRPG.Services;

public static class CharacterClassProvider
{
  public static IEnumerable<ICharacterClass> GetAllCharacterClasses()
  {
    return new List<ICharacterClass>
    {
      new Abjurer(),
      new Berserker()
    };
  }
}