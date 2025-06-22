using ValidadorDocumentos.Validators;

//var validator = new CpfValidator();

//Console.WriteLine("Digite um CPF para validar:");
//var input = Console.ReadLine();

//var result = validator.Validate(input!);
//Console.WriteLine($"{result.DocumentType}: {(result.IsValid ? "✔️ Válido" : "❌ Inválido")} - {result.Message}");

//// ✅ Espera uma tecla antes de fechar
//Console.WriteLine("\nPressione qualquer tecla para sair...");
//Console.ReadKey();

//

 Console.WriteLine("Digite 1 para validar CPF ou 2 para validar CNPJ:");
var opcao = Console.ReadLine();

DocumentValidator validator;
string tipoDocumento;

if (opcao == "2")
{
    validator = new CnpjValidator();
    tipoDocumento = "CNPJ";
}
else
{
    validator = new CpfValidator();
    tipoDocumento = "CPF";
}

Console.WriteLine($"Digite um {tipoDocumento} para validar:");
var input = Console.ReadLine();

var result = validator.Validate(input!);
Console.WriteLine($"{result.DocumentType}: {(result.IsValid ? "✔️ Válido" : "❌ Inválido")} - {result.Message}");

Console.WriteLine("\nPressione qualquer tecla para sair...");
Console.ReadKey();