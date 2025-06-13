using ValidadorDocumentos.Validators;

var validator = new CpfValidator();

Console.WriteLine("Digite um CPF para validar:");
var input = Console.ReadLine();

var result = validator.Validate(input!);
Console.WriteLine($"{result.DocumentType}: {(result.IsValid ? "✔️ Válido" : "❌ Inválido")} - {result.Message}");

// ✅ Espera uma tecla antes de fechar
Console.WriteLine("\nPressione qualquer tecla para sair...");
Console.ReadKey();
