﻿using System.Text;
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
    _stringBuilder.AppendFiller();
    foreach (var characterClass in _characterClasses)
      _stringBuilder.AppendCharacterClass(characterClass);
      
    return _stringBuilder.ToString();
  }
}