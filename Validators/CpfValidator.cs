using System.Linq;
using ValidadorDocumentos.Models;

namespace ValidadorDocumentos.Validators
{
    public class CpfValidator : DocumentValidator
    {
        public override ValidationResult Validate(string input)
        {
            string cleanCpf = CleanInput(input);

            if (cleanCpf.Length != 11 || cleanCpf.Distinct().Count() == 1)
            {
                return new ValidationResult
                {
                    IsValid = false,
                    DocumentType = "CPF",
                    Message = "CPF deve conter 11 dígitos e não pode ter todos os dígitos iguais."
                };
            }

            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += (cleanCpf[i] - '0') * (10 - i);

            int firstDigit = sum % 11;
            firstDigit = firstDigit < 2 ? 0 : 11 - firstDigit;

            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += (cleanCpf[i] - '0') * (11 - i);

            int secondDigit = sum % 11;
            secondDigit = secondDigit < 2 ? 0 : 11 - secondDigit;

            bool isValid = cleanCpf[9] - '0' == firstDigit && cleanCpf[10] - '0' == secondDigit;

            return new ValidationResult
            {
                IsValid = isValid,
                DocumentType = "CPF",
                Message = isValid ? "CPF válido." : "CPF inválido."
            };
        }
    }
}
