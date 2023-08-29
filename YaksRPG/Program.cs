using YaksRPG.CharacterClasses;
using YaksRPG.Models;
using YaksRPG.Services;

var homebreweryDocumentBuilder = new HomebreweryDocumentBuilder();
homebreweryDocumentBuilder.AddCharacterClasses(new ICharacterClass[]
{
  new Berserker(),
  new Abjurer()
});
var outputFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "HomebreweryGenerator", "Output.txt");
File.WriteAllText(outputFilePath, homebreweryDocumentBuilder.GenerateHomebreweryDocument());