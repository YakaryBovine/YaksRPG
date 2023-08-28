using YaksRPG.CharacterClasses;
using YaksRPG.Services;

var homebreweryDocumentBuilder = new HomebreweryDocumentBuilder();
homebreweryDocumentBuilder.AddCharacterClasses(new []
{
  new Berserker()
});
var outputFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "HomebreweryGenerator", "Output.txt");
File.WriteAllText(outputFilePath, homebreweryDocumentBuilder.GenerateHomebreweryDocument());