using System.Text;
using YaksRPG.Extensions;
using YaksRPG.Models;

namespace YaksRPG.Services;

public sealed class HomebreweryDocumentBuilder
{
  private readonly StringBuilder _stringBuilder = new();
  private readonly List<ICharacterClass> _characterClasses = new();

  public void AddCharacterClasses(IEnumerable<ICharacterClass> characterClasses)
  {
    _characterClasses.AddRange(characterClasses);
  }
  
  public string GenerateHomebreweryDocument()
  {
    foreach (var characterClass in _characterClasses)
      StringBuilderExtensions.Append(_stringBuilder, characterClass);
      
    return _stringBuilder.ToString();
  }
}