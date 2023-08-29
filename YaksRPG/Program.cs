using YaksRPG;
using YaksRPG.CharacterClasses;
using YaksRPG.Models;

var homebreweryDocumentBuilder = new HomebreweryDocumentBuilder();
homebreweryDocumentBuilder.AppendFiller();
homebreweryDocumentBuilder.AppendCharacterClasses(new ICharacterClass[]
{
  new Berserker(),
  new Abjurer()
});
var outputFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "HomebreweryGenerator", "Output.txt");
File.WriteAllText(outputFilePath, homebreweryDocumentBuilder.ToString());