using YaksRPG;
using YaksRPG.Services;

var homebreweryDocumentBuilder = new HomebreweryDocumentBuilder();
homebreweryDocumentBuilder.AppendFiller();
homebreweryDocumentBuilder.AppendCharacterClasses(CharacterClassProvider.GetAllCharacterClasses());
var outputFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "HomebreweryGenerator", "Output.txt");
File.WriteAllText(outputFilePath, homebreweryDocumentBuilder.ToString());